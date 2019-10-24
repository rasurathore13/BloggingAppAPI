using BloggingAppAPI.IRepository;
using BloggingAppAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingAppAPI.Repository
{
    public class BlogRepository : IBlogRepository
    {

        private readonly BlogDbContext _dbContext;

        public BlogRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            List<Blog> listOfBlogs= await _dbContext.Blogs.ToListAsync();
            return listOfBlogs;
        }
    }
}
