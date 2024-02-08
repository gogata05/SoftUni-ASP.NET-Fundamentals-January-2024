

// only properties with only: int, string, decimal, double
//pp,pp5
namespace Contacts.Models.Contact
{

    public class ContactViewModel
    {
        public string FirstName { get; set; } = null!;


        public string LastName { get; set; } = null!;


        public string Email { get; set; } = null!;


        public string PhoneNumber { get; set; } = null!;


        public string? Address { get; set; }


        public string Website { get; set; } = null!;


        public int Id { get; set; }

    }

}
// copy "All","Profile" shape here from Views.Contact:
//FirstName
//LastName
//Email
//PhoneNumber
//Address
//Website
//Id

// copy Contact description here:   and delete unused properties:
//Contact
//    •	Has FirstName – a string with min length 2 and max length 50 (required)
//    •	Has LastName – a string with min length 5 and max length 50 (required)
//    •	Has Email – a string with min length 10 and max length 60 (required)
//    •	Has PhoneNumber – a string with min length 10 and max length 13 (required). The phone number must start with "+359" or '0' (zero), followed by four sets of digits, separated by a space, '-' (dash) or nothing between the sets. The first group must have exactly three digits and the others exactly two digits. Valid examples: 0 875 23 45 15, +359 - 883 - 15 - 12 - 10, 0889552217.
//    •	Has Address – a string 
//    •	Has Website – a string. First four characters are "www.", followed by letters, digits or '-' and last three characters are ".bg" (required)
