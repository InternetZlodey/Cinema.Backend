using AutoMapper;
using Cinema.Application.Cinema.Commands.UpdateTicket;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class UpdateTicketDto : IMapWith<UpdateTicketCommand>
    {
        public Guid Id { get; set; }
        public int TicketPrice { get; set; }

        public DateTime SessionDate { get; set; }

        //Много на много с Films
        public Guid FilmId { get; set; }

        //Один к одному с Seats
        public Guid SeatId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTicketDto, UpdateTicketCommand>()
                .ForMember(ticketVm => ticketVm.TicketPrice,
                    opt => opt.MapFrom(ticket => ticket.TicketPrice))
                .ForMember(ticketVm => ticketVm.SessionDate,
                    opt => opt.MapFrom(ticket => ticket.SessionDate))
                .ForMember(ticketVm => ticketVm.FilmId,
                    opt => opt.MapFrom(ticket => ticket.FilmId))
                .ForMember(ticketVm => ticketVm.SeatId,
                    opt => opt.MapFrom(ticket => ticket.SeatId))
                .ForMember(ticketVm => ticketVm.Id,
                    opt => opt.MapFrom(ticket => ticket.Id));
        }
    }
}
