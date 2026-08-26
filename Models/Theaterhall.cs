using System.Collections.Generic;

namespace The_Movie_Gruppe_12.Models
{
    public class TheaterHall
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Screening> Screenings { get; set; }
            = new List<Screening>();
    }
}