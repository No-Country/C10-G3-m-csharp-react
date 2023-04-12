using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Models.Establishments;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.Helper;
using System.ComponentModel;
using static System.IO.Directory;

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

    public Task DeleteFile(string path, string imgeContainer, Guid id)
    {
        var filePath = Path.Combine(path, FilePath.Images, imgeContainer, id.ToString());
        if (Exists(filePath)) Delete(filePath, true);
        
        return Task.FromResult(0);
    }

    public async Task<Category?> UploadCategoryFileAsync(Guid fatherId, IFormFile? file, string path, string imagePath)
    {
        if (string.IsNullOrEmpty(file?.FileName)) return null;
        var directoryPath = Path.Combine(path, FilePath.Images, FilePath.Categories, fatherId.ToString());

        if (Exists(directoryPath)) Delete(directoryPath, true);
        CreateDirectory(directoryPath);
        var filePath = Path.Combine(directoryPath, file.FileName);
        var urlPath = $"{imagePath}/{FilePath.Images}/{FilePath.Categories}/{fatherId.ToString()}/{file.FileName}";

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
        stream.Close();
        var categoryEntity = await _repository.Categories.GetCategoryByIdAsync(fatherId, true);
        categoryEntity!.Image = urlPath;
        await _repository.SaveAsync();

        return await _repository.Categories.GetCategoryByIdAsync(fatherId, false);
    }

    public async Task<EstablishmentDto?> UploadEstablishmentFileAsync(Guid fatherId, IFormFile? file, string path, string imagePath)
    {
        if (string.IsNullOrEmpty(file?.FileName)) return null;
        var directoryPath = Path.Combine(path, FilePath.Images, FilePath.Establishments, fatherId.ToString());

        if (Exists(directoryPath)) Delete(directoryPath, true);
        CreateDirectory(directoryPath);
        var dir = Path.Combine(directoryPath, file.FileName);
        var urlPath = $"{imagePath}/{FilePath.Images}/{FilePath.Establishments}/{fatherId.ToString()}/{file.FileName}";

        await using var stream = new FileStream(dir, FileMode.Create);
        await file.CopyToAsync(stream);
        stream.Close();
        var establishmentEntity = await _repository.Establishments.GetEstablishmentByIdAsync(fatherId, true);
        establishmentEntity!.Image = urlPath;
        await _repository.SaveAsync();


        var establishment = await _repository.Establishments.GetEstablishmentByIdAsync(fatherId, false);
        return _mapper.Map<EstablishmentDto>(establishment);
    }
}

