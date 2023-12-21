using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{



    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Show>))]
        public IActionResult GetGenre()
        {
            var genre = _mapper.Map<List<GenreDto>>(_genreRepository.GetGenres());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(genre);
        }


        [HttpGet("{genreId}")]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400)]
        public IActionResult GetGenre(int genreId)
        {
            if (!_genreRepository.GenreExists(genreId)) return NotFound();

            var genre = _mapper.Map<Show>(_genreRepository.GetGenre(genreId));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(genre);
        }
    }
}
