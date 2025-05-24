using Backend.Core.Services.RouteRelated.TripServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.RouteRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService) {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripEntity>>> GetAll() {
            var gps = await _tripService.GetAllTripsAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TripEntity>> GetById(int id) {
            var gps = await _tripService.GetTripByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<TripEntity>> Create([FromBody] CreateTripDto dto) {
            var created = await _tripService.CreateTripAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TripID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTripDto dto) {
            var success = await _tripService.UpdateTripAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _tripService.DeleteTripAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}