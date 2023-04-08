using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballSensei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
