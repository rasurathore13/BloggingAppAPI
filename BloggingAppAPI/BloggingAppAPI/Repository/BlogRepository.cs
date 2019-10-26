using BloggingAppAPI.IRepository;
using BloggingAppAPI.Model;
using BloggingAppAPI.UIModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BloggingAppAPI.Repository
{
    public class BlogRepository : IBlogRepository
    {

        private readonly BlogDbContext _dbContext;

        public BlogRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Blog> AddBlog(BlogInfo blogInfo)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Blog blog = new Blog()
                    {
                        BlogMainImageUrl = blogInfo.BlogMainImageUrl,
                        BlogHeading = blogInfo.BlogHeading,
                        BlogAuthor = blogInfo.BlogAuthor,
                        BlogBrief = blogInfo.BlogBrief,
                        BlogDateTimeStamp = DateTime.UtcNow,
                    };
                    await _dbContext.Blogs.AddAsync(blog);
                    await _dbContext.SaveChangesAsync();
                    BlogBody blogBody = new BlogBody()
                    {
                        BlogId = blog.BlogId,
                        EntireBlog = blogInfo.BlogBody,
                    };
                    await _dbContext.BlogBodies.AddAsync(blogBody);
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                    return blog;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
                
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            List<Blog> listOfBlogs= await _dbContext.Blogs.ToListAsync();
            return listOfBlogs;
        }

        public async Task<BlogInfo> GetBlogDetails(int blogId)
        {

            Blog blog = await _dbContext.Blogs
                                   .Where(x => x.BlogId == blogId)
                                   .FirstOrDefaultAsync();
            BlogBody blogBody = await _dbContext.BlogBodies
                                          .Where(x => x.BlogId == blog.BlogId)
                                          .FirstOrDefaultAsync();
            
            if (blog != null && blogBody != null)
            {
                BlogInfo blogInfo = new BlogInfo()
                {
                    BlogId = blog.BlogId,
                    BlogHeading = blog.BlogHeading,
                    BlogAuthor = blog.BlogAuthor,
                    BlogBrief = blog.BlogBrief,
                    BlogDateTimeStamp = blog.BlogDateTimeStamp,
                    BlogMainImageUrl = blog.BlogMainImageUrl,
                    BlogBody = blogBody.EntireBlog,
                };
                return blogInfo;
            }
            else
            {
                return null;
            }
        }
    }
}
