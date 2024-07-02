using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateProfit;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class CreateProfitDto : IMapWith<CreateProfitCommand>
    {
        public Guid FilmId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProfitDto, CreateProfitCommand>()
                .ForMember(filmCommand => filmCommand.FilmId,
                    opt => opt.MapFrom(filmDto => filmDto.FilmId));
        }
    }
}
