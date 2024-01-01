using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Dto;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{


    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class ConcertController : Controller
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IMapper _mapper;

        public ConcertController(IConcertRepository concertRepository, IMapper mapper)
        {
                _concertRepository = concertRepository;
                _mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Concert>))]
        public IActionResult GetConcerts()
        {
            var concert = _mapper.Map<List<ConcertDto>>(_concertRepository.GetConcerts());
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(concert);
        }


        [HttpGet("{concertId}")]
        [ProducesResponseType(200, Type = typeof(Concert))]
        [ProducesResponseType(400)]
        public IActionResult GetConcert(int concertId)
        {
            if (!_concertRepository.ConcertExists(concertId)) return NotFound();

            var concert = _mapper.Map<Concert>(_concertRepository.GetConcert(concertId));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(concert);
        }


    }
}
