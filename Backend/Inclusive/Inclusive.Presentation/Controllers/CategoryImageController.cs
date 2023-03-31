using System.Text.Json;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

public class CategoryImageController : ControllerBase
{
    private IServiceManager _service;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CategoryImageController(IServiceManager service, IWebHostEnvironment webHostEnvironment)
    {
        _service = service;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet(Name = "GetCategoryImages")]
    public async Task<IActionResult> GetCategoryImages([FromQuery] CategoryImageParameters parameters)
    {
        var pagedResult = await _service.CategoryImageService.GetCategoryImagesAsync(parameters, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.categoryImages);
    }

    [HttpGet(Name = "GetCategoryImagesByCategory")]
    public async Task<IActionResult> GetCategoryImagesByCategory([FromQuery] CategoryImageParameters parameters,
        Guid id)
    {
        var pagedResult = await _service.CategoryImageService.GetCategoryImagesByCategoryAsync(id, parameters, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.categoryImages);
    }

    [HttpGet("{id:guid}", Name = "GetCategoryImageById")]
    public async Task<IActionResult> GetCategoryImageById(Guid id)
    {
        var categoryImage = await _service.CategoryImageService.GetCategoryImageByIdAsync(id, false);
        return Ok(categoryImage);
    }

    [HttpPost(Name = "CreateCategoryImage")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCategoryImage([FromForm] CategoryImageForCreationDto categoryImage)
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        var createdCategoryImage =
            await _service.CategoryImageService.CreateCategoryImageAsync(categoryImage.CategoryId, categoryImage,
                false);
        await _service.FileService.UploadFileAsync(categoryImage.CategoryId, categoryImage.CategoryImages, "category",
            path);
        return CreatedAtRoute("GetCategoryImageById", new { id = createdCategoryImage.Id }, createdCategoryImage);
    }

    [HttpDelete("{id:guid}", Name = "DeleteCategoryImage")]
    public async Task<IActionResult> DeleteCategoryImage(Guid id)
    {
        await _service.CategoryImageService.DeleteCategoryImageAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateCategoryImage")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCategoryImage(Guid id, [FromBody] CategoryImageForUpdateDto categoryImage)
    {
        await _service.CategoryImageService.UpdateCategoryImageAsync(categoryImage.CategoryId, id, categoryImage, false,
            true);
        return NoContent();
    }
}