using Entities.Models;
using Entities.Models.Establishments;
using Microsoft.AspNetCore.Http;

namespace Service.Contracts;

public interface IFileService 
{
    Task<Category?> UploadCategoryFileAsync(Guid fatherId, IFormFile? file, string path, string imagePath);
    Task<Establishment?> UploadEstablishmentFileAsync(Guid fatherId, IFormFile? file, string path, string imagePath);
    Task DeleteFile(string path, string imgeContainer, Guid id);
}