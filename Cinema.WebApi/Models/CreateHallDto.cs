using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateHall;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class CreateHallDto : IMapWith<CreateHallCommand>
    {
        public string Name { get; set; }
        public int SeatsNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHallDto, CreateHallCommand>()
                .ForMember(hallCommand => hallCommand.Name,
                opt => opt.MapFrom(hallDto => hallDto.Name))
                .ForMember(hallCommand => hallCommand.SeatsNumber,
                opt => opt.MapFrom(hallDto => hallDto.SeatsNumber));
        }
    }
}
