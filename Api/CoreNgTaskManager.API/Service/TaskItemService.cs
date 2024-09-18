using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.Dtos;

namespace Service
{
    public sealed class TaskItemService : ITaskItemService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TaskItemService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItemDto>> GetAllTaskItemsAsync(bool trackChanges)
        {
            var taskItems = await _repositoryManager.TaskItems.GetAllTaskItemsAsync(trackChanges);
            var taskItemsDto = _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);
            return taskItemsDto;
        }

        public async Task<TaskItemDto> GetTaskItemAsync(int id, bool trackChanges)
        {
            var taskItem = await _repositoryManager.TaskItems.GetTaskItemAsync(id, trackChanges);
            var taskItemDto = _mapper.Map<TaskItemDto>(taskItem);
            return taskItemDto;
        }
    }
}