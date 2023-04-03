﻿using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Service.Contracts;

public interface IFileService
{
    Task<Category?> UploadCategoryFileAsync(Guid fatherId, IFormFile? file, string path, string imagePath);
    void DeleteFile(string path, Guid id);
}