﻿using Contracts;
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
using Microsoft.Extensions.Options;
using Services.Models;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration, IOptions<JWTSettings> jWTSettings)
        {
            _categoryService =
                new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper, loggerManager));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(loggerManager, mapper, userManager, jWTSettings));

            //new AuthenticationService(loggerManager, mapper, userManager, configuration));
        }

        public ICategoryService CategoryService => _categoryService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}