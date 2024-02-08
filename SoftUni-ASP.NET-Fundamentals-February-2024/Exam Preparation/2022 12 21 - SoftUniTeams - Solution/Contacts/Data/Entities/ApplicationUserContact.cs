

//pp,pp5
//db,sl1

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Contacts.Data.Entities
{
    public class ApplicationUserContact
    {
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [ForeignKey(nameof(Contact))]
        public int ContactId { get; set; }


        public Contact Contact { get; set; }

    }
}
//fk,req,max,*

//copy description here:
//ApplicationUserContact
//    •	ApplicationUserId – a  string, Primary Key, foreign key (required)
//    •	ApplicationUser – ApplicationUser
//    •	ContactId – an integer, Primary Key, foreign key (required)
//    •	Contact – Contact
