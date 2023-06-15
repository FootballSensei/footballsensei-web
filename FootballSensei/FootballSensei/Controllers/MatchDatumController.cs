using FootballSensei.Services.MatchDatumService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballSensei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchDatumController : ControllerBase
    {
        public readonly IMatchDatumService _matchDatumService;
        private readonly HttpClient _httpClient;

        public MatchDatumController(IMatchDatumService matchDatumService)
        {
            _matchDatumService = matchDatumService;
            _httpClient = new HttpClient();
        }

        [HttpPost("prediction/{homeTeam}/{awayTeam}")]
        public async Task<IActionResult> GetPrediction(string homeTeam, string awayTeam)
        {
            string ht = homeTeam.Replace(" ", "");
            string at = awayTeam.Replace(" ", "");
            var match = await _matchDatumService.GetMatchByTeams(ht, at);

            // Prepare the API URL with the provided parameters
            string apiUrl = $"http://ai:8000/api/score?HTP={match.Htp}&ATP={match.Atp}&HM1_D={match.Hm1D}&HM1_L={match.Hm1L}&HM1_M={match.Hm1M}&HM1_W={match.Hm1W}&HM2_D={match.Hm2D}&HM2_L={match.Hm2L}&HM2_M={match.Hm2M}&HM2_W={match.Hm2W}&HM3_D={match.Hm3D}&HM3_L={match.Hm3L}&HM3_M={match.Hm3M}&HM3_W={match.Hm3W}&AM1_D={match.Am1D}&AM1_L={match.Am1L}&AM1_M={match.Am1M}&AM1_W={match.Am1W}&AM2_D={match.Am2D}&AM2_L={match.Am2L}&AM2_M={match.Am2M}&AM2_W={match.Am2W}&AM3_D={match.Am3D}&AM3_L={match.Am3L}&AM3_M={match.Am3M}&AM3_W={match.Am3W}&HTGD={match.Htgd}&ATGD={match.Atgd}&DiffFormPoints={match.DiffFormPts}";

            // Send the HTTP POST request
            var response = await _httpClient.PostAsync(apiUrl, null);

            if (response.IsSuccessStatusCode)
            {
                // Handle successful response
                var result = await response.Content.ReadAsStringAsync();
                // Process the result as needed
                return Ok(result);
            }
            else
            {
                // Handle error response
                return StatusCode((int)response.StatusCode);
            }
        }

    }
}
