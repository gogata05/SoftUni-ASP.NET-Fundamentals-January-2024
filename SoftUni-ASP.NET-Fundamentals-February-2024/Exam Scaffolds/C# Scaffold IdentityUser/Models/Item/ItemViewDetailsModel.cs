// Details is rearly used, delete if not needed

// ItemViewDetailsModel.cs
//:,pp,pp5
namespace Solution.Models.Event
{
    public class ItemViewDetailsModel : ItemViewModel
    {
        public string Description { get; set; } = null!;
        public string End { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;
    }
}
// : ItemViewModel

//"Details" shape:

// @Model.Id
// @Model.Name
// @Model.Start
// @Model.Type
// @Model.Organiser

// @Model.Description
// @Model.End
// @Model.CreatedOn



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