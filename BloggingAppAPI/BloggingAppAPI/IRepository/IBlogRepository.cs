using BloggingAppAPI.Model;
using BloggingAppAPI.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingAppAPI.IRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogs();
        Task<BlogInfo> GetBlogDetails(int blogId);
        Task<Blog> AddBlog(BlogInfo blogInfo);
    }
}
