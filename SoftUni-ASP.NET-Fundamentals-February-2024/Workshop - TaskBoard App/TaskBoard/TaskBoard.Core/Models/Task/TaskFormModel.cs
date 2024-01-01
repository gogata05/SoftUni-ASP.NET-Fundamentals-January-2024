namespace TaskBoard.Core.Models.Task
{
    using System.ComponentModel.DataAnnotations;
    using TaskBoard.Core.Models.Board;
    using static Common.ValidationConstants.Task;
    public class TaskFormModel
    {
        [Required]
        [MinLength(MinTitleLength)]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(MinDescriptionLength)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;

        public int BoardId { get; set; }

        public IEnumerable<BoardSelectViewModel>? Boards { get; set; }

    }
}
