using AutoMapper;
using Cinema.Application.Cinema.Commands.UpdateProfit;
using Cinema.Application.Common.Mappings;

namespace Cinema.WebApi.Models
{
    public class UpdateProfitDto : IMapWith<UpdateProfitCommand>
    {
        public Guid Id { get; set; }
        public Guid FilmId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProfitDto, UpdateProfitCommand>()
                .ForMember(filmCommand => filmCommand.FilmId,
                    opt => opt.MapFrom(filmDto => filmDto.FilmId))
                .ForMember(filmCommand => filmCommand.Id,
                    opt => opt.MapFrom(filmDto => filmDto.Id));
        }
    }
}
