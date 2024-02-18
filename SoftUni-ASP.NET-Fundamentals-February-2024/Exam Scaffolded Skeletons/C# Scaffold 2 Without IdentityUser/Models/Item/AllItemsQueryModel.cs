//if there is no "IdentityUser" class in the ManyToMany entity in description
//This is SomethingUser class/entity(example: ApplicationUser) from description 


//i1-IEnumerable-List
namespace Solution.Models.Contact
{
    public class AllItemsQueryModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
            = new List<ItemViewModel>();
    }
}
//query