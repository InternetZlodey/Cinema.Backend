using AutoMapper;
using Cinema.Application.Cinema.Commands.UpdateHall;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class UpdateHallDto : IMapWith<UpdateHallCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SeatsNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateHallDto, UpdateHallCommand>()
                .ForMember(hallCommand => hallCommand.Id,
                    opt => opt.MapFrom(hallDto => hallDto.Id))
                .ForMember(hallCommand => hallCommand.Name,
                    opt => opt.MapFrom(hallDto => hallDto.Name))
                .ForMember(hallCommand => hallCommand.SeatsNumber,
                    opt => opt.MapFrom(hallDto => hallDto.SeatsNumber));
        }
    }
}
