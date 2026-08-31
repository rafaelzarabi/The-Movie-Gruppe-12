using System.Collections.Generic;

namespace The_Movie_Gruppe_12.Models
{
    public class AppData
    {
        public List<Movie> Movies { get; set; }
            = new List<Movie>();

        public List<Cinema> Cinemas { get; set; }
            = new List<Cinema>();

        public List<Screening> Screenings { get; set; }
            = new List<Screening>();

        public List<Reservation> Reservations { get; set; }
            = new List<Reservation>();
    }
}