using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Models.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly IOptions<JwtConfiguration> _configuration;
        private readonly JwtConfiguration _jwtConfiguration;

        private ApplicationUser? _user;

        public AuthenticationService(UserManager<ApplicationUser> userManager, ILoggerManager loggerManager, IMapper mapper, IOptions<JwtConfiguration> configuration)
        {
            _userManager = userManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
            _configuration = configuration;
            _jwtConfiguration = _configuration.Value;
        }
 
        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<ApplicationUser>(userForRegistrationDto);
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
        {
            _user = await _userManager.FindByEmailAsync(userForAuthenticationDto.Email);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));

            return result;
        }

        public JwtTokenDto CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            var token = new JwtTokenDto() {  Token = accessToken };

            return token;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(issuer: _jwtConfiguration.ValidIssuer, audience: _jwtConfiguration.ValidAudience, claims: claims, signingCredentials: signingCredentials, expires: DateTime.Now.AddHours(Convert.ToDouble(_jwtConfiguration.Expires)));

            return tokenOptions;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfiguration.Key);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            return claims;
        }
    }
}
