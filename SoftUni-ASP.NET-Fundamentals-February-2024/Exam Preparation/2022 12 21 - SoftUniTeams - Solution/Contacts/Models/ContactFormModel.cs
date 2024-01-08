using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using static Contacts.Data.DataConstants;
namespace Contacts.Models
{
    public class ContactFormModel 
    {
        [Required]
        [StringLength(ContactFirstNameMaxLength, MinimumLength = ContactFirstNameMinLength)]
        //[Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ContactLastNameMaxLength, MinimumLength = ContactLastNameMinLength)]
        //[Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        //[Display(Name = "E-mail")]
        [StringLength(ContactEmailMaxLength, MinimumLength = ContactEmailMinLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(ContactPhoneNumberMaxLength, MinimumLength = ContactPhoneNumberMinLength)]
        //[Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        public string? Address { get; set; }

        [Required]
        [RegularExpression(ContactWebsiteRegex)]
        public string Website { get; set; }
    }
}
//req,"?",min,max,range,regular,email,enum int range,displayname,*

// "Add" shape:
// asp-for="FirstName"
// asp-for="LastName" -
// asp-for="Email"
// asp-for="PhoneNumber"
// asp-for="Address"
// asp-for="Website"


// Contact 
// Has Id – a unique integer, Primary Key 
// Has FirstName – a string with min length 2 and max length 50 (required) 
// Has LastName – a string with min length 5 and max length 50 (required) 
// Has Email – a string with min length 10 and max length 60 (required) 
// Has PhoneNumber – a string with min length 10 and max length 13 (required). The phone number must start with "+359" or '0' (zero), followed by four sets of digits, separated by a space, '-' (dash) or nothing between the sets. The first group must have exactly three digits and the others exactly two digits. Valid examples: 0 875 23 45 15, +359-883-15-12-10, 0889552217. 
// Has Address – a string  
// Has Website – a string. First four characters are "www.", followed by letters, digits or '-' and last three characters are ".bg" (required) 
// Has ApplicationUsersContacts – a collection of type ApplicationUserContact 