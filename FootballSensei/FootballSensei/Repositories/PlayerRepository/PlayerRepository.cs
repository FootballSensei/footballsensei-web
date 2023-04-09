using FootballSensei.Models;
using FootballSensei.Data;
using FootballSensei.Repositories.GenericRepository;

namespace FootballSensei.Repositories.PlayerRepository
{
    public class PlayerRepository : GenericRepository<Player> ,IPlayerRepository
    {
        public PlayerRepository(ProjectContext context) : base(context){}



    }
}
