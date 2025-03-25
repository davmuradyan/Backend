using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.StopServices;

namespace Backend.Controllers
{
    public class BusStopController : Controller {
        private IStopService stopService;

        public BusStopController(IStopService stopService) {
            this.stopService = stopService;
        }

        [HttpGet("AddStop")]
        public IActionResult AddStop(string name, double latitude, double longitude) {
            return Ok(stopService.CreateStop(name, latitude, longitude));
        }

        [HttpDelete("DeleteStop")]
        public IActionResult DeleteStop(int Stop_id) {
            return Ok(stopService.DeleteStop(Stop_id));
        }
    }
}