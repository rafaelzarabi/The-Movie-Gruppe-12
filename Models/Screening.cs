using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Movie_Gruppe_12.Models
{
    public class Screening
    {
        public DateTime StartTime { get; set; }

        public Movie Movie { get; set; }

        public TheaterHall TheaterHall { get; set; }

        public List<Reservation> Reservations { get; set; }
            = new List<Reservation>();


        public DateTime CalculateEndTime()
        {
            int advertisementTime = 15;
            int cleaningTime = 15;

            return StartTime.AddMinutes(
                Movie.Duration + advertisementTime + cleaningTime);
        }
        // Vi bruger dette for at vise sluttidspunktet i selve UI'et
        public DateTime EndTime => CalculateEndTime();


        public int FreeSeats()
        {
            int reservedSeats = Reservations.Sum(
                reservation => reservation.NumberOfTickets);

            return TheaterHall.Capacity - reservedSeats;
        }


        public bool CanReserve(int numberOfTickets)
        {
            return numberOfTickets > 0
                && numberOfTickets <= FreeSeats();
        }
    }
}