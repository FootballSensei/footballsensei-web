using FootballSensei.Models;
using FootballSensei.Data;
using FootballSensei.Repositories.GenericRepository;

namespace FootballSensei.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team> ,ITeamRepository
    {
        public TeamRepository(ProjectContext context) : base(context) { }
    }
}
