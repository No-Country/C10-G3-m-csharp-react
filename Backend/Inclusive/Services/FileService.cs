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

    public async Task<Category?> UploadCategoryFileAsync(Guid fatherId, IFormFile? file, string path)
    {
        if (file == null)
            return null;

        if (string.IsNullOrEmpty(file.FileName))
            return null;

        var directoryPath = Path.Combine(path, "categories", fatherId.ToString());

        if (Directory.Exists(directoryPath))
            Directory.Delete(directoryPath, true);

        Directory.CreateDirectory(directoryPath);

        var dir = Path.Combine(directoryPath, file.FileName);

        using (var stream = new FileStream(dir, FileMode.Create))
        {
            await file.CopyToAsync(stream);
            stream.Close();
        }

        var categoryEntity = await _repository.Categories.GetCategoryByIdAsync(fatherId, true);
        categoryEntity.Image = dir;
        await _repository.SaveAsync();
        return await _repository.Categories.GetCategoryByIdAsync(fatherId, true);
    }
}