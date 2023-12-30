using System.ComponentModel.DataAnnotations;

namespace TextSplitter.Models;

public class TextViewModel
{
    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string Text { get; set; } = null!;

    public string? SplitText { get; set; }
}
