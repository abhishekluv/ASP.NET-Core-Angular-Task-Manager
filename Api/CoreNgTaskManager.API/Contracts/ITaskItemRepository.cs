using Entities.Models;

namespace Contracts
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync(bool trackChanges);
        Task<TaskItem> GetTaskItemAsync(int id, bool trackChanges);
        void CreateTaskItem(TaskItem taskItem);
        void DeleteTaskItem(TaskItem taskItem);
    }
}
