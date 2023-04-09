using FootballSensei.Models.DTOs;
using FootballSensei.Services.TeamService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballSensei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeams();
            return Ok(teams);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDTO teamDTO)
        {
            var teams = await _teamService.CreateTeam(teamDTO);
            return Ok(teams);
        }
    }
}
