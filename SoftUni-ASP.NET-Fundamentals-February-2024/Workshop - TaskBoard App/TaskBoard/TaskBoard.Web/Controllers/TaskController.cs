namespace TaskBoard.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaskBoard.Core.Contracts;
    using TaskBoard.Core.Models.Task;
    using TaskBoard.Web.Extensions;

    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                TaskFormModel model = new TaskFormModel();
               
                var boards = await boardService.GetBoardsForSelectAsync();
                model.Boards = boards;

                return View(model);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel inputModel)
        {
            try
            {
                bool boardExist = await boardService.DoesExists(inputModel.BoardId);
                if (!boardExist)
                {
                    ModelState.AddModelError(nameof(inputModel.BoardId), "Board does not exist");
                }

                if (!ModelState.IsValid)
                {
                    var boards = await boardService.GetBoardsForSelectAsync();
                    inputModel.Boards = boards;
                    return View(inputModel);
                }

                string currentUserId = this.User.GetId();

                await taskService.AddAsync(currentUserId, inputModel);

                return RedirectToAction("All", "Board");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {   
            try
            {
                TaskDetailsViewModel taskDetails = await taskService.GetDetailsAsync(id);

                return View(taskDetails);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                TaskFormModel model = await taskService.GetFormModelByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        public async Task<IActionResult> Edit(string id, TaskFormModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var boards = await boardService.GetBoardsForSelectAsync();
                    inputModel.Boards = boards;
                    return View(inputModel);
                }

                await taskService.EditAsync(id, inputModel);

                return RedirectToAction("All", "Board");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                TaskViewModel taskModel = await taskService.GetViewModelByIdAsync(id);

                string currentUser = this.User.GetUser();

                if(taskModel.Owner != currentUser)
                {
                    return Unauthorized();
                }

                return View(taskModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, TaskViewModel taskViewModel)
        {
            try
            {
                await taskService.DeleteAsync(id, taskViewModel);

                return RedirectToAction("All", "Board");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }
    }
}
