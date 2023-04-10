using FootballSensei.Data;
using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace FootballSensei.Repositories.MatchRepository
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(ProjectContext context) : base(context) { }

        public async Task<Match> GetMatchById(Guid id)
        {
            
            return await _context.Matches.FirstOrDefaultAsync(m => m.Id == id);
            
        }

    }
    
    
}
