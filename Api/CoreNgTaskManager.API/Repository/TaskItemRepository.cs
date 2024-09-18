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
            var taskItems = await FindAll(trackChanges).Select(task => new TaskItem
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt,
                DueDate = task.DueDate,
                User = new ApplicationUser
                {
                    UserName = task.User.UserName
                }
            }).ToListAsync();
            return taskItems;
        }

        public async Task<TaskItem> GetTaskItemAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id == id, trackChanges).Select(task => new TaskItem
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt,
                DueDate = task.DueDate,
                User = new ApplicationUser
                {
                    UserName = task.User.UserName
                }
            }).SingleOrDefaultAsync();
        }
    }
}