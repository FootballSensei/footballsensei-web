

using AutoMapper;
using FootballSensei.Models;
using FootballSensei.Models.DTOs;
using FootballSensei.Repositories.MatchRepository;

namespace FootballSensei.Services.MatchService
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<List<MatchDTO>> CreateMatch(CreateMatchDTO matchDTO)
        {
            var match = _mapper.Map<Match>(matchDTO);
            await _matchRepository.CreateAsync(match);
            await _matchRepository.SaveAsync();
            var matches = await _matchRepository.GetAllAsync();
            var matchesDTO = _mapper.Map<List<MatchDTO>>(matches);
            return matchesDTO;
        }

        public async Task<List<MatchDTO>> GetAllMatches()
        {
            var matches = await _matchRepository.GetAllAsync();
            var matchesDTO = _mapper.Map<List<MatchDTO>>(matches);
            return matchesDTO;
        }
    }
}
