namespace The_Movie_Gruppe_12.Models
{
    public class Reservation
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public int NumberOfTickets { get; set; }

        public Screening Screening { get; set; }
    }
}