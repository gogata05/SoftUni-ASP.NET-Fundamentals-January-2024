// if "Type" exists

// only properties with only: int, string, decimal, double
//pp,pp5
namespace Homies.Models.Type
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
//copy "All","Profile","Add","Edit" Type shape here:
//< option value = "@type.Id" > @type.Name </ option >


// copy Event description here:   and delete unused properties:
//Type
//    •	Has Id – a unique integer, Primary Key
//    •	Has Name – a string with min length 5 and max length 15 (required)
//    •	Has Events – a collection of type Event
