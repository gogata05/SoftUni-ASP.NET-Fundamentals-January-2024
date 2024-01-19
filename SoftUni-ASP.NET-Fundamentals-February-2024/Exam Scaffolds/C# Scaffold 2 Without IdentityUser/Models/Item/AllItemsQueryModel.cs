//if there is no "IdentityUser" class in the ManyToMany entity in description
//This is SomethingUser class/entity from description which has specific properties: Id, UserName, Email, Password,a Collection(example: ApplicationUser))


//dbwc-IEnumerable-List
namespace Items.Models
{
    public class AllItemsQueryModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
            = new List<ItemViewModel>();
    }
}
//query