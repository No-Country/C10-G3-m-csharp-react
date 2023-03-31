﻿using System.Text.Json;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Hosting;
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
        var path = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);
        await _service.FileService.UploadFileAsync(createdCategory.Id, category.CategoryImages, "category",
            path);

        return CreatedAtRoute("GetCategoryById", new { id = createdCategory.Id }, createdCategory);
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