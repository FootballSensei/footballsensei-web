using FootballSensei.Services.LineupDatumService;
using Microsoft.AspNetCore.Mvc;

namespace FootballSensei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineupDatumController : ControllerBase
    {
        public readonly ILineupDatumService _lineupDatumService;

        public LineupDatumController(ILineupDatumService lineupDatumService)
        {
              _lineupDatumService = lineupDatumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLineupDatumsAsync()
        {
            var lineupDatums = await _lineupDatumService.GetLineupDatumsAsync();
            return Ok(lineupDatums);
        }

        [HttpGet ("match/{homeTeam}/{awayTeam}")]
        public async Task<IActionResult> GetLineupDatumByTeams(String homeTeam, String awayTeam)
        {
            String ht = homeTeam.Replace(" ", "");
            String at = awayTeam.Replace(" ", "");
            var lineupDatum = await _lineupDatumService.GetLineupDatumByTeams(ht, at);
            return Ok(lineupDatum);
        }
    }
}
