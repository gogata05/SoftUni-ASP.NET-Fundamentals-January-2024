// Details is rearly used, delete if not needed


// only properties with only: int, string, decimal, double
//pp,pp5
using System.Xml.Linq;

namespace Homies.Models.Event
{
    public class EventViewDetailsModel : EventViewModel
    {
        
        public string Name { get; set; } = null!;


        public string Description { get; set; } = null!;


        public string Start { get; set; } = null!;


        public string End { get; set; } = null!;



        public string Organiser { get; set; } = null!;


        public string CreatedOn { get; set; } = null!;


        public string Type { get; set; } = null!;


        public int Id { get; set; }


    }
}
// : EventViewModel

// copy "Details" shape here from Views.Event:
//Name 
//Description
//Start
//End
//Organiser
//CreatedOn
//Type
//Id


// copy Event description here:   and delete unused properties:
//    •	Has Id – a unique int, Primary Key
//    •	Has Name – a string with min length 5 and max length 20 (required)*
//    •	Has Description – a string with min length 15 and max length 150 (required)*
//    •	Has Organiser – an IdentityUser (required)
//    •	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has End – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has Type – a Type (required)


