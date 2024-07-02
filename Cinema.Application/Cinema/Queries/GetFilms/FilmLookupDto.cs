using AutoMapper;
using Cinema.Application.Common.Mappings;
using Cinema.Domain;

namespace Cinema.Application.Cinema.Queries.GetFilms
{
    public class FilmLookupDto : IMapWith<Film>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearPublished { set; get; }
        public string Genres { get; set; }
        public string Duration { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmLookupDto>()
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
                .ForMember(filmVm => filmVm.Id,
                    opt => opt.MapFrom(film => film.Id));
        }
    }
}
