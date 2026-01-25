using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Telhai.Csharpproject.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello from ASP.NET API ...";
        }


        [HttpPost("echo")]
        public string Echo([FromBody] string text)
        {
            return $"Server got: {text}" +DateTime.Now;
        }
    }
}
