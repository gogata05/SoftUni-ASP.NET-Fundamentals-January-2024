namespace TaskBoard.Core.Models.Task
{
    public class TaskDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Board { get; set; } = null!;

        public string Owner { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;
    }
}
