using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Services.Models;
using Shared.DataTransferObjects.UserDtos;
using Shared.Helper;

namespace Services;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly JWTSettings _jWTSettings;

    private User? _user;

    public AuthenticationService(ILoggerManager logger,
                                 IMapper mapper,
                                 UserManager<User> userManager,
                                 IOptions<JWTSettings> jWTSettings)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _jWTSettings = jWTSettings.Value;
    }

    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto
        userForRegistration)
    {
        var user = _mapper.Map<User>(userForRegistration);
        // user.EmailConfirmed = true

        var result = await _userManager.CreateAsync(user, userForRegistration.Password);

        if (result.Succeeded)
            await _userManager.AddToRoleAsync(user, UserRoles.User);

        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
    {
        //_user = await _userManager.FindByNameAsync(userForAuth.UserName);
        _user = await _userManager.FindByEmailAsync(userForAuth.Email);
        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

        if (!result)
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");
        return result;
    }

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jWTSettings.SecretKey);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<IEnumerable<Claim>> GetClaims()
    {
        IList<Claim> userClaims = await _userManager.GetClaimsAsync(_user!);

        var roles = await _userManager.GetRolesAsync(_user!);
        List<Claim> roleClaims = new();

        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(CustomClaimTypes.Role, role));
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _user!.Id),
            new Claim(JwtRegisteredClaimNames.Email, _user.Email),
            new Claim(CustomClaimTypes.FullName, $"{_user.FirstName} {_user.LastName}"),
            //new Claim(CustomClaimTypes.Uid, _user!.Id),
            // new Claim("ip", ipAddress)
        }
        .Union(userClaims)
        .Union(roleClaims);

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        //var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jWTSettings.ValidIssuer,
            audience: _jWTSettings.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jWTSettings.DurationInMinutes)),
            signingCredentials: signingCredentials
        );
        return tokenOptions;
    }
}