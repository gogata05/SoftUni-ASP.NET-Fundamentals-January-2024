using TaskBoard.Core.Models.Task;

namespace TaskBoard.Core.Contracts
{
    public interface ITaskService
    {
        public Task AddAsync(string OwnerId,TaskFormModel inputModel);

        public Task<TaskDetailsViewModel> GetDetailsAsync(string taskId);

        public Task EditAsync(string taskId, TaskFormModel inputModel);

        public Task<TaskFormModel> GetFormModelByIdAsync(string taskId);

        public Task<TaskViewModel> GetViewModelByIdAsync(string taskId);

        public Task DeleteAsync(string taskId, TaskViewModel model);

        public Task<int> TaskCountInBoardAsync(string boardName);

        public Task<int> AllTasksCountAsync();

        public Task<int> GetUserTasksGount(string userId);
    }
}
