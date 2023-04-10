using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IEstablishmentService EstablishmentService { get; }
        ICategoryService CategoryService { get; }
        IOwnerService OwnerService { get; }
        IAuthenticationService AuthenticationService { get; }
        IFileService FileService { get; }
        IUserService UserService { get; }
        IAccessibilityService AccessibilityService { get; }
    }
}