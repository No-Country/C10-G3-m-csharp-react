using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Services;

public class FileService : IFileService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public FileService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task UploadFileAsync(Guid fatherId, IEnumerable<IFormFile>? files, string folderName, string path)
    {
        if (files == null)
            return;

        foreach (var file in files)
        {
            if (string.IsNullOrEmpty(file.FileName))
                break;
            if (!Directory.Exists(Path.Combine(path, folderName)))
                Directory.CreateDirectory(Path.Combine(path, folderName));

            var dir = Path.Combine(path, folderName, file.FileName);

            using (var stream = new FileStream(dir, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Close();
            }

            await SaveImageToDbAsync(fatherId, file.FileName, dir, "category");
        }
    }

    private async Task SaveImageToDbAsync(Guid fatherId, string fileName, string filePath, string type)
    {
        if (type.Equals("category"))
            _repository.CategoryImages.CreateCategoryImage(fatherId,
                new CategoryImage { ImageName = fileName, ImagePath = filePath });
        if (type.Equals("categoryImage"))
            return;
        
        await _repository.SaveAsync();
    }
}