//if there is no "IdentityUser" class in the ManyToMany entity in description
//This is SomethingUser class/entity(example: ApplicationUser) from description 

//only IEnumerable-List here:
//i1-IEnumerable-List

namespace Contacts.Models.Contact
{
    public class AllContactsQueryModel
    {
        public IEnumerable<ContactViewModel> Contacts { get; set; } = new List<ContactViewModel>();

    }
}
//query