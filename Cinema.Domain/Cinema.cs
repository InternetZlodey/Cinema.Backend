using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Domain
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearPublished { set; get; }
        public string Genres { get; set; }
        public string Duration { get; set; }

        //Reference
        public ICollection<Ticket> Tickets { get; set; }
    }

    public class Hall
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SeatsNumber { get; set; }

        // Референс на места
        [Required]
        public ICollection<Seat> Seats { get; set; }
    }

    public class Seat
    {
        [Key]
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        //Один на много (Один зал - много мест)
        [ForeignKey("Hall")]
        public Guid HallID { get; set; }
        public Hall Hall { get; set; }

        public Ticket Ticket { get; set; }
    }

    public class Ticket
    {
        public Guid Id { get; set; }
        public int TicketPrice { get; set; }

        public DateTime SessionDate { get; set; }

        //Много на много с Films
        public Guid FilmId { get; set; }
        public Film Film { get; set; }

        //Один к одному с Seats
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
    }

    public class Profit
    {
        [Key]
        public Guid Id { get; set; }

        public long Earnings { get; set; }

        [ForeignKey("Film")]
        public Guid FilmId { get; set; }
        public Film Film { get; set; }
    }
}
