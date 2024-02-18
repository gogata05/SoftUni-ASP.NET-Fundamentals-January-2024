namespace SeminarHub.Models.Seminar
{
    public class SeminarViewDetailsModel : SeminarViewModel
    {
        public int Duration { get; set; }

        public string Details { get; set; } = null!;
    }
}
