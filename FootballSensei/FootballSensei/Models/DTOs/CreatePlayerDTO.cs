﻿namespace FootballSensei.Models.DTOs
{
    public class CreatePlayerDTO
    {
        public string Name { get; set; }
        public int GoalNumber { get; set; }
        public int AssistNumber { get; set; }
        public int YellowCardNumber { get; set; }
        public int RedCardNumber { get; set; }
        public int MatchNumber { get; set; }
        public int MinutesPlayed { get; set; }
        public int Rating { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public Guid? TeamId { get; set; }
    }
}
