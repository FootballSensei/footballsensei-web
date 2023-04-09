using FootballSensei.Models.DTOs;
using FootballSensei.Services.PlayerService;
using Microsoft.AspNetCore.Mvc;

namespace FootballSensei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayers();
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerDTO playerDTO)
        {
            var players = await _playerService.CreatePlayer(playerDTO);
            return Ok(players);
        }
        

    }
}
