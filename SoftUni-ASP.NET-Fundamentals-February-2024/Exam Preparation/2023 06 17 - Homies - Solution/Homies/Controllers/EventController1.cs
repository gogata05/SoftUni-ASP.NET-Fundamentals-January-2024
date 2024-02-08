

// Use   //*   to remove "Type" everywhere if "type" doesn't exists



//Ctrl+H - Replace "Event" 1st with uppercase then lowercase////главни букви включени
//0.1.uppercase//главни букви включени
//0.2.lowercase//главни букви включени

//1.2: replace "BazarDbContext" with the "NameDbContext" Ctrl+H

//1.3: replace "Type" with the "Name" Ctrl+H//if exist
//1.4: replace "GetTypes" with the "GetName" Ctrl+H//if exist
//1.5: replace "Types" with the "TypesName" Ctrl+H//check the "DbSetTypeName"

//1.6: replace "OrganiserId " with the "OwnerNameId" Ctrl+H
//1.7: replace "HelperId " with the "Name2Id" Ctrl+H//ManyToManyEntityName2//careful

//1.8: replace "EventParticipants" with the "EventParticipant" Ctrl+H//ManyToManyEntityName//careful
//1.9: replace "EventParticipant" with the "EventParticipant" Ctrl+H//ManyToManyEntityName//careful




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
//All,Add,Edit,Details,Joined ,AddToCart1,RemoveFromCart1
//copy URLs here:

//All,Add,Edit,Details,Team,AddToTeam,RemoveFromTeam

using System.Security.Claims;
using Homies.Data;
using Homies.Data.Entities;
using Homies.Models.Event;
using Homies.Models.Type;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Solution.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext _data;
        public EventController(HomiesDbContext data)
        {
            _data = data;
        }

        //"Add" button//Get
        public async Task<IActionResult> Add()//"Add" get
        {
            EventFormModel eventModel = new EventFormModel()
            {
                Types = GetTypes()//If there is no "type" entity remove this line and leave it empty//*
            };
            return View(eventModel);
        }

        //Add,All,Edit:
        //Details sometimes:

        //"Add" button/Post
        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel eventModel)//"Add" post
        {
            if (!GetTypes().Any(e => e.Id == eventModel.TypeId))//*
            {
                ModelState.AddModelError(nameof(eventModel.TypeId), "Type does not exist!");
            }
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }
            string currentUserId = GetUserId();//!
            var eventToAdd = new Event()
            {
                CreatedOn = DateTime.Now,//delete if no Date needed in "All"
                OrganiserId  = currentUserId,//F2 - OrganiserId 

                Name = eventModel.Name,
                Description = eventModel.Description,
                Start = eventModel.Start,
                End = eventModel.End,
                TypeId = eventModel.TypeId,


                //we skip/dont post this: model.Types; 

                //fix names:
                //copy "Add" shape here from EventFormModel.cs:
                //Model.Name
                //Model.Description
                //Model.Start
                //Model.End
                //Model.TypeId
                //Model.Types

            };
            await _data.Events.AddAsync(eventToAdd);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Event");//!
        }

        //"All" button
        //replace "All" with "AllEventsName" button
        public async Task<IActionResult> All()
        {
            var eventsToDisplay = await _data
                .Events
                .Select(e => new EventViewModel()
                {
                    Name = e.Name,
                    Start = e.Start.ToString("dd/MM/yyyy H:mm"),//?
                    Type = e.Type.Name,
                    Id = e.Id,
                    Organiser = e.Organiser.UserName,


                    //Name = e.Name,
                    //CreatedOn = e.CreatedOn.ToString("dd/MM/yyyy H:mm"),

                    //fix names:
                    //copy shape here from EventViewModel.cs:
                    //Name
                    //Start
                    //Type
                    //Id
                    //Organiser

                }).ToListAsync();
            return View(eventsToDisplay);
        }

        //If "Edit" button exist//Get
        //replace "Edit" with "EditName" button
        public async Task<IActionResult> Edit(int id)//"Edit" get
        {
            var eventToEdit = await _data.Events.FindAsync(id);
            if (eventToEdit == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != eventToEdit.OrganiserId )
            {
                return Unauthorized();
            }
            EventFormModel eventModel = new EventFormModel()
            {
                Types = GetTypes(),
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start,
                End = eventToEdit.End,
                TypeId = eventToEdit.TypeId,


                // Name = eventToEdit.Name,

                //fix names:
                //copy "Edit" shape here from EventFormModel.cs:
                //Model.Name
                //Model.Description
                //Model.Start
                //Model.End
                //Model.TypeId
                //Model.Types

            };
            return View(eventModel);
        }

        //If "Edit" button exist//Post
        //replace "Edit" with "EditName" button
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormModel model)//"Edit" post
        {
            var eventToEdit = await _data.Events.FindAsync(id);
            if (eventToEdit == null)
            {
                return BadRequest();
            }
            string currentUser = GetUserId();
            if (currentUser != eventToEdit.OrganiserId )//!
            {
                return Unauthorized();
            }
            if (!GetTypes().Any(e => e.Id == model.TypeId))//*
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist!");
            }
            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.Start = model.Start;
            eventToEdit.End = model.End;
            eventToEdit.TypeId = model.TypeId;


            //we skip/dont post this: model.Types; 

            //eventToEdit.Name = model.Name;

            //fix names:
            //copy "Edit" shape here from EventFormModel.cs:
            //Model.Name
            //Model.Description
            //Model.Start
            //Model.End
            //Model.TypeId
            //Model.Types

            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Event");//!
        }

        //if "Details" button exists
        //"details" button in dashboard/not in myprofile//in myprofile only add/remove event
        //replace "Details" details "detailsButtonName"
        public async Task<IActionResult> Details(int id)//"Details" button
        {
            var eventDetails = await _data
               .Events
               .Where(e => e.Id == id)
               .Select(e => new EventViewDetailsModel()
               {
                   Name = e.Name,
                   Description = e.Description,
                   Start = e.Start.ToString("dd/MM/yyyy H:mm"),//?
                   End = e.End.ToString("dd/MM/yyyy H:mm"),//?
                   Organiser = e.Organiser.UserName,
                   CreatedOn = e.CreatedOn.ToString("dd/MM/yyyy H:mm"),//?
                   Type = e.Type.Name,
                   Id = e.Id,


                   //name = e.Name,
                   //createdOn = e.CreatedOn.ToString("dd/mm/yyyy h:mm")

                   //fix names
                   //copy "Details" shape here from EventViewDetailsModel.cs:
                   //Name 
                   //Description
                   //Start
                   //End
                   //Organiser
                   //CreatedOn
                   //Type
                   //Id

               }).FirstOrDefaultAsync();
            if (eventDetails == null)
            {
                return BadRequest();
            }
            return View(eventDetails);
        }


        //"MyProfileName" button
        //replace "Cart" with "MyProfileName" button
        public async Task<IActionResult> Joined()//"My Profile" button
        {
            string currentUserId = GetUserId();
            var userEvents = await _data
                .EventParticipants//F2 - EventParticipants
                .Where(ab => ab.HelperId  == currentUserId)//F2 - HelperId  
                .Select(ab => new EventViewModel()
                {
                    Name = ab.Event.Name,
                    Start = ab.Event.Start.ToString("dd/MM/yyyy H:mm"),//?
                    Type = ab.Event.Type.Name,
                    Id = ab.Event.Id,
                    Organiser = ab.Event.Organiser.UserName,


                    //Owner = ab.Event.Owner.ToString(),
                    //CreatedOn = ab.Event.CreatedOn.ToString("dd/MM/yyyy H:mm"),

                    //fix names:
                    //copy "All" shape here from EventViewModel.cs:
                    //Name
                    //Start
                    //Type
                    //Id
                    //Organiser

                }).ToListAsync();
            return View(userEvents);
        }

        //"AddEventToProfile" button
        //replace "AddToCart" with "AddEventToProfile" button
        //replace "Cart" with "profileName" : Ctrl+H
        public async Task<IActionResult> Join(int id)//"AddToCart" Button
        {
            var eventToAdd = await _data
                .Events
                .FindAsync(id);
            if (eventToAdd == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();//!
            var entry = new EventParticipant()
            {
                EventId = eventToAdd.Id,
                HelperId  = currentUserId,//!
            };
            if (await _data.EventParticipants.ContainsAsync(entry))
            {
                return RedirectToAction("Joined", "Event");//!
            }
            await _data.EventParticipants.AddAsync(entry);
            await _data.SaveChangesAsync();
            return RedirectToAction("Joined", "Event");//!
        }

        //"RemoveEventFromProfile" button
        //replace "RemoveFromCart" with "RemoveEventFromProfile" button
        public async Task<IActionResult> Leave(int id)//"RemoveFromCart" Button
        {
            var eventId = id;
            var currentUser = GetUserId();//!
            var eventToRemove = await _data.Events.FindAsync(eventId);
            if (eventToRemove == null)
            {
                return BadRequest();
            }
            var entry = await _data.EventParticipants
            .FirstOrDefaultAsync(ab => ab.HelperId  == currentUser
            && ab.EventId == eventId);
            _data.EventParticipants.Remove(entry);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Event");//!
        }


        // Helper methods
        // Get Types//Извличане на списъка с категории от базата данни
        private IEnumerable<TypeViewModel> GetTypes()//*
            => _data
                .Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                });
        // Get currently logged-in user's Id//Извличане на Id на текущия потребител
        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}