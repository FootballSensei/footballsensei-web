﻿using FootballSensei.Models;
using FootballSensei.Repositories.GenericRepository;

namespace FootballSensei.Repositories.MatchRepository
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        public Task<Match> GetMatchById(Guid id);
    }

    

}
