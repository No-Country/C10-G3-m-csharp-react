using System.Text.Json;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.CategoryDtos;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

[Route("api/category")]
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CategoryController(IServiceManager service, IWebHostEnvironment webHostEnvironment)
    {
        _service = service;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet(Name = "GetCategories")]
    public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters parameters)
    {
        var pagedResult = await _service.CategoryService.GetCategoriesAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.categories);
    }

    [HttpGet("{id:guid}", Name = "GetCategoryById")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _service.CategoryService.GetCategoryByIdAsync(id, false);
        return Ok(category);
    }

    [HttpPost(Name = "CreateCategory")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCategory([FromForm] CategoryForCreationDto category)
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath);
        var urlPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);
        var res = await _service.FileService.UploadCategoryFileAsync(createdCategory.Id, category.Image, path, urlPath);

        return CreatedAtRoute("GetCategoryById", new { id = res?.Id ?? createdCategory.Id }, res == null ? createdCategory : res);
    }

    [HttpDelete("{id:guid}", Name = "DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        _service.FileService.DeleteFile(Path.Combine(_webHostEnvironment.WebRootPath), id);
        await _service.CategoryService.DeleteCategoryAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateCategory")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromForm] CategoryForUpdateDto category)
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath);
        var urlPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        await _service.CategoryService.UpdateCategoryAsync(id, category, true);
        var res = await _service.FileService.UploadCategoryFileAsync(id, category.Image, path, urlPath);

        return CreatedAtRoute("GetCategoryById", new { id = res?.Id ?? id }, res == null ? category : res);
    }
}