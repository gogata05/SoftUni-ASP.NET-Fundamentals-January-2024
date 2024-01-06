using Homies.Models.Type;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Data.DataConstants;
namespace Homies.Models.Event
{
    public class EventFormModel
    {
        [Required]
        [StringLength(EventMaxName, MinimumLength = EventMinName,
            ErrorMessage = "Event name must be between 5 and 20 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventMaxDescription, MinimumLength = EventMinDescription,
            ErrorMessage = "Description must be between 15 and 150 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required] 
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; }
            = new List<TypeViewModel>();
    }
}
//req,"?",min,max,range,regular,email,enum int range,displayname,*

// "Add" shape:
// @Model.Name
// @Model.Description
// @Model.Start
// @Model.End
// @Model.TypeId
// Model.Types


// Event 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 20 (required) 
// Has Description – a string with min length 15 and max length 150 (required) 
// Has OrganiserId – an string (required) 
// Has Organiser – an IdentityUser (required) 
// Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one) 
// Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one) 
// Has End – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one) 
// Has TypeId – an integer, foreign key (required) 
// Has Type – a Type (required) 
// Has EventsParticipants – a collection of type EventParticipant 