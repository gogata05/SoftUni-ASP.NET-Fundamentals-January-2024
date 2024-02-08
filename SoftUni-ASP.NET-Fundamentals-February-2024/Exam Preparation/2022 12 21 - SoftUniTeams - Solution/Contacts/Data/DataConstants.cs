

//pc,pc5
//pcs1Regex
namespace Contacts.Data
{
    public static class DataConstants
    {
        ///Contact
        //FirstName
        public const int ContactFirstNameMinLength = 2;
        public const int ContactFirstNameMaxLength = 50;

        //LastName
        public const int ContactLastNameMinLength = 5;
        public const int ContactLastNameMaxLength = 50;

        //Email
        public const int ContactEmailMinLength = 10;
        public const int ContactEmailMaxLength = 60;

        //PhoneNumber
        public const int ContactPhoneNumberMinLength = 10;
        public const int ContactPhoneNumberMaxLength = 13;

        //PhoneNumber
        public const string ContactPhoneNumberRegex = @"^(\+359|0)\s?\d{3}\s?\d{2}\s?\d{2}\s?\d{2}$";//?

        //Website
        public const string ContactWebsiteRegex = @"^www\.[A-Za-z0-9-]+\.[bB][gG]$";//?

        ///ApplicationUser
        //UserName
        //public const int ApplicationUserUserNameMinLength = 5;
        //public const int ApplicationUserUserNameMaxLength = 20;

        ////Email
        //public const int ApplicationUserEmailMinLength = 10;
        //public const int ApplicationUserEmailMaxLength = 60;

        ////Password
        //public const int ApplicationUserPasswordMinLength = 5;
        //public const int ApplicationUserPasswordMaxLength = 20;

    }
}
//Copy all min/max length constants here:
//Contact
//    •	Has FirstName – a string with min length 2 and max length 50 (required)
//    •	Has LastName – a string with min length 5 and max length 50 (required)
//    •	Has Email – a string with min length 10 and max length 60 (required)

//    •	Has PhoneNumber – a string with min length 10 and max length 13 (required). The phone number must start with "+359" or '0' (zero), followed by four sets of digits, separated by a space, '-' (dash) or nothing between the sets. The first group must have exactly three digits and the others exactly two digits. Valid examples: 0 875 23 45 15, +359 - 883 - 15 - 12 - 10, 0889552217.
//    •	Has Website – a string. First four characters are "www.", followed by letters, digits or '-' and last three characters are ".bg" (required)


//ApplicationUser
//    •	Has a UserName – a string with min length 5 and max length 20 (required)
//    •	Has an Email – a string with min length 10 and max length 60 (required)
//    •	Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required for a hashed password in the database (required)




