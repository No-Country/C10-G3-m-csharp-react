using System.Text.Json;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public CategoryController(IServiceManager service)
    {
        _service = service;
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
    public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
    {
        var createCategory = await _service.CategoryService.CreateCategoryAsync(category);
        return CreatedAtRoute("GetCategoryById", new { id = createCategory.Id }, createCategory);
    }

    [HttpDelete("{id:guid}", Name = "DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        await _service.CategoryService.DeleteCategoryAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateCategory")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category)
    {
        await _service.CategoryService.UpdateCategoryAsync(id, category, true);
        return NoContent();
    }
}