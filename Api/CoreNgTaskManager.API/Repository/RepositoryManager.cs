using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ITaskItemRepository> _taskItemRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _taskItemRepository = new Lazy<ITaskItemRepository>(() => new TaskItemRepository(repositoryContext));
        }

        public ITaskItemRepository TaskItems => _taskItemRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}