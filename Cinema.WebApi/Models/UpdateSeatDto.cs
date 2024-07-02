using AutoMapper;
using Cinema.Application.Cinema.Commands.UpdateSeat;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class UpdateSeatDto : IMapWith<UpdateSeatCommand>
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Guid HallId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSeatDto, UpdateSeatCommand>()
                .ForMember(seatCommand => seatCommand.Row,
                    opt => opt.MapFrom(seatDto => seatDto.Row))
                .ForMember(seatCommand => seatCommand.SeatNumber,
                    opt => opt.MapFrom(seatDto => seatDto.SeatNumber))
                .ForMember(seatCommand => seatCommand.HallID,
                    opt => opt.MapFrom(seatDto => seatDto.HallId))
                .ForMember(seatCommand => seatCommand.Id,
                    opt => opt.MapFrom(seatDto => seatDto.Id));
        }
    }
}
