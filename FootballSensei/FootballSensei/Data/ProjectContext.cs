using FootballSensei.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProiectASPNET.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public object Players { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            





            base.OnModelCreating(modelBuilder);
        }

    }
}
