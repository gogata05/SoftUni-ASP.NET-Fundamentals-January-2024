using Microsoft.AspNetCore.Mvc;
using TaskBoard.Core.Contracts;
using TaskBoard.Core.Models.Board;
using TaskBoard.Core.Models.Home;
using TaskBoard.Web.Extensions;

namespace TaskBoard.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBoardService boardService;
        private readonly ITaskService taskService;

        public HomeController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<HomeBoardModel> boards = await boardService.GetHomeBoardsAsync();

            foreach (HomeBoardModel board in boards)
            {
                board.TasksCount = await taskService.TaskCountInBoardAsync(board.BoardName);
            }

            int allTasksCount = await taskService.AllTasksCountAsync();

            int userTasksCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                string currentUserId = this.User.GetId();
                userTasksCount = await taskService.GetUserTasksGount(currentUserId);
            }

            HomeViewModel homeModel = new HomeViewModel()
            {
                AllTasksCount = allTasksCount,
                BoardsWithTasksCount = boards.ToList(),
                UserTasksCount = userTasksCount
            };


            return View(homeModel);
        }


    }
}