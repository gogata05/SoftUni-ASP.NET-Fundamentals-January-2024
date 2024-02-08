

// only properties with only: int, string, decimal, double
//pp,pp5
using System.Xml.Linq;

namespace Homies.Models.Event
{

    public class EventViewModel
    {
        
        public string Name { get; set; } = null!;


        public string Start { get; set; } = null!;


        public string Type { get; set; } = null!;


        public int Id { get; set; }


        public string Organiser { get; set; } = null!;


    }

}
// copy "All","Profile" shape here from Views.Event:
//Name
//Start
//Type
//Id
//Organiser

// copy Event description here:   and delete unused properties:
//Event
//    •	Has Id – a unique integer, Primary Key
//    •	Has Name – a string with min length 5 and max length 20 (required)*
//    •	Has Organiser – an IdentityUser (required)
//    •	Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required)
//    •	Has Type – a Type (required)
