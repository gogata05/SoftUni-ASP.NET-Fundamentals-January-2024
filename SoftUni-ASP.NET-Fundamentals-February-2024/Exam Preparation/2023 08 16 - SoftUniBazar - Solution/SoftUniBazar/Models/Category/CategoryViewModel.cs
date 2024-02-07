// if "Category" exists

// only properties with only: int, string, decimal, double
//pp,pp5
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using SoftUniBazar.Data.Entities;

namespace SoftUniBazar.Models.Category
{
    public class CategoryViewModel
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        //public IEnumerable<Ad> Categories { get; set; } = new List<Ad>();

    }
}
//copy "All","Profile","Item","Edit" category shape here:
//< option value = "@type.Id" > @type.Name </ option >
//Model.Categories

//copy Category description here:
//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 3 and max length 15 (required)
//•	Has Ads – a collection of type Ad
