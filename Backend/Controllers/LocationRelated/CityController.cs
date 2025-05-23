using Backend.Core.Services.LocationRelated.CityServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.LocationRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService) {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityEntity>>> GetAll() {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityEntity>> GetById(int id) {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<CityEntity>> Create([FromBody] CreateCityDto dto) {
            var created = await _cityService.CreateCityAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.CityID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCityDto dto) {
            var success = await _cityService.UpdateCityAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _cityService.DeleteCityAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}