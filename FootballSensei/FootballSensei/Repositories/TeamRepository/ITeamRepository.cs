using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;

namespace FootballSensei.Repositories.TeamRepository
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        public Task<List<Team>> GetAllWithTeamsAsync();
    }
}
