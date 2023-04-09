using AutoMapper;
using FootballSensei.Models;
using FootballSensei.Models.DTOs;

namespace FootballSensei.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            
            CreateMap<CreatePlayerDTO, Player>();
            CreateMap<Player, PlayerDTO>();
            CreateMap<CreateTeamDTO, Team>();
            CreateMap<Team, TeamDTO>();
            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerDTO, Player>();

        }
    }
}
