namespace FootballSensei.Models.DTOs
{
    public class TeamDTO
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public string Logo { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public ICollection<PlayerDTO> Players { get; set; }
    }
}
