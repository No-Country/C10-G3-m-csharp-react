using System.Text.Json;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

[Route("api/establisment")]
[ApiController]
public class EstablismentController : ControllerBase
{
    private readonly IServiceManager _service;

    public EstablismentController(IServiceManager service)
    {
        _service = service;
    }


    [HttpGet(Name = "GetEstablisments")]
    public async Task<IActionResult> GetEstablisments([FromQuery] EstablishmentParameters parameters)
    {
        var pagedResult = await _service.EstablishmentService.GetEstablishmentsAsync(parameters, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.establishmentDtos);
    }

    [HttpGet("{id:guid}", Name = "GetEstablishmentById")]
    public async Task<IActionResult> GetEstablishmentById(Guid id)
    {
        var establishment = await _service.EstablishmentService.GetEstablishmentByIdAsync(id, false);
        return Ok(establishment);
    }

    [HttpPost(Name = "CreateEstablishment")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateEstablishment(Guid ownerId, [FromForm] EstablishmentForCreationDto establishment)
    {
        var establishmentCreated =
            await _service.EstablishmentService.CreateEstablishmentAsync(ownerId, establishment, false);
        return CreatedAtRoute("GetEstablishmentById", new { id = establishmentCreated.Id }, establishmentCreated);
    }
    
    [HttpDelete("{id:guid}", Name = "DeleteEstablishment")]
    public async Task<IActionResult> DeleteEstablishment(Guid ownerId, Guid id)
    {
        await _service.EstablishmentService.DeleteEstablishmentAsync(ownerId, id, false);
        return NoContent();
    }
    
    [HttpPut("{id:guid}", Name = "UpdateEstablishment")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateEstablishment(Guid ownerId, Guid id, [FromForm] EstablishmentForUpdateDto establishment)
    {
        await _service.EstablishmentService.UpdateEstablishmentAsync(ownerId, id, establishment, false,true);
        return NoContent();
    }
}