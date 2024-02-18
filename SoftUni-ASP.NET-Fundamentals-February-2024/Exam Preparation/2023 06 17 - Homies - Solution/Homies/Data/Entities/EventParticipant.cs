

//pp,pp5
//db,sl1
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Homies.Data.Entities
{
    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(Helper))]
        public string HelperId { get; set; } = null!;


        public IdentityUser Helper { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }


        public Event Event { get; set; } = null!;

    }
}
//fk,req,max,*

//copy description here:
//EventParticipant
//    •	HelperId – a  string, Primary Key, foreign key (required)
//    •	Helper – IdentityUser
//    •	EventId – an integer, Primary Key, foreign key (required)
//    •	Event – Event
