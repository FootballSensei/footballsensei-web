using AutoMapper;
using FootballSensei.Models;
using FootballSensei.Models.DTOs;
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

        public async Task<List<TeamDTO>> CreateTeam(CreateTeamDTO teamDTO)
        {
            var team = _mapper.Map<Team>(teamDTO);
            await _teamRepository.CreateAsync(team);
            await _teamRepository.SaveAsync();
            var teams = await _teamRepository.GetAllAsync();
            var teamsDTO = _mapper.Map<List<TeamDTO>>(teams);
            return teamsDTO;
        }

        public async Task<List<TeamDTO>> GetAllTeams()
        {
            
            var teams = await _teamRepository.GetAllAsync();
            var teamDTOs = _mapper.Map<List<TeamDTO>>(teams);
            return teamDTOs;
            
        }

    }
}
