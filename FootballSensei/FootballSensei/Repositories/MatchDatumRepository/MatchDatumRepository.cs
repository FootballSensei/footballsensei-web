using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace FootballSensei.Repositories.MatchDatumRepository
{
    public class MatchDatumRepository : GenericRepository<MatchDatum>, IMatchDatumRepository
    {
        public MatchDatumRepository(FootballsenseiContext context) : base(context) { }

        public async Task<MatchDatum> GetMatchByTeams(String homeTeam, String awayTeam){
            String ht = homeTeam.Replace(" ", "");
            String at = awayTeam.Replace(" ", "");
            ht = ht.Replace("%20", "");

            Console.WriteLine(ht);
            Console.WriteLine(at);
            
            return await _context.MatchData
                .Where(md => md.HomeTeamName.Replace(" ", "").Equals(ht) && md.AwayTeamName.Replace(" ", "").Equals(at))
                .FirstOrDefaultAsync();
        }

    }
    
}
