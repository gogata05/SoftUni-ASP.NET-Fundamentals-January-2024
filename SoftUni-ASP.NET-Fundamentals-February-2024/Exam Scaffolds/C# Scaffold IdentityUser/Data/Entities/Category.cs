//DB Level

//pp,pp5
//db,using,
using System.ComponentModel.DataAnnotations;
using static Solution.Data.DataConstants;
namespace Solution.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(CategoryNameMax)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Item> Items { get; set; } = new List<Item>();
    }
}
//pk,fk,req,max,*

//Category
//    •	Has Id – a unique int, Primary Key
//    •	Has Name – a string with min length 3 and max length 15 (required)*
//    •	Has Ads – a collection of type Ad