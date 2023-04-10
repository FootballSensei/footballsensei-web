using FootballSensei.Models.DTOs;
using FootballSensei.Services.MatchService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballSensei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatches();
            Console.WriteLine("GetAllMatches called");
            return Ok(matches);
        }

        [HttpGet ("getMatchById/{id}")]
        public async Task<IActionResult> GetMatchById(Guid id)
        {
            var match = await _matchService.GetMatchById(id);
            return Ok(match);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDTO matchDTO)
        {
            var matches = await _matchService.CreateMatch(matchDTO);
            return Ok(matches);
        }
    }
}
