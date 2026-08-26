using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movie_Gruppe_12.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Duration {get; set;  }
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime PremiereDate { get; set; }

    }
}
