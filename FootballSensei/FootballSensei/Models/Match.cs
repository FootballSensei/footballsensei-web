using FootballSensei.Models.Base;

namespace FootballSensei.Models
{
    public class Match : BaseEntity
    {
        public string HomeTeamName { get; set; }
        public Guid HomeTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public Guid AwayTeamId { get; set; }

        public string Date { get; set; }
        public string Stadium { get; set; }
        public int? HomeGoals { get; set; }
        public int? AwayGoals { get; set; }
        public int Round { get; set; }
        public string RefereeName { get; set; }



    }
}
