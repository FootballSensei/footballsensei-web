using FootballSensei.Models;
using ProiectASPNET.Data;
using ProiectASPNET.Repositories.GenericRepository;

namespace FootballSensei.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team> ,ITeamRepository
    {
        public TeamRepository(ProjectContext context) : base(context) { }
    }
}
