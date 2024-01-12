using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants;
namespace Library.Data.Entities
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCategoryName)]
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
//pk,fk,req,max,*

// Category 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 50 (required) 
// Has Books – a collection of type Books 