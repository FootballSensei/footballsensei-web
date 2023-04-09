using FootballSensei.Models;
using FootballSensei.Data;
using FootballSensei.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace FootballSensei.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team> ,ITeamRepository
    {
        public TeamRepository(ProjectContext context) : base(context) { }

        public async Task<List<Team>> GetAllWithTeamsAsync()
        {
            return await _context.Teams
                .Include(t => t.Players)
                .ToListAsync();
        }
    }
}
