

// Use   //*   to remove "Category" everywhere if "type" doesn't exists



//Ctrl+H - Replace "Item" 1st with uppercase then lowercase////главни букви включени
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
//All,Add,Edit,Details,Cart2,AddToCart1,RemoveFromCart1
//copy URLs here:

//All,Add,Edit,Details,Team,AddToTeam,RemoveFromTeam

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Solution.Data;
using Solution.Data.Models;
using Solution.Models.Item;
using Solution.Models.Category;
namespace Solution.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly BazarDbContext _data;//replace BazarDbContext
        public ItemController(BazarDbContext data)//replace BazarDbContext
        {
            _data = data;
        }

        //"Add" button//Get
        public async Task<IActionResult> Add()//"Add" get
        {
           ItemFormModel itemModel = new ItemFormModel()
            {
                Categories = GetCategories()//If there is no "category" entity remove this line and leave it empty//*
            };
            return View(itemModel);
        }

        //Add,All,Edit:
        //Details sometimes:

        //"Add" button/Post
        [HttpPost]
        public async Task<IActionResult> Add(ItemFormModel itemModel)//"Add" post
        {
            if (!GetCategories().Any(e => e.Id == itemModel.CategoryId))//*
            {
                ModelState.AddModelError(nameof(itemModel.CategoryId), "Category does not exist!");
            }
            if (!ModelState.IsValid)
            {
                return View(itemModel);
            }
            string currentUserId = GetUserId();//!
            var itemToAdd = new Item()
            {
                CreatedOn = DateTime.Now,//delete if no Date needed in "All"
                OwnerId = currentUserId,//F2 - OwnerId
                Name1 = itemModel.Name1,

            
                //we skip/dont post this: adToEdit.Categories = model.Categories; 

                //Name = itemModel.Name,

                //fix names:
                //copy "Add" shape here:
               

            };
            await _data.Items.AddAsync(itemToAdd);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Item");//!
        }

        //"All" button
        //replace "All" with "AllItemsName" button
        public async Task<IActionResult> All()
        {
            var itemsToDisplay = await _data
                .Items
                .Select(e => new ItemViewModel()
                {
                    Name1 = e.Name1,


                    //Name = e.Name,
                    //CreatedOn = e.CreatedOn.ToString("dd/MM/yyyy H:mm"),

                    //fix names:
                    //copy shape here:


                }).ToListAsync();
            return View(itemsToDisplay);
        }

        //If "Edit" button exist//Get
        //replace "Edit" with "EditName" button
        public async Task<IActionResult> Edit(int id)//"Edit" get
        {
            var itemToEdit = await _data.Items.FindAsync(id);
            if (itemToEdit == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != itemToEdit.OwnerId)
            {
                return Unauthorized();
            }
            ItemFormModel itemModel = new ItemFormModel()
            {
                //Categories = GetCategories(),
                Name1 = itemToEdit.Name1,



                // Name = itemToEdit.Name,

                //fix names:
                //copy "Edit" shape here:


            };
            return View(itemModel);
        }

        //If "Edit" button exist//Post
        //replace "Edit" with "EditName" button
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ItemFormModel model)//"Edit" post
        {
            var itemToEdit = await _data.Items.FindAsync(id);
            if (itemToEdit == null)
            {
                return BadRequest();
            }
            string currentUser = GetUserId();
            if (currentUser != itemToEdit.OwnerId)//!
            {
                return Unauthorized();
            }
            if (!GetCategories().Any(e => e.Id == model.CategoryId))//*
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }
            itemToEdit.Name1 = model.Name1;


            
            //we skip/dont post this: adToEdit.Categories = model.Categories; 

            //itemToEdit.Name = model.Name;
            
            //fix names:
            //copy "Add" shape here:


            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Item");//!
        }

        //if "Details" button exists
        //"details" button in dashboard/not in myprofile//in myprofile only add/remove item
        //replace "Details" details "detailsButtonName"
        public async Task<IActionResult> Details(int id)//"Details" button
        {
            var itemDetails = await _data
               .Items
               .Where(e => e.Id == id)
               .Select(e => new ItemViewDetailsModel()
               {
                   name1 = e.Name1,


                   //name = e.Name,
                   //createdOn = e.CreatedOn.ToString("dd/mm/yyyy h:mm")

                   //fix names
                   //copy "Details" shape here:


               }).FirstOrDefaultAsync();
            if (itemDetails == null)
            {
                return BadRequest();
            }
            return View(itemDetails);
        }


        //"MyProfileName" button
        //replace "Cart" with "MyProfileName" button
        public async Task<IActionResult> Cart2()//"My Profile" button
        {
            string currentUserId = GetUserId();
            var userItems = await _data
                .Names1Names2//F2 - Names1Names2
                .Where(ab => ab.BuyerId == currentUserId)//F2 - BuyerId 
                .Select(ab => new ItemViewModel()
                {
                    Name1 = ab.Item.Name1,


                    //Owner = ab.Item.Owner.ToString(),
                    //CreatedOn = ab.Item.CreatedOn.ToString("dd/MM/yyyy H:mm"),

                    //fix names:
                    //copy "All" shape here:


                }).ToListAsync();
            return View(userItems);
        }

        //"AddItemToProfile" button
        //replace "AddToCart" with "AddItemToProfile" button
        //replace "Cart" with "profileName" : Ctrl+H
        public async Task<IActionResult> AddToCart1(int id)//"AddToCart" Button
        {
            var itemToAdd = await _data
                .Items
                .FindAsync(id);
            if (itemToAdd == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();//!
            var entry = new Name1Name2()
            {
                ItemId = itemToAdd.Id,
                BuyerId = currentUserId,//!
            };
            if (await _data.Names1Names2.ContainsAsync(entry))
            {
                return RedirectToAction("Cart2", "Item");//!
            }
            await _data.Names1Names2.AddAsync(entry);
            await _data.SaveChangesAsync();
            return RedirectToAction("Cart2", "Item");//!
        }

        //"RemoveItemFromProfile" button
        //replace "RemoveFromCart" with "RemoveItemFromProfile" button
        public async Task<IActionResult> RemoveFromCart1(int id)//"RemoveFromCart" Button
        {
            var itemId = id;
            var currentUser = GetUserId();//!
            var itemToRemove = await _data.Items.FindAsync(itemId);
            if (itemToRemove == null)
            {
                return BadRequest();
            }
            var entry = await _data.Names1Names2
            .FirstOrDefaultAsync(ab => ab.BuyerId == currentUser 
            && ab.ItemId == itemId);
            _data.Names1Names2.Remove(entry);
            await _data.SaveChangesAsync();
            return RedirectToAction("Cart2", "Item");//!
        }


        // Helper methods
        // Get Categories//Извличане на списъка с категории от базата данни
        private IEnumerable<CategoryViewModel> GetCategories()//*
            => _data
                .Categories
                .Select(t => new CategoryViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                });
         // Get currently logged-in user's Id//Извличане на Id на текущия потребител
        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}