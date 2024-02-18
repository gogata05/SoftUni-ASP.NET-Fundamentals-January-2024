namespace SeminarHub.Models.Seminar
{
    public class SeminarDeleteModel
    {
        public int Id {get; set; }

        public string Topic { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;

    }
}