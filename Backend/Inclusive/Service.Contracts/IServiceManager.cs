﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        ICategoryImageService CategoryImageService { get; }
        IAuthenticationService AuthenticationService { get; }
        IFileService FileService { get; }
    }
}