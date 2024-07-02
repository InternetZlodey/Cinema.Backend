using AutoMapper;
using Cinema.Application.Common.Mappings;
using Cinema.Domain;

namespace Cinema.Application.Cinema.Queries.GetSeat
{
    public class SeatDetailsVm : IMapWith<Seat>
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Guid HallID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seat, SeatDetailsVm>()
                .ForMember(seatVm => seatVm.Row,
                    opt => opt.MapFrom(seat => seat.Row))

                .ForMember(seatVm => seatVm.Id,
                    opt => opt.MapFrom(seat => seat.Id))

                .ForMember(seatVm => seatVm.SeatNumber,
                    opt => opt.MapFrom(seat => seat.SeatNumber))

                .ForMember(seatVm => seatVm.HallID,
                    opt => opt.MapFrom(seat => seat.HallID));
        }
    }
}
