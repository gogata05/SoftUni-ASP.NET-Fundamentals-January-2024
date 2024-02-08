

//pc,pc5
//pcs1Regex
using Homies.Data.Entities;
using NuGet.Configuration;

namespace Homies.Data
{
    public static class DataConstants
    {
        ///Event
        //Name
        public const int EventNameMinLength = 5;
        public const int EventNameMaxLength = 20;

        //Description
        public const int EventDescriptionMinLength = 15;
        public const int EventDescriptionMaxLength = 150;

        ///Type
        //Name
        public const int TypeNameMinLength = 5;
        public const int TypeNameMaxLength = 15;

    }
}
//Copy all min/max length constants here:
//Event
//    •	Has Name – a string with min length 5 and max length 20 (required)
//    •	Has Description – a string with min length 15 and max length 150 (required)
//Type
//    •	Has Name – a string with min length 5 and max length 15 (required)



