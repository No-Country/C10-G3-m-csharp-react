using System.Text.Json;
using Entities.Models;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.OwnerDtos;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

[Route("api/owner")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly IServiceManager _services;

    public OwnerController(IServiceManager services)
    {
        _services = services;
    }


    [HttpGet(Name = "GetOwners")]
    public async Task<IActionResult> GetOwners([FromQuery] OwnerParameters ownerParameters)
    {
        var pagedResult = await _services.OwnerService.GetOwnersAsync(ownerParameters,
            false);
        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.ownerDtos);
    }


    [HttpGet("{id:guid}",
        Name = "GetOwnerById")]
    public async Task<IActionResult> GetOwnerById(Guid id)
    {
        var owner = await _services.OwnerService.GetOwnerByIdAsync(id,
            false);
        return Ok(owner);
    }


    [HttpPost(Name = "CreateOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]

    public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto ownerDto)
    {
        var owner = await _services.OwnerService.CreateOwnerAsync(ownerDto);
        return CreatedAtRoute("GetOwnerById", new{ id = owner.Id}, owner);
    }


    [HttpDelete("{id:guid}", Name = "DeleteOwner")]
    public async Task<IActionResult> DeleteOwner(Guid id)
    {
        await _services.OwnerService.DeleteOwnerAsync(id, false);
        return NoContent();
    }


    [HttpPut]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateOwner(Guid id,
        [FromForm] OwnerForUpdateDto ownerDto)
    {
        await _services.OwnerService.UpdateOwnerAsync(id,
            ownerDto,
            true);
        return NoContent();
    }
}