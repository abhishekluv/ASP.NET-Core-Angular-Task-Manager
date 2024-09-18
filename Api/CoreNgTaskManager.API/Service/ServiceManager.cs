using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Models.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITaskItemService> _taskItemService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager loggerManager, UserManager<ApplicationUser> userManager, IOptions<JwtConfiguration> configuration)
        {
            _taskItemService = new Lazy<ITaskItemService>(() => new TaskItemService(repositoryManager, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager,loggerManager, mapper,configuration));
        }

        public ITaskItemService TaskItemService => _taskItemService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
