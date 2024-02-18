// only properties with only: int, string, decimal, double
//pp,pp5
namespace Solution.Models.Item
{
    public class ItemDeleteModel
    {
        public int Id {get; set; }

        public string Topic { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;

    }
}
// copy "Delete" shape here from Views.Item:
//Id
//Topic
//DateAndTime

//copy Item description here:   and delete unused properties:
//Item
// Has Id – a unique integer, Primary Key 
// Has Topic – a string with min length 5 and max length 20 (required) 
// Has DateAndTime – a DateTime with format "yyyy-MM-dd H:mm" (required)