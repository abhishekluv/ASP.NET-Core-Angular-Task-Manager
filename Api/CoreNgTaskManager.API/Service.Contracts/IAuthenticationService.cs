﻿using Microsoft.AspNetCore.Identity;
using Shared.Dtos;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
        JwtTokenDto CreateToken();
    }
}
