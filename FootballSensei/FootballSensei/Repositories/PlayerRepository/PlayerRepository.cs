using FootballSensei.Models;
using ProiectASPNET.Data;
using ProiectASPNET.Repositories.GenericRepository;

namespace FootballSensei.Repositories.PlayerRepository
{
    public class PlayerRepository : GenericRepository<Player> ,IPlayerRepository
    {
        public PlayerRepository(ProjectContext context) : base(context){}



    }
}
