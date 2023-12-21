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
            CreateMap<Concert, ConcertDto>();
            CreateMap<Genre, GenreDto>();
        }
    }
}
