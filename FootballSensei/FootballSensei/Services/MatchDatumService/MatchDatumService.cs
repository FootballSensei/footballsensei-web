using FootballSensei.Models;
using FootballSensei.Repositories.MatchDatumRepository;

namespace FootballSensei.Services.MatchDatumService
{
    public class MatchDatumService : IMatchDatumService
    {
        private readonly IMatchDatumRepository _matchDatumRepository;
        
        public MatchDatumService(IMatchDatumRepository matchDatumRepository)
        {
                _matchDatumRepository = matchDatumRepository;
        
        
        }

        public async Task<MatchDatum> GetMatchByTeams(String homeTeam, String awayTeam)
        {
            return await _matchDatumRepository.GetMatchByTeams(homeTeam, awayTeam);
        }
    
          
    }
}
