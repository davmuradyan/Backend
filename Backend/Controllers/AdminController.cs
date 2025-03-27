using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.AdminServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Data.Entities;

namespace Backend.Controllers {
    [ApiController]
    [Route("api/admins")]
    public class AdminController : ControllerBase {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService) {
            this.adminService = adminService;
        }

        /// <summary>
        /// Creates a new Admin.
        /// </summary>
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromBody] CreateAdminRequest request) {
            var admin = await adminService.CreateAdminAsync(request.Name, request.Surname, request.Email, request.City, request.Username, request.Password);
            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Admin_id }, admin);
        }

        /// <summary>
        /// Retrieves an Admin by ID.
        /// </summary>
        [HttpGet("GetAdmin/{id}")]
        public async Task<IActionResult> GetAdmin(int id) {
            var admin = await adminService.GetAdminAsync(id);
            return admin != null ? Ok(admin) : NotFound();
        }

        /// <summary>
        /// Retrieves all Admins.
        /// </summary>
        [HttpGet("GetAdmins")]
        public async Task<IActionResult> GetAdmins() {
            var admins = await adminService.GetAdminsAsync();
            return Ok(admins);
        }

        /// <summary>
        /// Updates an existing Admin.
        /// </summary>
        [HttpPut("UpdateAdmin/{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] UpdateAdminRequest request) {
            var updatedAdmin = await adminService.UpdateAdminAsync(id, request.Name, request.Surname, request.Email, request.City, request.Username, request.Password);
            return updatedAdmin != null ? Ok(updatedAdmin) : NotFound();
        }

        /// <summary>
        /// Deletes an Admin.
        /// </summary>
        [HttpDelete("DeleteAdmin/{id}")]
        public async Task<IActionResult> DeleteAdmin(int id) {
            var result = await adminService.DeleteAdminAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

    /// <summary>
    /// DTO for creating an Admin.
    /// </summary>
    public class CreateAdminRequest {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// DTO for updating an Admin.
    /// </summary>
    public class UpdateAdminRequest {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}