using AutoMapper;
using Cinema.Application.Common.Mappings;
using Cinema.Domain;

namespace Cinema.Application.Cinema.Queries.GetProfits
{
    public class ProfitDetailsVm : IMapWith<Profit>
    {
        public Guid Id { get; set; }

        public long Earnings { get; set; }

        public Guid FilmId { get; set; }
        public FilmDto Film { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Profit, ProfitDetailsVm>()
                .ForMember(profitVm => profitVm.Id,
                    opt => opt.MapFrom(profit => profit.Id))
                .ForMember(profitVm => profitVm.Earnings,
                    opt => opt.MapFrom(profit => profit.Earnings))
                .ForMember(profitVm => profitVm.FilmId,
                    opt => opt.MapFrom(profit => profit.FilmId))
                .ForMember(profitVm => profitVm.Film,
                    opt => opt.MapFrom(profit => profit.Film));
        }
    }

    public class FilmDto : IMapWith<Film>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearPublished { set; get; }
        public string Genres { get; set; }
        public string Duration { get; set; }

        //Reference
        public ICollection<TicketDto> Tickets { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmDto>()
                .ForMember(filmVm => filmVm.Id,
                    opt => opt.MapFrom(film => film.Id))
                .ForMember(filmVm => filmVm.Name,
                    opt => opt.MapFrom(film => film.Name))
                .ForMember(filmVm => filmVm.Country,
                    opt => opt.MapFrom(film => film.Country))
                .ForMember(filmVm => filmVm.YearPublished,
                    opt => opt.MapFrom(film => film.YearPublished))
                .ForMember(filmVm => filmVm.Genres,
                    opt => opt.MapFrom(film => film.Genres))
                .ForMember(filmVm => filmVm.Duration,
                    opt => opt.MapFrom(film => film.Duration))
                .ForMember(filmVm => filmVm.Tickets,
                    opt => opt.MapFrom(film => film.Tickets));
        }
    }

    public class TicketDto : IMapWith<Ticket>
    {
        public Guid Id { get; set; }
        public int TicketPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ticket, TicketDto>()
                .ForMember(ticketVm => ticketVm.Id,
                    opt => opt.MapFrom(ticket => ticket.Id))
                .ForMember(ticketVm => ticketVm.TicketPrice,
                    opt => opt.MapFrom(ticket => ticket.TicketPrice));
        }
    }
}
