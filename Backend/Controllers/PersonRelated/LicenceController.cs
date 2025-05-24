using Backend.Core.Services.PersonRelated.DriverServices.Licence;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.PersonRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class LicenceController : ControllerBase {
        private readonly ILicenceService _licenceService;

        public LicenceController(ILicenceService licenceService) {
            _licenceService = licenceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceEntity>>> GetAll() {
            var gps = await _licenceService.GetAllLicencesAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceEntity>> GetById(int id) {
            var gps = await _licenceService.GetLicenceByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<LicenceEntity>> Create([FromBody] CreateLicenceDto dto) {
            var created = await _licenceService.CreateLicenceAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.LicenceID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLicenceDto dto) {
            var success = await _licenceService.UpdateLicenceAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _licenceService.DeleteLicenceAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}