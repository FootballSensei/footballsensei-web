using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;

namespace FootballSensei.Repositories.LineupDatumRepository
{
    public interface ILineupDatumRepository : IGenericRepository<LineupDatum>
    {
        public Task<List<LineupDatum>> GetLineupDatumsAsync();
        public Task<LineupDatum> GetLineupDatumByTeams(String homeTeam, String awayTeam);
    }
}
