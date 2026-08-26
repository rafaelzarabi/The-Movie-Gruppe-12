using System.Collections.Generic;

namespace The_Movie_Gruppe_12.Models
{
    public class Cinema
    {
        public string Name { get; set; }
        public string City { get; set; }

        public List<TheaterHall> TheaterHalls { get; set; }
            = new List<TheaterHall>();
    }
}