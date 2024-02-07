using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; }


        public virtual IEnumerable<Ad> Ads { get; set; } = new List<Ad>();

    }
}
//fk,req,max,*

//Category
//    •	Has Id – a unique int, Primary Key
//    •	Has Name – a string with min length 3 and max length 15 (required)
//    •	Has Ads – a collection of type Ad
