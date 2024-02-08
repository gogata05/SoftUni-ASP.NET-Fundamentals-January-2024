

//pp,pp5
//db,sl1
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.EventNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DataConstants.EventDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string OrganiserId { get; set; }

        [Required]
        public IdentityUser Organiser { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Required]
        public Type Type { get; set; }
        
        public EventParticipant EventsParticipants { get; set; }
    }
}
//pk,fk,req,max,*

//copy description here:
//    •	Has Id – a unique int, Primary Key
//    •	Has Name – a string with min length 5 and max length 20 (required)*
//    •	Has Description – a string with min length 15 and max length 150 (required)*
//    •	Has OrganiserId – an string (required)
//    •	Has Organiser – an IdentityUser (required)
//    •	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has End – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has TypeId – an int, foreign key (required)
//    •	Has Type – a Type (required)
//    •	Has EventsParticipants – a collection of type EventParticipant
