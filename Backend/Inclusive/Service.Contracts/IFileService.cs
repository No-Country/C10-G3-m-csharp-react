using Entities.Models;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects.EstablishmentDtos;

namespace Service.Contracts;

public interface IFileService 
{
    Task<Category?> UploadCategoryFileAsync(Guid fatherId, IFormFile? file, string path, string imagePath);
    Task<EstablishmentDto?> UploadEstablishmentFileAsync(Guid fatherId, IFormFile? file, string path, string imagePath);
    Task DeleteFile(string path, string imgeContainer, Guid id);
}