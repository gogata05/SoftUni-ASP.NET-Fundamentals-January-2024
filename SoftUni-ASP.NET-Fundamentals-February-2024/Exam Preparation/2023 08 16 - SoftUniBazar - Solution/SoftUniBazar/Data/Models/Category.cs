using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.DataConstants;
namespace SoftUniBazar.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(CategoryNameMax)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Ad> Ads { get; set; } = new List<Ad>();
    }
}
//pk,fk,req,max,*

// Category 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 3 and max length 15 (required) 
// Has Ads – a collection of type Ad 