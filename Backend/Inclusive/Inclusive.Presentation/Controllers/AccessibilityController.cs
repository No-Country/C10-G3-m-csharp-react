using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.AccessibilityDtos;
using Shared.Helper;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

[Route("api/accessibility")]
[ApiController]

public class AccessibilityController : ControllerBase
{
    private readonly IServiceManager _service;
  
    public AccessibilityController(IServiceManager service)
    {
        _service = service;
    }

    [Authorize(Roles = UserRoles.AdministratorOrUser)]
    [HttpGet(Name = "GetAccessibilitys")]
    public async Task<IActionResult> GetAccessibilitys([FromQuery] AccessibilityParameters parameters)
    {
        var accessibilitys = await _service.AccessibilityService.GetAccessibilitysAsync(parameters, false);

        return Ok(accessibilitys);
    }

    [Authorize(Roles = UserRoles.Administrator)]
    [HttpGet("{id:guid}", Name = "GetAccessibilityById")]
    public async Task<IActionResult> GetAccessibilityById(Guid id)
    {
        var accessibility = await _service.AccessibilityService.GetAccessibilityByIdAsync(id, false);
        return Ok(accessibility);
    }

    //[AllowAnonymous]
    [Authorize(Roles = UserRoles.Administrator)]
    [HttpPost(Name = "CreateAccessibility")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAccessibility([FromBody] AccessibilityForCreationDto accessibility)
    {
        var createdAccessibility = await _service.AccessibilityService.CreateAccessibilityAsync(accessibility);

        return CreatedAtRoute("GetAccessibilityById", new { id = createdAccessibility.Id }, createdAccessibility);
    }

    [Authorize(Roles = UserRoles.Administrator)]
    [HttpDelete("{id:guid}", Name = "DeleteAccessibility")]
    public async Task<IActionResult> DeleteAccessibility(Guid id)
    {
        await _service.AccessibilityService.DeleteAccessibilityAsync(id, false);
        return NoContent();
    }

    [Authorize(Roles = UserRoles.Administrator)]
    [HttpPut("{id:guid}", Name = "UpdateAccessibility")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateAccessibility(Guid id, [FromBody] AccessibilityForUpdateDto accessibility)
    {
        await _service.AccessibilityService.UpdateAccessibilityAsync(id, accessibility, true);

        return NoContent();
    }
}