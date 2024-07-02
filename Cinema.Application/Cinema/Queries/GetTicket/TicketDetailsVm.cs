using AutoMapper;
using Cinema.Application.Common.Mappings;
using Cinema.Domain;

namespace Cinema.Application.Cinema.Queries.GetTicket
{
    public class TicketDetailsVm : IMapWith<Ticket>
    {
        public Guid Id { get; set; }
        public int TicketPrice { get; set; }
        public DateTime SessionDate { get; set; }
        public FilmDto Film { get; set; }
        public SeatDto Seat { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ticket, TicketDetailsVm>()
            .ForMember(ticketVm => ticketVm.Id,
                opt => opt.MapFrom(ticket => ticket.Id))
            .ForMember(ticketVm => ticketVm.TicketPrice,
                opt => opt.MapFrom(ticket => ticket.TicketPrice))
            .ForMember(ticketVm => ticketVm.SessionDate,
                opt => opt.MapFrom(ticket => ticket.SessionDate))
            .ForMember(ticketVm => ticketVm.Film,
                opt => opt.MapFrom(ticket => ticket.Film))
            .ForMember(ticketVm => ticketVm.Seat,
                opt => opt.MapFrom(ticket => ticket.Seat));
        }
    }

    public class FilmDto : IMapWith<Film>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearPublished { get; set; }
        public string Genres { get; set; }
        public string Duration { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmDto>()
            .ForMember(filmVm => filmVm.Id,
                opt => opt.MapFrom(film => film.Id))
            .ForMember(filmVm => filmVm.Genres,
                opt => opt.MapFrom(film => film.Genres))
            .ForMember(filmVm => filmVm.YearPublished,
                opt => opt.MapFrom(film => film.YearPublished))
            .ForMember(filmVm => filmVm.Country,
                opt => opt.MapFrom(film => film.Country))
            .ForMember(filmVm => filmVm.Name,
                opt => opt.MapFrom(film => film.Name))
            .ForMember(filmVm => filmVm.Duration,
                opt => opt.MapFrom(film => film.Duration));
        }
    }

    public class SeatDto : IMapWith<Seat>
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public HallDto Hall { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seat, SeatDto>()
            .ForMember(seatVm => seatVm.Id,
                opt => opt.MapFrom(seat => seat.Id))
            .ForMember(seatVm => seatVm.Row,
                opt => opt.MapFrom(seat => seat.Row))
            .ForMember(seatVm => seatVm.SeatNumber,
                opt => opt.MapFrom(seat => seat.SeatNumber))
            .ForMember(seatVm => seatVm.Hall,
                opt => opt.MapFrom(seat => seat.Hall));
        }
    }

    public class HallDto : IMapWith<Hall>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SeatsNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hall, HallDto>()
            .ForMember(hallVm => hallVm.Id,
                opt => opt.MapFrom(hall => hall.Id))
            .ForMember(hallVm => hallVm.Name,
                opt => opt.MapFrom(hall => hall.Name))
            .ForMember(hallVm => hallVm.SeatsNumber,
                opt => opt.MapFrom(hall => hall.SeatsNumber));
        }
    }

}
