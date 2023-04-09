using FootballSensei.Data;
using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;

namespace FootballSensei.Repositories.MatchRepository
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(ProjectContext context) : base(context) { }
    }
    
    
}
