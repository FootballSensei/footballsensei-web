using FootballSensei.Models;

namespace FootballSensei.Services.MatchDatumService
{
    public interface IMatchDatumService
    {
        public Task<MatchDatum> GetMatchByTeams(String homeTeam, String awayTeam);
    }
}
