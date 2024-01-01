using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using TaskBoard.Core.Contracts;
using TaskBoard.Core.Models.Task;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Core.Services
{

    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext dbContext;
        private readonly IBoardService boardService;
        public TaskService(TaskBoardAppDbContext dbContext, IBoardService boardService)
        {
            this.dbContext = dbContext;
            this.boardService = boardService;
        }

        public async Task AddAsync(string OwnerId,TaskFormModel inputModel)
        {
            Infrastructure.Data.Models.Task newTask = new Infrastructure.Data.Models.Task()
            {
               Title = inputModel.Title,
               Description = inputModel.Description,
               BoardId = inputModel.BoardId,
               CreatedOn = DateTime.UtcNow,
               OwnerId = OwnerId
            };

            await dbContext.Tasks.AddAsync(newTask);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string taskId, TaskViewModel model)
        {
            Infrastructure.Data.Models.Task? modelToDelete = await dbContext.Tasks
                               .FindAsync(Guid.Parse(taskId));

            if (modelToDelete == null)
            {
                throw new Exception("Task cannot be found");
            }

            dbContext.Tasks.Remove(modelToDelete);
            await dbContext.SaveChangesAsync();

        }

        public async Task EditAsync(string taskId, TaskFormModel inputModel)
        {
            Infrastructure.Data.Models.Task? modelToEdit = await dbContext.Tasks
                               .FindAsync(Guid.Parse(taskId)); 

            if(modelToEdit == null)
            {
                throw new Exception("Task cannot be found");
            }

            modelToEdit.Title = inputModel.Title;
            modelToEdit.Description = inputModel.Description;
            modelToEdit.BoardId = inputModel.BoardId;

            await dbContext.SaveChangesAsync();
        }

        public async Task<TaskFormModel> GetFormModelByIdAsync(string taskId)
        {
            try
            {
                var foundTask = await dbContext.Tasks
                               .FindAsync(Guid.Parse(taskId));

                if(foundTask == null)
                {
                    throw new Exception("Task cannot be found");
                }

                var boards = await boardService.GetBoardsForSelectAsync();

                TaskFormModel newModel = new TaskFormModel
                {
                    Title = foundTask.Title,
                    Description = foundTask.Description,
                    BoardId = foundTask.BoardId,
                    Boards = boards
                };

                return newModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaskDetailsViewModel> GetDetailsAsync(string taskId)
        {
            try
            {
                var foundTask = await dbContext.Tasks
                                .Select(x => new TaskDetailsViewModel()
                                {
                                    Id = x.Id.ToString(),
                                    Description = x.Description,
                                    Title = x.Title,
                                    Owner = x.Owner.UserName,
                                    Board = x.Board.Name,
                                    CreatedOn = x.CreatedOn.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                                })
                                .FirstOrDefaultAsync(t => t.Id == taskId);

                if (foundTask == null)
                {
                    throw new Exception("Task cannot be found");
                }


                return foundTask;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TaskViewModel> GetViewModelByIdAsync(string taskId)
        {
            try
            {
                var foundTask = await dbContext.Tasks
                               .Select(t => new TaskViewModel
                               {
                                   Id = t.Id.ToString(),
                                   Title = t.Title,
                                   Description = t.Description,
                                   Owner = t.Owner.UserName
                               })
                               .FirstOrDefaultAsync(t => t.Id == taskId);

                if (foundTask == null)
                {
                    throw new Exception("Task cannot be found");
                }


                return foundTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> TaskCountInBoardAsync(string boardName)
        {
            return await dbContext.Tasks
                         .Where(t => t.Board.Name == boardName)
                         .CountAsync();
        }

        public async Task<int> AllTasksCountAsync()
        {
            return await dbContext.Tasks
                         .CountAsync();
        }

        public async Task<int> GetUserTasksGount(string userId)
        {
            return await dbContext.Tasks
                        .Where(t => t.OwnerId == userId)
                        .CountAsync();
        }
    }
}
