using FootballSensei.Models.DTOs;

namespace FootballSensei.Services.MatchService
{
    public interface IMatchService
    {
        public Task<List<MatchDTO>> CreateMatch(CreateMatchDTO matchDTO);
        public Task<List<MatchDTO>> GetAllMatches();
    }
}
