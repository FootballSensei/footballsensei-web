using AutoMapper;
using FootballSensei.Models;
using FootballSensei.Models.DTOs;
using FootballSensei.Repositories.PlayerRepository;

namespace FootballSensei.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {

        public readonly IPlayerRepository _playerRepository;
        public readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<List<PlayerDTO>> CreatePlayer(CreatePlayerDTO playerDTO)
        {
            var player = _mapper.Map<Player>(playerDTO);
            await _playerRepository.CreateAsync(player);
            await _playerRepository.SaveAsync();
            var players = await _playerRepository.GetAllAsync();
            var playersDTO = _mapper.Map<List<PlayerDTO>>(players);
            return playersDTO;
        }

        public async Task<List<PlayerDTO>> GetAllPlayers()
        {
            
            var players = await _playerRepository.GetAllAsync();
            var playerDTOs = _mapper.Map<List<PlayerDTO>>(players);
            return playerDTOs;
            
        }

    }
}
