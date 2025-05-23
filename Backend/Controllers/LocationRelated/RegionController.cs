using Backend.Core.Services.LocationRelated.RegionServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.LocationRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService) {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionEntity>>> GetAll() {
            var regions = await _regionService.GetAllRegionsAsync();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegionEntity>> GetById(int id) {
            var region = await _regionService.GetRegionByIdAsync(id);
            if (region == null)
                return NotFound();
            return Ok(region);
        }

        [HttpPost]
        public async Task<ActionResult<RegionEntity>> Create([FromBody] CreateRegionDto dto) {
            var created = await _regionService.CreateRegionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RegionID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRegionDto dto) {
            var success = await _regionService.UpdateRegionAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _regionService.DeleteRegionAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}