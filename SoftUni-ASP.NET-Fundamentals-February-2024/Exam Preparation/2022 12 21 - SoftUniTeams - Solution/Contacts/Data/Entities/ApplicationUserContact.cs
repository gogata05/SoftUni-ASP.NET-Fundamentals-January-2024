using System.ComponentModel.DataAnnotations.Schema;
namespace Contacts.Data.Entities
{
    public class ApplicationUserContact 
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
// ApplicationUserContact 
// ApplicationUserId – a  string, Primary Key, foreign key (required) 
// ApplicationUser – ApplicationUser 
// ContactId – an integer, Primary Key, foreign key (required) 
// Contact – Contact 