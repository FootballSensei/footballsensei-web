using FootballSensei.Models.DTOs;

namespace FootballSensei.Services.TeamService
{
    public interface ITeamService
    {
        public Task<List<TeamDTO>> CreateTeam(CreateTeamDTO teamDTO);
        public Task<List<TeamDTO>> GetAllTeams();
    }
}
