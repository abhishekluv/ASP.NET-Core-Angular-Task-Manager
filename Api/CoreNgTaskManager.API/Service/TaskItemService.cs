using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.Dtos;
using System.Security.Claims;

namespace Service
{
    public sealed class TaskItemService : ITaskItemService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskItemService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TaskItemDto> CreateTaskItemAsync(TaskItemForCreationDto taskItemForCreationDto)
        {
            var taskItemToCreate = _mapper.Map<TaskItem>(taskItemForCreationDto);

            var userId = GetCurrentUserId();
            taskItemToCreate.UserId = userId;
           
            _repositoryManager.TaskItems.CreateTaskItem(taskItemToCreate);
            await _repositoryManager.SaveAsync();

            var taskItemToReturn = _mapper.Map<TaskItemDto>(taskItemToCreate);
            return taskItemToReturn;
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

        private int? GetCurrentUserId()
        {
            var userIdAsString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if(int.TryParse(userIdAsString, out var userId))
            {
                return userId;
            }

            return null;
        }
    }
}