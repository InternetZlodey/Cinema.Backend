using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateSeat;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class CreateSeatDto : IMapWith<CreateSeatCommand>
    {
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Guid HallID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSeatDto, CreateSeatCommand>()
                .ForMember(seatCommand => seatCommand.Row,
                    opt => opt.MapFrom(seatDto => seatDto.Row))
                .ForMember(seatCommand => seatCommand.SeatNumber,
                    opt => opt.MapFrom(seatDto => seatDto.SeatNumber))
                .ForMember(seatCommand => seatCommand.HallID,
                    opt => opt.MapFrom(seatDto => seatDto.HallID));
        }

    }
}
