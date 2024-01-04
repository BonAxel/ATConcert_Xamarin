using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IConcertRepository _concertRepository;

        public BookingController(IBookingRepository bookingRepository, IMapper mapper, IConcertRepository concertRepository)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _concertRepository = concertRepository;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Booking>))]
        public IActionResult GetBookings()
        {
            var categories = _mapper.Map<List<Booking>>(_bookingRepository.GetBookings());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(categories);
        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBooking([FromBody] Booking bookingCreate)
        {
            if (bookingCreate == null) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookingRepository.CreateBooking(bookingCreate);

            //bookingMap.Concert = _concertRepository.GetConcert(showId);
            return Ok("Succesfully created");

        }
    }
}
