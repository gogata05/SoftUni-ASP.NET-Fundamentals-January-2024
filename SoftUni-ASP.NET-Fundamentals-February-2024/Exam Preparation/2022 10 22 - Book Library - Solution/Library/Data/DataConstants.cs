using System.Reflection.Metadata;
using System.Security.Policy;

namespace Library.Data
{
    public class DataConstants
    {
        //Category
        public const int MaxCategoryName = 50;
        public const int MinCategoryName = 5;

        // Book
        public const int MaxBookTitle = 50;
        public const int MinBookTitle = 10;
        public const int MaxDescription = 5000;
        public const int MinDescription = 5;
        public const int MaxAuthorName = 50;
        public const int MinAuthorName = 5;

        // User
        // later
        public const int MaxUserUsername = 20;
        public const int MaxUserEmail = 60;
    }
}
//category
//Has Name – a string with min length 5 and max length 50 (required) 

//book
//Has Title – a string with min length 10 and max length 50 (required) 
//Has Author – a string with min length 5 and max length 50 (required) 
//Has Description – a string with min length 5 and max length 5000 (required) 
//Has ImageUrl – a string (required) 
//Has Rating – a decimal with min value 0.00 and max value 10.00 (required) 