using FootballSensei.Models.DTOs;

namespace FootballSensei.Services.PlayerService
{
    public interface IPlayerService
    {
        public Task<List<PlayerDTO>> CreatePlayer(CreatePlayerDTO playerDTO);
        public Task<List<PlayerDTO>> GetAllPlayers();
    }
}
