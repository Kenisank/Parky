using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyApi.Models;
using ParkyApi.Models.DTOs;
using ParkyApi.Repositories.Interfaces;
using System.Collections.Generic;

namespace ParkyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParkyController : Controller
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;

        public NationalParkyController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper; 
        }

        [HttpGet]
       // [Route("all")]
        public IActionResult GetNationalParks()
        {
            var nationalParks = _npRepo.GetAll();
            var nationalParkDto = _mapper.Map<List<NationalParkDto>>(nationalParks);
            return Ok(nationalParkDto);
        }


        [HttpGet("{id:int}", Name = "GetNationalPark")]
      //  [Route("{id:int}")]
        public IActionResult GetNationalPark(int id)
        {
            var park = _npRepo.Get(id);

            if(park== null) return NotFound();

            var parkDto = _mapper.Map<NationalParkDto>(park);

            return Ok(parkDto);
        }


        [HttpPost]
        public IActionResult NewNationalPark([FromBody]NationalParkDto nationalParkDto)
        {
            if(nationalParkDto == null) return BadRequest(ModelState);

            if (_npRepo.Exists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nationalpark = _mapper.Map<NationalParks>(nationalParkDto);

            if (!_npRepo.Create(nationalpark))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {nationalpark.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNationalPark", new {id=nationalpark.Id}, nationalpark);  


        }


        [HttpPatch("{id:int}", Name = "UpdateNationalPark")]
        public IActionResult UpdateNationalPark(int id, [FromBody]NationalParkDto nationalParkDto)
        {

            if(nationalParkDto==null || id!=nationalParkDto.Id) return BadRequest(ModelState);

            var nationalpark = _mapper.Map<NationalParks>(nationalParkDto);

            if (!_npRepo.Update(nationalpark))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {nationalpark.Name}");
                return StatusCode(500, ModelState);
            } 

            return NoContent();

        }


        [HttpDelete("{id:int}", Name = "Delete NationalPark")]
        public IActionResult DeleteNationalPark(int id)
        {

            if (!_npRepo.Exists(id)) return NotFound() ;


            var nationalpark = _npRepo.Get(id);

            if (!_npRepo.Delete(id))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {nationalpark.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }


    }
}
