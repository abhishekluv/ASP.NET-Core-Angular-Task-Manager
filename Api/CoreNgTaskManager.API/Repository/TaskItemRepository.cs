using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TaskItemRepository : RepositoryBase<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateTaskItem(TaskItem taskItem)
        {
            Create(taskItem);
        }

        public void DeleteTaskItem(TaskItem taskItem)
        {
            Delete(taskItem);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<TaskItem> GetTaskItemAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }
}