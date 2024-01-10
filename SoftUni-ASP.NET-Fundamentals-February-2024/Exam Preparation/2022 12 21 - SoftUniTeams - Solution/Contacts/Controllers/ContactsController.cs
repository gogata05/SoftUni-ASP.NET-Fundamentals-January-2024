

// Use   //*   to remove "Category" everywhere if "type" doesn't exists



//Ctrl+H - Replace "Contact" 1st with uppercase then lowercase////главни букви включени
//0.1.uppercase//главни букви включени
//0.2.lowercase//главни букви включени


//1.2: replace "BazarDbContext" with the "NameDbContext" Ctrl+H

//1.3: replace "Category" with the "Name" Ctrl+H//if exist
//1.4: replace "GetCategories" with the "GetName" Ctrl+H//if exist
//1.5: replace "Categories" with the "TypesName" Ctrl+H//check the "DbSetTypeName"

//1.6: replace "OwnerId" with the "OwnerNameId" Ctrl+H
//1.7: replace "BuyerId" with the "Name2Id" Ctrl+H//ManyToManyEntityName2//careful

//1.8: replace "Names1Names2" with the "Name1Name2" Ctrl+H//ManyToManyEntityName//careful
//1.9: replace "Name1Name2" with the "Name1Name2" Ctrl+H//ManyToManyEntityName//careful




//copy redirections here:

// Redirections
// ⦁	Upon successful Login of an IdentityUser, you should be redirected to the /Ad/All.
// ⦁	Upon successful Creation of an Ad, you should be redirected to the /Ad/All.
// ⦁	Upon successful Adding an Ad to the User's collection, should be redirected to the /Ad/Cart.
// ⦁	Upon successful Editing of an Ad, you should be redirected to the /Ad/All.
// ⦁	Upon successful Removal of an Ad from the User's collection, should be redirected to the /Ad/All.
// ⦁	If a User tries to add an already added ad to their collection, they should be redirected to /Ad/All (or just a page refresh).
// ⦁	Upon successful Logout of a User, you should be redirected to the Index Page.
// ⦁	If any of the validations in the POST forms don't pass, redirect to the same page (reload/refresh it).


//replace immediately: Ctrl+H
//All,Add,Edit,Details,Team,AddToTeam,RemoveFromTeam
//copy URLs here:

//All,Add,Edit,Details,Team,AddToTeam,RemoveFromTeam




using Contacts.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Contacts.Data.Entities;
using Contacts.Models;
namespace Contacts.Controllers
{

    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ContactsDbContext _data;
        public ContactsController(ContactsDbContext data)
        {
            _data = data;
        }

        //"Add" button//Get
        public IActionResult Add()//"Add" get
        {
            ContactFormModel contactModel = new ContactFormModel()
            {
            };
            return View(contactModel);
        }

        //Add,All,Edit
        //Details sometimes

        //"Add" button/Post
        [HttpPost]
        public IActionResult Add(ContactFormModel contactModel)//"Add" post
        {
            if (!ModelState.IsValid)
            {
                return View(contactModel);
            }
            string currentUserId = GetUserId();//!
            var contactToAdd = new Contact()
            {
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Email = contactModel.Email,
                PhoneNumber = contactModel.PhoneNumber,
                Address = contactModel.Address,
                Website = contactModel.Website
                // asp-for="FirstName"
                // asp-for="LastName" -
                // asp-for="Email"
                // asp-for="PhoneNumber"
                // asp-for="Address"
                // asp-for="Website"

            };
            _data.Contacts.Add(contactToAdd);
            _data.SaveChanges();
            return RedirectToAction("All", "Contacts");//!
        }

        //"All" button
        //replace "All" with "AllContactsName" button
        public IActionResult All()
        {
            var allContacts = new AllContactsQueryModel()
            {
                Contacts = _data.Contacts
                    .Select(c => new ContactViewModel()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PhoneNumber = c.PhoneNumber,
                        Email = c.Email,
                        Address = c.Address,
                        Website = c.Website
                        // @contact.FirstName
                        // @contact.LastName
                        // @contact.Email
                        // @contact.PhoneNumber
                        // @contact.Address
                        // @contact.Website
                        // @contact.Id
                    })
            };
            return View(allContacts);
        }

        //If "Edit" button exist//Get
        //replace "Edit" with "EditName" button
        public IActionResult Edit(int id)//"Edit" get
        {
            var contactToEdit = _data.Contacts.Find(id);
            if (contactToEdit == null)
            {
                return BadRequest();
            }
            // string currentUserId = GetUserId();
            // if (currentUserId != contactToEdit.OwnerId)
            // {
            //     return Unauthorized();
            // }
            ContactFormModel contactModel = new ContactFormModel()
            {

                FirstName = contactToEdit.FirstName,
                LastName = contactToEdit.LastName,
                Address = contactToEdit.Address,
                PhoneNumber = contactToEdit.PhoneNumber,
                Website = contactToEdit.Website,
                Email = contactToEdit.Email
                // asp-for="FirstName"
                // asp-for="LastName" -
                // asp-for="Email"
                // asp-for="PhoneNumber"
                // asp-for="Address"
                // asp-for="Website"
            };
            return View(contactModel);
        }

        //If "Edit" button exist//Post
        //replace "Edit" with "EditName" button
        [HttpPost]
        public IActionResult Edit(int id, ContactFormModel contactModel)//"Edit" post
        {
            var contactToEdit = _data.Contacts.Find(id);
            if (contactToEdit == null)
            {
                return BadRequest();
            }
            // string currentUser = GetUserId();
            // if (currentUser != contactToEdit.OwnerId)
            // {
            //     return Unauthorized();
            // }

            contactToEdit.FirstName = contactModel.FirstName;
            contactToEdit.LastName = contactModel.LastName;
            contactToEdit.Address = contactModel.Address;
            contactToEdit.PhoneNumber = contactModel.PhoneNumber;
            contactToEdit.Website = contactModel.Website;
            contactToEdit.Email = contactModel.Email;
            // asp-for="FirstName"
            // asp-for="LastName" -
            // asp-for="Email"
            // asp-for="PhoneNumber"
            // asp-for="Address"
            // asp-for="Website"
            _data.SaveChanges();//its a sync! why await??? maybe _
            return RedirectToAction("All", "Contacts");//!
        }


        //"MyProfileName" button
        //replace "Cart" with "MyProfileName" button
        public IActionResult Team()//"My Profile" button
        {
            string currentUserId = GetUserId();
            var currentUser = _data.Users.Find(currentUserId);
            var allContacts = new AllContactsQueryModel()
            {
                Contacts = _data.ApplicationUsersContacts
                    .Where(x => x.ApplicationUserId == currentUserId)//F2 - ApplicationUserId
                    .Select(um => new ContactViewModel()
                    {
                        Id = um.Contact.Id,
                        FirstName = um.Contact.FirstName,
                        LastName = um.Contact.LastName,
                        Email = um.Contact.Email,
                        Website = um.Contact.Website,
                        Address = um.Contact.Address,
                        PhoneNumber = um.Contact.PhoneNumber
                        // @contact.FirstName
                        // @contact.LastName
                        // @contact.Email
                        // @contact.PhoneNumber
                        // @contact.Address
                        // @contact.Website
                        // @contact.Id
                    })
            };
            return View(allContacts);
        }

        //"AddContactToProfile" button
        //replace "AddToCart" with "AddContactToProfile" button
        //replace "Cart" with "profileName" : Ctrl+H
        [HttpPost]
        public IActionResult AddToTeam(int id)//"AddToCart" button
        {
            var contact = _data.Contacts.Find(id);
            if (contact == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();//!
            var entry = new ApplicationUserContact()
            {
                ContactId = contact.Id,
                ApplicationUserId = currentUserId//!
            };
            if (_data.ApplicationUsersContacts.Contains(entry))
            {
                return RedirectToAction("Team", "Contacts");//!
            }
            _data.ApplicationUsersContacts.Add(entry);
            _data.SaveChanges();
            return RedirectToAction("Team", "Contacts");//!
        }

        //"RemoveContactFromProfile" button
        //replace "RemoveFromCart" with "RemoveContactFromProfile" button
        [HttpPost]
        public IActionResult RemoveFromTeam(int id)//"RemoveFromCart" button
        {
            var contactId = id;
            var currentUserId = GetUserId();//!
            var contact = _data.Contacts.Find(id);
            if (contact == null)
            {
                return BadRequest();
            }
            var entry = _data.ApplicationUsersContacts.FirstOrDefault(x => x.ApplicationUserId == currentUserId && x.ContactId == id);
            _data.ApplicationUsersContacts.Remove(entry);
            _data.SaveChanges();
            return RedirectToAction("Team", "Contacts");//!
        }


        // Get currently logged-in user's Id//Извличане на Id на текущия потребител
        private string GetUserId()
           => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
