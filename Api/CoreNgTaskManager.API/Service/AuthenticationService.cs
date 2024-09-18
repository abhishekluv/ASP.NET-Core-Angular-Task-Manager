using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Models.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Shared.Dtos;

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
        public Task<JwtTokenDto> CreateToken()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<ApplicationUser>(userForRegistrationDto);
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            return result;
        }

        public Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
        {
            throw new NotImplementedException();
        }
    }
}
