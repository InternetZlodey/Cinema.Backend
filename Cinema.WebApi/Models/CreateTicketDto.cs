using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateTicket;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class CreateTicketDto : IMapWith<CreateTicketCommand>
    {
        public int TicketPrice { get; set; }

        public DateTime SessionDate { get; set; }

        //Много на много с Films
        public Guid FilmId { get; set; }

        //Один к одному с Seats
        public Guid SeatId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTicketDto, CreateTicketCommand>()
                .ForMember(ticketVm => ticketVm.TicketPrice,
                    opt => opt.MapFrom(ticket => ticket.TicketPrice))
                .ForMember(ticketVm => ticketVm.SessionDate,
                    opt => opt.MapFrom(ticket => ticket.SessionDate))
                .ForMember(ticketVm => ticketVm.FilmId,
                    opt => opt.MapFrom(ticket => ticket.FilmId))
                .ForMember(ticketVm => ticketVm.SeatId,
                    opt => opt.MapFrom(ticket => ticket.SeatId));
        }
    }
}
