using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FootballSensei.Models;

public partial class FootballsenseiContext : DbContext
{
    public FootballsenseiContext()
    {
    }

    public FootballsenseiContext(DbContextOptions<FootballsenseiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LineupDatum> LineupData { get; set; }

    public virtual DbSet<MatchDatum> MatchData { get; set; }

    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<Match> Matches { get; set; }
    public virtual DbSet<Player> Players { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:footballsensei-server.database.windows.net; Database=footballsensei; User Id=dbadmin; Password=Dinamo1948!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LineupDatum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AwayLineup)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AwayNegativeScore).HasColumnName("away_negative_score");
            entity.Property(e => e.AwayPositiveScore).HasColumnName("away_positive_score");
            entity.Property(e => e.AwaySentiment).HasColumnName("away_sentiment");
            entity.Property(e => e.AwayTeam)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.HomeLineup)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HomeNegativeScore).HasColumnName("home_negative_score");
            entity.Property(e => e.HomePositiveScore).HasColumnName("home_positive_score");
            entity.Property(e => e.HomeSentiment).HasColumnName("home_sentiment");
            entity.Property(e => e.HomeTeam)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MatchDatum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Am1D).HasColumnName("AM1_D");
            entity.Property(e => e.Am1L).HasColumnName("AM1_L");
            entity.Property(e => e.Am1M).HasColumnName("AM1_M");
            entity.Property(e => e.Am1W).HasColumnName("AM1_W");
            entity.Property(e => e.Am2D).HasColumnName("AM2_D");
            entity.Property(e => e.Am2L).HasColumnName("AM2_L");
            entity.Property(e => e.Am2M).HasColumnName("AM2_M");
            entity.Property(e => e.Am2W).HasColumnName("AM2_W");
            entity.Property(e => e.Am3D).HasColumnName("AM3_D");
            entity.Property(e => e.Am3L).HasColumnName("AM3_L");
            entity.Property(e => e.Am3M).HasColumnName("AM3_M");
            entity.Property(e => e.Am3W).HasColumnName("AM3_W");
            entity.Property(e => e.Atgd).HasColumnName("ATGD");
            entity.Property(e => e.Atp).HasColumnName("ATP");
            entity.Property(e => e.AwayTeamName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ftr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("FTR");
            entity.Property(e => e.Hm1D).HasColumnName("HM1_D");
            entity.Property(e => e.Hm1L).HasColumnName("HM1_L");
            entity.Property(e => e.Hm1M).HasColumnName("HM1_M");
            entity.Property(e => e.Hm1W).HasColumnName("HM1_W");
            entity.Property(e => e.Hm2D).HasColumnName("HM2_D");
            entity.Property(e => e.Hm2L).HasColumnName("HM2_L");
            entity.Property(e => e.Hm2M).HasColumnName("HM2_M");
            entity.Property(e => e.Hm2W).HasColumnName("HM2_W");
            entity.Property(e => e.Hm3D).HasColumnName("HM3_D");
            entity.Property(e => e.Hm3L).HasColumnName("HM3_L");
            entity.Property(e => e.Hm3M).HasColumnName("HM3_M");
            entity.Property(e => e.Hm3W).HasColumnName("HM3_W");
            entity.Property(e => e.HomeTeamName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Htgd).HasColumnName("HTGD");
            entity.Property(e => e.Htp).HasColumnName("HTP");
            entity.Property(e => e.Matchdate)
                .HasColumnType("date")
                .HasColumnName("MATCHDATE");
        });

      /*
        //one team has many players
        modelBuilder.Entity<Team>()
            .HasMany(t => t.Players)
            .WithOne(p => p.Team)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
      */

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
