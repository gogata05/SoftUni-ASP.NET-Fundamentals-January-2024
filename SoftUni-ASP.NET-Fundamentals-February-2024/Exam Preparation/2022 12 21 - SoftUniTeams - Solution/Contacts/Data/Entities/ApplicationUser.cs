

// only ICollection here needed
//icollection3
using Microsoft.AspNetCore.Identity;
namespace Contacts.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}
// Auto user (Id,Name,Email,Pass)  

//copy description here:
//ApplicationUser
//    •	Has an Id – a string, Primary Key
//    •	Has a UserName – a string with min length 5 and max length 20 (required)
//    •	Has an Email – a string with min length 10 and max length 60 (required)
//    •	Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required for a hashed password in the database (required)

//    •	Has ApplicationUsersContacts – a collection of type ApplicationUserContact
