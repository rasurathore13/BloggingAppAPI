using BloggingAppAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingAppAPI.IRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogs();
        Task<Blog> GetBlogDetails(int blogId);
    }
}
