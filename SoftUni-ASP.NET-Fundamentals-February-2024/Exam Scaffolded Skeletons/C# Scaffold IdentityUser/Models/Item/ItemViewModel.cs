

// only properties with only: int, string, decimal, double
//pp,pp5
namespace Solution.Models.Item
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Organiser { get; set; } = null!;
    }

}
// copy "All","Profile" shape here from Views.Item:
// e.Id
// e.Name
// e.Start
// e.Type
// e.Organiser

//copy Item description here:   and delete unused properties:
//Event 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 20 (required) 
// Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required) 
// Has Type – a Type (required) 
// Has Organiser – an IdentityUser (required) 