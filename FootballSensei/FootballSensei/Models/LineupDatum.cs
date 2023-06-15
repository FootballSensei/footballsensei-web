using System;
using System.Collections.Generic;

namespace FootballSensei.Models;

public partial class LineupDatum
{
    public DateTime? Date { get; set; }

    public string? HomeTeam { get; set; }

    public string? AwayTeam { get; set; }

    public string? HomeLineup { get; set; }

    public string? AwayLineup { get; set; }

    public float? HomeSentiment { get; set; }

    public float? AwaySentiment { get; set; }

    public float? HomePositiveScore { get; set; }

    public float? HomeNegativeScore { get; set; }

    public float? AwayPositiveScore { get; set; }

    public float? AwayNegativeScore { get; set; }
}
