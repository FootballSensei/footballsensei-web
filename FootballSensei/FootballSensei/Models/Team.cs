using FootballSensei.Models.Base;

namespace FootballSensei.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public string Logo { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
