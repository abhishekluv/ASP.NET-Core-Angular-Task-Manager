using Shared.Dtos;

namespace Service.Contracts
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItemDto>> GetAllTaskItemsAsync(bool trackChanges);
        Task<TaskItemDto> GetTaskItemAsync(int id, bool trackChanges);
        Task<TaskItemDto> CreateTaskItemAsync(TaskItemForCreationDto taskItemForCreationDto);
    }
}
