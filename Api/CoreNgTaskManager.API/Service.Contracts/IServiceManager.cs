namespace Service.Contracts
{
    public interface IServiceManager
    {
        ITaskItemService TaskItemService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}