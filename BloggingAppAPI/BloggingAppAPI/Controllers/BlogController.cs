
using System.Collections.Generic;
using System.Threading.Tasks;
using BloggingAppAPI.IRepository;
using BloggingAppAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BloggingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        [Route("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            List<Blog> listOfBlog = await _blogRepository.GetAllBlogs();
            return Ok(listOfBlog);
        }
    }
}