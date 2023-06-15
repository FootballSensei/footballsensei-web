using FootballSensei.Models;
using FootballSensei.Repositories.LineupDatumRepository;

namespace FootballSensei.Services.LineupDatumService
{
    public class LineupDatumService : ILineupDatumService
    {
        private readonly ILineupDatumRepository _lineupDatumRepository;
        
        public LineupDatumService(ILineupDatumRepository lineupDatumRepository)
        {
            _lineupDatumRepository = lineupDatumRepository;
        }

        public async Task<List<LineupDatum>> GetLineupDatumsAsync()
        {
            return await _lineupDatumRepository.GetLineupDatumsAsync();
        }

        public async Task<LineupDatum> GetLineupDatumByTeams(String homeTeam, String awayTeam)
        {
            return await _lineupDatumRepository.GetLineupDatumByTeams(homeTeam, awayTeam);
        }

    }
}
