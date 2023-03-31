using Microsoft.AspNetCore.Http;

namespace Service.Contracts;

public interface IFileService
{
    Task UploadFileAsync(Guid fatherId, IEnumerable<IFormFile>? files, string folderName, string path);
}