using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects.UserDtos;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserNotFoundException(email,true);
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await GetUserAndCheckIfItExists(id);
            return _mapper.Map<UserDto>(user);
        }


        public async Task<IdentityResult> UpdateUserAsync(Guid id, string logUserId, UserForUpdateDto user)
        {
            if (id != Guid.Parse(logUserId))
                throw new UserBadRequestException(id.ToString());

            var userEntity = await GetUserAndCheckIfItExists(id);
            _mapper.Map(user, userEntity);
            var result = await _userManager.UpdateAsync(userEntity);

            if (!result.Succeeded)
            {
                _logger.LogWarn($"{nameof(UpdateUserAsync)}: Update User failed. Wrong username or password.");
            }
                
            return result;
        }

        public async Task<IdentityResult> UpdateUserPasswordAsync(Guid id, string logUserId, UserForUpdatePasswordDto user)
        {
            if (id != Guid.Parse(logUserId))
                throw new UserBadRequestException(id.ToString()); 

            var userEntity = await GetUserAndCheckIfItExists(id);

            var result = await _userManager.ChangePasswordAsync(userEntity, user.CurrentPassword, user.NewPassword);

            if (!result.Succeeded)
            {
                _logger.LogWarn($"{nameof(UpdateUserPasswordAsync)}: Update Password failed.");
            }

            return result;
        }

        private async Task<User> GetUserAndCheckIfItExists(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null) throw new UserNotFoundException(id.ToString());
            return user;
        }
    }
}
