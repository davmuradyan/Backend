using Backend.Core.Services.PersonRelated.UserFeedbackServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.PersonRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class UserFeedbackController : ControllerBase {
        private readonly IUserFeedbackService _userFeedbackService;

        public UserFeedbackController(IUserFeedbackService userFeedbackService) {
            _userFeedbackService = userFeedbackService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFeedbackEntity>>> GetAll() {
            var gps = await _userFeedbackService.GetAllFeedbacksAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserFeedbackEntity>> GetById(int id) {
            var gps = await _userFeedbackService.GetFeedbackByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<UserFeedbackEntity>> Create([FromBody] CreateUserFeedbackDto dto) {
            var created = await _userFeedbackService.CreateFeedbackAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.UserFeedbackID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserFeedbackDto dto) {
            var success = await _userFeedbackService.UpdateFeedbackAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _userFeedbackService.DeleteFeedbackAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}