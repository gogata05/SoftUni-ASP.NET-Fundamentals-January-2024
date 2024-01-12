using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class ApplicationUserBook
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } 

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; } 
    }
}
//fk,req,max,*

// ApplicationUserBook 
// ApplicationUserId – a  string, Primary Key, foreign key (required) 
// ApplicationUser – ApplicationUser 
// BookId – an integer, Primary Key, foreign key (required) 
// Book – Book 