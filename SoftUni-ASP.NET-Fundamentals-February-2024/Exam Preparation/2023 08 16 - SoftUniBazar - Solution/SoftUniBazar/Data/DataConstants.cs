namespace SoftUniBazar.Data
{
    public static class DataConstants
    {
        ///Ad
        //Name
        public const int AdNameMinLength = 5;
        public const int AdNameMaxLength = 25;

        //Description
        public const int AdDescriptionMinLength = 15;
        public const int AdDescriptionMaxLength = 250;

        ///Category
        //Name
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 15;

    }
}
//Ad
//    •	Has Name – a string with min length 5 and max length 25 (required)
//    •	Has Description – a string with min length 15 and max length 250 (required)
//Category
//    •	Has Name – a string with min length 3 and max length 15 (required)