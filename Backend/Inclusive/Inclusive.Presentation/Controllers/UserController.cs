using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.UserDtos;
using System.Security.Claims;

namespace Inclusive.Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}", Name = "GetUserById")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var user = await _service.UserService.GetUserByIdAsync(id);
            return Ok(user);
        }


        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _service.UserService.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [HttpPut("{id:guid}", Name = "UpdateUser")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateDto user)
        {
            // *** como puedo poner este error JP
            var logUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var result = await _service.UserService.UpdateUserAsync(id, logUserId, user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut("updatePassword/{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePassword(Guid id, [FromBody] UserForUpdatePasswordDto model)
        {
            var logUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var result = await _service.UserService.UpdateUserPasswordAsync(id, logUserId, model);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
