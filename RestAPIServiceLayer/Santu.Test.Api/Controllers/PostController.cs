using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContentRepository.Services;
using ContentRepository.Entities;
using ContentRepository.Services.Interface;
using Framework;

namespace Santu.Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IContentService _contentservice;
        public PostController(ContentServiceResolver contentServiceResolver, IServiceArgsHelper serviceArgsHelper)
        {
            _ = contentServiceResolver ?? throw new ArgumentNullException(nameof(contentServiceResolver));
            _ = serviceArgsHelper ?? throw new ArgumentNullException(nameof(serviceArgsHelper));
            var serviceArgs = serviceArgsHelper.GetUserSpecficArgs() ?? throw new ArgumentNullException("serviceArgs");
            _contentservice = contentServiceResolver(serviceArgs);
        }


        [Route("GetPost")]
        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            List<Post> result = await _contentservice.GetPosts();
            return Ok(result);
        }
    }
}
