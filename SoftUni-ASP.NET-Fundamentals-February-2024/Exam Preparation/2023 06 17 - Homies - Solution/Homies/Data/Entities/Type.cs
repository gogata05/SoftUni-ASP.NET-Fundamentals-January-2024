

//pp,pp5
//db,sl1,ienumerable-list

using System.ComponentModel.DataAnnotations;
namespace Homies.Data.Entities
{
    public class Type
    {
        //[Key]
        public int Id { get; set; }

        //[Required]
        [StringLength(DataConstants.TypeNameMaxLength)]
        public string Name { get; set; }

        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
//pk,fk,req,max,*

//copy description here:
//Type
//    •	Has Id – a unique integer, Primary Key
//    •	Has Name – a string with min length 5 and max length 15 (required)
//    •	Has Events – a collection of type Event
