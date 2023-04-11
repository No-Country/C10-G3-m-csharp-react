using System.Text.Json;
using Entities.Models;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.Helper;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

[Route("api/establishment")]
[ApiController]
public class EstablishmentController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public EstablishmentController(IServiceManager service, IWebHostEnvironment webHostEnvironment)
    {
        _service = service;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet(Name = "GetEstablishments")]
    public async Task<IActionResult> GetEstablishments([FromQuery] EstablishmentParameters parameters)
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
        var path = Path.Combine(_webHostEnvironment.WebRootPath);
        var urlPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

        var establishmentCreated = await _service.EstablishmentService.CreateEstablishmentAsync(ownerId, establishment, false);

        var res = await _service.FileService.UploadEstablishmentFileAsync(establishmentCreated.Id, establishment.Image, path, urlPath);

        return CreatedAtRoute("GetEstablishmentById", new { id = res?.Id ?? establishmentCreated.Id }, res == null ? establishmentCreated : res);
        //return CreatedAtRoute("GetEstablishmentById", new { id = establishmentCreated.Id }, establishmentCreated);
    }

    [HttpDelete("{id:guid}", Name = "DeleteEstablishment")]
    public async Task<IActionResult> DeleteEstablishment(Guid ownerId, Guid id)
    {
        await _service.FileService.DeleteFile(Path.Combine(_webHostEnvironment.WebRootPath), FilePath.Establishments, id);
        await _service.EstablishmentService.DeleteEstablishmentAsync(ownerId, id, false);
        return NoContent();
    }
    
    [HttpPut("{id:guid}", Name = "UpdateEstablishment")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateEstablishment(Guid ownerId, Guid id, [FromForm] EstablishmentForUpdateDto establishment)
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath);
        var urlPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

        //await _service.CategoryService.UpdateCategoryAsync(id, category, true);
        await _service.EstablishmentService.UpdateEstablishmentAsync(ownerId, id, establishment, false, true);

        var res = await _service.FileService.UploadCategoryFileAsync(id, establishment.Image, path, urlPath);

        return CreatedAtRoute("GetEstablishmentById", new { id = res?.Id ?? id }, res == null ? establishment : res);
    }
}