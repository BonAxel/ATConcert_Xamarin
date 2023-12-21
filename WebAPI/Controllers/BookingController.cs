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
        private readonly IShowRepository _showRepository;

        public BookingController(IBookingRepository bookingRepository, IMapper mapper, IShowRepository showRepository)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _showRepository = showRepository;
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
        public IActionResult CreateBooking([FromQuery] int showId, [FromBody] BookingDto bookingCreate)
        {
            if (bookingCreate == null) return BadRequest();

            var booking = _bookingRepository.GetBookings().Where(c => c.BookingId == bookingCreate.BookingId).FirstOrDefault();

            if (booking != null)
            {
                ModelState.AddModelError("", "Booking already exists");
                return StatusCode(422, ModelState);


            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookingMap = _mapper.Map<Booking>(bookingCreate);

            bookingMap.Show = _showRepository.GetShow(showId);


            if (!_bookingRepository.CreateBooking(showId, bookingMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfully created");

        }
    }
}
