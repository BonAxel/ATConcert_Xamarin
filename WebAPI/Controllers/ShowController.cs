using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{


    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ShowController : Controller
    {
        private readonly IShowRepository _showRepository;
        private readonly IMapper _mapper;

        public ShowController(IShowRepository Showrepository, IMapper mapper)
        {
            _showRepository = Showrepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Show>))]
        public IActionResult GetPokemons()
        {
            var show = _mapper.Map<List<ShowDto>>(_showRepository.GetShows());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(show);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Show))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_showRepository.ShowExists(pokeId)) return NotFound();

            var pokemon = _mapper.Map<Show>(_showRepository.GetShow(pokeId));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemon);
        }
    }
}
