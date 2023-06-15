using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace FootballSensei.Repositories.LineupDatumRepository
{
    public class LineupDatumRepository : GenericRepository<LineupDatum>, ILineupDatumRepository
    {
       public LineupDatumRepository(FootballsenseiContext context) : base(context) { }

        public async Task<List<LineupDatum>> GetLineupDatumsAsync()
        {
            return await _context.LineupData
                .ToListAsync();
        }

        public async Task<LineupDatum> GetLineupDatumByTeams(String homeTeam, String awayTeam)
        {
            String ht = homeTeam.Replace(" ", "");
            String at = awayTeam.Replace(" ", "");
            ht = ht.Replace("%20", "");

            Console.WriteLine(ht);
            Console.WriteLine(at);
            return await _context.LineupData
                .Where(ld => ld.HomeTeam.Replace(" ", "").Equals(ht) && ld.AwayTeam.Replace(" ", "").Equals(at))
                .FirstOrDefaultAsync();
        
        }
    }
}
