using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IFileService> _fileService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _categoryService =
                new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper, loggerManager));
            _fileService = new Lazy<IFileService>(() => new FileService(repositoryManager, mapper, loggerManager));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(loggerManager, mapper, userManager, configuration));
        }

        public ICategoryService CategoryService => _categoryService.Value;
        public IFileService FileService => _fileService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}