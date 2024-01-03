using AutoMapper;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Show, ShowDto>();
            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>();
            
            CreateMap<Concert, ConcertDto>();
            CreateMap<ConcertDto, Concert>();

            CreateMap<ConcertDto, Genre>();
            CreateMap<Genre, GenreDto>();

            //CreateMap<Concert, Show>();


            CreateMap<Genre, GenreDto>();


        }
    }
}
