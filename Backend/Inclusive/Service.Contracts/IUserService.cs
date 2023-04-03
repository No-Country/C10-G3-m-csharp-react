using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.User;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<IdentityResult> UpdateUserAsync(Guid id, string logUserId, UserForUpdateDto user);
        Task<IdentityResult> UpdateUserPasswordAsync(Guid id, string logUserId, UserForUpdatePasswordDto user);
    }
}




