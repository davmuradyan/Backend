using Backend.Core.Services.LocationRelated.CountryServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.LocationRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService) {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryEntity>>> GetAll() {
            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryEntity>> GetById(int id) {
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<CountryEntity>> Create([FromBody] CreateCountryDto dto) {
            var created = await _countryService.CreateCountryAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.CountryID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryDto dto) {
            var success = await _countryService.UpdateCountryAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _countryService.DeleteCountryAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}