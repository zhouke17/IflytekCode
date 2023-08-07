using AutoMapper;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Age, config =>
                    config.MapFrom(src => DateTime.Now.Year - src.BirthDate.Year));
            CreateMap<AuthorDto, Author>().ForMember(dest => dest.BirthDate,config =>config.MapFrom(src => (DateTime.Now.AddYears(-src.Age)).ToString("yyyy-MM-dd")));
            CreateMap<Book, BookDto>();
        }
    }
}
