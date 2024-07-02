using AutoMapper;
using Cinema.Application.Cinema.Queries.GetSeat;
using Cinema.Application.Common.Mappings;
using Cinema.Domain;

namespace Cinema.Application.Cinema.Queries.GetHall
{
    public class HallDetailsVm : IMapWith<Hall>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SeatsNumber { get; set; }

        public ICollection<SeatDetailsVm> Seats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hall, HallDetailsVm>()
                .ForMember(hallVm => hallVm.Name,
                    opt => opt.MapFrom(hall => hall.Name))
                .ForMember(hallVm => hallVm.Id,
                    opt => opt.MapFrom(hall => hall.Id))
                .ForMember(hallVm => hallVm.SeatsNumber,
                    opt => opt.MapFrom(hall => hall.SeatsNumber))
                .ForMember(hallVm => hallVm.Seats,
                    opt => opt.MapFrom(hall => hall.Seats));
        }
    }
}
