namespace TaskBoard.Common
{
    public class ValidationConstants
    {
        public static class Task
        {
            public const int MinTitleLength = 5;
            public const int MaxTitleLength = 70;
            public const int MinDescriptionLength = 5;
            public const int MaxDescriptionLength = 1000;
          
        }

        public static class Board
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 30;
            
        }
    }
}