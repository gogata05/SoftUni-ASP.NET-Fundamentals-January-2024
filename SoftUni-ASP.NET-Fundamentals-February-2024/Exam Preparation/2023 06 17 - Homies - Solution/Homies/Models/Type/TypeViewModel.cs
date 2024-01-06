namespace Homies.Models.Type
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
//All,Profile,Add,Edit 
//type shape:
//value="@type.Id">@type.Name





// Type 
// Has Id – a unique integer, Primary Key 
// Has Name – a string with min length 5 and max length 15 (required) 
// Has Events – a collection of type Event 