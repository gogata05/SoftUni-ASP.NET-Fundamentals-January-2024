using TaskBoard.Core.Models.Task;

namespace TaskBoard.Core.Models.Board
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            this.Tasks = new List<TaskViewModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<TaskViewModel> Tasks { get; set; }
    }
}
