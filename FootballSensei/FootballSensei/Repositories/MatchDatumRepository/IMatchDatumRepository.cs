using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;

namespace FootballSensei.Repositories.MatchDatumRepository
{
    public interface IMatchDatumRepository : IGenericRepository<MatchDatum>
    {
        public Task<MatchDatum> GetMatchByTeams(String homeTeam, String awayTeam);
    }
}
