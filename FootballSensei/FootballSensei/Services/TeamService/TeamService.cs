using AutoMapper;
using FootballSensei.Repositories.TeamRepository;

namespace FootballSensei.Services.TeamService
{
    public class TeamService : ITeamService
    {
        public readonly ITeamRepository _teamRepository;
        public readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

    }
}
