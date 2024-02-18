// Details is rearly used, delete if not needed


// only properties with only: int, string, decimal, double
//pp,pp5
namespace Solution.Models.Event
{
    public class ItemViewDetailsModel : ItemViewModel// inheritance
    {
        public string Description { get; set; } = null!;
        public string End { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;
    }
}
// : ItemViewModel

// copy "Details" shape here from Views.Item:

// Model.Id
// Model.Name
// Model.Start
// Model.Type
// Model.Organiser

// Model.Description
// Model.End
// Model.CreatedOn


// copy Item description here:   and delete unused properties:
//Event  
// Has Description – a string with min length 15 and max length 150 (required) 
// Has End – a DateTime with format "yyyy-MM-dd H:mm" (required)
// Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) 
