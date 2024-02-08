

//full info properties 
//pp,pp5
//dbw,sl2,IEnumerable-list
using Type = Homies.Data.Entities.Type;
using System.ComponentModel.DataAnnotations;
using Homies.Data;
using Homies.Models.Type;

namespace Homies.Models.Event
{
    public class EventFormModel
    {
        [Required]
        [StringLength(DataConstants.EventNameMaxLength, MinimumLength = DataConstants.EventNameMinLength)]
        public string Name { get; set; }


        [Required]
        [StringLength(DataConstants.EventDescriptionMaxLength, MinimumLength = DataConstants.EventDescriptionMinLength)]
        public string Description { get; set; }


        [Required]
        public DateTime Start { get; set; }


        [Required]
        public DateTime End { get; set; }


        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();

    }
}
//req,"?",min,max,range,regular,email,enum int range,displayname,*

// copy "Add","Edit" shape here from Views.Event:
//Model.Name
//Model.Description
//Model.Start
//Model.End
//Model.TypeId
//Model.Types

// copy Event description here:   and delete unused properties:
//    •	Has Name – a string with min length 5 and max length 20 (required)*
//    •	Has Description – a string with min length 15 and max length 150 (required)*
//    •	Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has End – a DateTime with format "yyyy-MM-dd H:mm" (required) 
//    •	Has TypeId – an int, foreign key (required)
//    •	Has Type – a Type (required)//?
