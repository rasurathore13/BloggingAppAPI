
using System.Collections.Generic;
using System.Threading.Tasks;
using BloggingAppAPI.IRepository;
using BloggingAppAPI.Model;
using BloggingAppAPI.UIModel;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("GetBlogDetails")]
        public async Task<IActionResult> GetBlogDetails([FromQuery]int blogId)
        {
            BlogInfo blogToReturn = await _blogRepository.GetBlogDetails(blogId);
            if (blogToReturn != null)
            {
                return Ok(blogToReturn);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddBlog")]
        [Authorize]
        public async Task<IActionResult> AddBlog([FromBody] BlogInfo blogInfo) 
        {
            return Ok(await _blogRepository.AddBlog(blogInfo));
        }
    }
}