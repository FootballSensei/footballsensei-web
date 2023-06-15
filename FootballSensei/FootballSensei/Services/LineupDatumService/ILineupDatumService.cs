using FootballSensei.Models;

namespace FootballSensei.Services.LineupDatumService
{
    public interface ILineupDatumService
    {
        public Task<List<LineupDatum>> GetLineupDatumsAsync();
        public Task<LineupDatum> GetLineupDatumByTeams(String homeTeam, String awayTeam);
    }
}
