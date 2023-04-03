﻿using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.User;

namespace Inclusive.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost("register")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto
        userForRegistration)
    {
        var result = await
            _service.AuthenticationService.RegisterUser(userForRegistration);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto
        user)
    {
        // *** preguntar JP si no no se sabe q esta mal ingresado
        // "Authentication failed. Wrong username or password."
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized("Authentication failed. Wrong username or password.");
        return Ok(new
        {
            Token = await _service.AuthenticationService.CreateToken()
        });
    }
}