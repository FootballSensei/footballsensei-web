
using FootballSensei.Repositories.LineupDatumRepository;
using FootballSensei.Repositories.MatchRepository;
using FootballSensei.Repositories.PlayerRepository;
using FootballSensei.Repositories.TeamRepository;
using FootballSensei.Repositories.MatchDatumRepository;
using FootballSensei.Services.LineupDatumService;
using FootballSensei.Services.MatchService;
using FootballSensei.Services.PlayerService;
using FootballSensei.Services.TeamService;
using FootballSensei.Services.MatchDatumService;

namespace FootballSensei.Helperss.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<ILineupDatumRepository, LineupDatumRepository>();
            services.AddTransient<IMatchDatumRepository, MatchDatumRepository>();
         


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
           
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ILineupDatumService, LineupDatumService>();
            services.AddTransient<IMatchDatumService, MatchDatumService>();


            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
