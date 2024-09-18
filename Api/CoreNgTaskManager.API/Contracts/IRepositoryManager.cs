namespace Contracts
{
    public interface IRepositoryManager
    {
        ITaskItemRepository TaskItems { get; }
        Task SaveAsync();
    }
}
