using AutoMapper;
using Cinema.Application.Common.Mappings;
using Cinema.Domain;

namespace Cinema.Application.Cinema.Queries.GetFilms
{
    public class FilmListVm
    {
        public List<FilmLookupDto> Films { get; set; }
    }
}
