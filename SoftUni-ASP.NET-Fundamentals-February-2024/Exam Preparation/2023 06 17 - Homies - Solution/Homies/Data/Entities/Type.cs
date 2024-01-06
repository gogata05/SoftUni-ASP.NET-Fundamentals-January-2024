using System.ComponentModel.DataAnnotations;
using Homies.Data.Entities;
using static Homies.Data.DataConstants;
namespace Homies.Data.Entities
{
    public class Type
    {
        public int Id { get; set; }

        [StringLength(TypeNameMax)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
//pk,fk,req,max,*

// Type 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 15 (required) 
// Has Events – a collection of type Event 