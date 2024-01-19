

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

using Solution.Data;
using Solution.Data.Entities;
using Solution.Models.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Solution.Controllers
{
    [Authorize]
    public class ItemController : Controller//името на класа - мн. или ед.число взависимост от LibraryDbContext
    {
        private readonly LibraryDbContext _data;//replace BazarDbContext
        public ItemController(LibraryDbContext data)//replace BazarDbContext
        {
            _data = data;
        }
        
        //"Add" button//Get
        public IActionResult Add()//"Add" get
        {
            ItemFormModel itemModel = new ItemFormModel()
            {
                Categories = GetCategories()//If there is no "category" entity remove this line and leave it empty//*
            };
            return View(itemModel);
        }

        //Add,All,Edit
        //Details sometimes

        //"Add" button/Post
        [HttpPost]
        public IActionResult Add(ItemFormModel itemModel)//"Add" post
        {
            if (!GetCategories().Any(x => x.Id == itemModel.CategoryId))//*
            {
                this.ModelState.AddModelError(nameof(itemModel.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                itemModel.Categories = GetCategories();//If there is no "category" entity remove this line and leave it empty//*
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
            _data.Items.Add(itemToAdd);
            _data.SaveChanges();
            return RedirectToAction("All", "Item");//!
        }

        //"All" button
        //replace "All" with "AllItemsName" button
        public IActionResult All()
        {
            var allItems = new AllItemsQueryModel()
            {
                Items = _data.Items
                    .Select(x => new ItemViewModel()
                    {
                    Name1 = x.Name1,


                    //Name = x.Name,
                    //CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy H:mm"),

                    //fix names:
                    //copy shape here:


                    })
            };
            return View(allItems);
        }

        //If "Edit" button exist//Get
        //replace "Edit" with "EditName" button
        public IActionResult Edit(int id)//"Edit" get
        {
            var itemToEdit = _data.Items.Find(id);
            if (itemToEdit == null)
            {
                return BadRequest();
            }
            // string currentUserId = GetUserId();
            // if (currentUserId != itemToEdit.OwnerId)
            // {
            //     return Unauthorized();
            // }
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
        public IActionResult Edit(int id, ItemFormModel model)//"Edit" post
        {
            var itemToEdit = _data.Items.Find(id);
            if (itemToEdit == null)
            {
                return BadRequest();
            }
            // string currentUser = GetUserId();
            // if (currentUser != itemToEdit.OwnerId)
            // {
            //     return Unauthorized();
            // }
            if (!GetCategories().Any(x => x.Id == model.CategoryId))//*
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }
            itemToEdit.Name1 = model.Name1;


            
            //we skip/dont post this: adToEdit.Categories = model.Categories; 

            //itemToEdit.Name = model.Name;
            
            //fix names:
            //copy "Add" shape here:


            _data.SaveChanges();//its a sync! why await??? maybe _
            return RedirectToAction("All", "Item");//!
        }

        //if "Details" button exists
        //"details" button in dashboard/not in myprofile//in myprofile only add/remove item
        //replace "Details" details "detailsButtonName"
        public IActionResult Details(int id)//"Details" button
        {
            var itemDetails = _data
               .Items
               .Where(x => x.Id == id)
               .Select(x => new ItemViewDetailsModel()
               {
                   name1 = x.Name1,


                   //name = x.Name,
                   //createdOn = x.CreatedOn.ToString("dd/mm/yyyy h:mm")

                   //fix names
                   //copy "Details" shape here:


               }).FirstOrDefault();
            if (itemDetails == null)
            {
                return BadRequest();
            }
            return View(itemDetails);
        }


        //"MyProfileName" button
        //replace "Cart" with "MyProfileName" button
        public IActionResult Cart2()//"My Profile" button
        {
            string currentUserId = GetUserId();
            var currentUser = _data.Users.Find(currentUserId);
            var allItems = new AllItemsQueryModel()
            {
                Items = _data.UsersItems
                    .Where(x => x.CollectorId == currentUserId)//F2 - CollectorId
                    .Select(x => new ItemViewModel()
                    {
                        Name1 = x.Item.Name1,
                        //Owner = x.Item.Owner.ToString(),
                        //CreatedOn = x.Item.CreatedOn.ToString("dd/MM/yyyy H:mm"),

                        //fix names:
                        //copy "All" shape here:


                    })
            };
            return View(allItems);
        }

        //"AddItemToProfile" button
        //replace "AddToCart" with "AddItemToProfile" button
        //replace "Cart" with "profileName" : Ctrl+H
        [HttpPost]
        public IActionResult AddToCart1(int id)//"AddToCart" button
        {
            var item = _data.Items.Find(id);
            if (item == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();//!
            var entry = new UserItem()
            {
                ItemId = item.Id,
                CollectorId = currentUserId//!
            };
            if (_data.UsersItems.Contains(entry))
            {
                return RedirectToAction("Cart2", "Item");//!
            }
            _data.UsersItems.Add(entry);
            _data.SaveChanges();
            return RedirectToAction("Cart2", "Item");//!
        }

        //"RemoveItemFromProfile" button
        //replace "RemoveFromCart" with "RemoveItemFromProfile" button
        [HttpPost]
        public IActionResult RemoveFromCart1(int id)//"RemoveFromCart" button
        {
            var itemId = id;
            var currentUserId = GetUserId();//!
            var item = _data.Items.Find(id);
            if (item == null)
            {
                return BadRequest();
            }
            var entry = _data.UsersItems.FirstOrDefault(x => x.CollectorId == currentUserId && x.ItemId == id);
            _data.UsersItems.Remove(entry);
            _data.SaveChanges();
            return RedirectToAction("Cart2", "Item");//!
        }


        // Helper methods
        // Get Categories//Извличане на списъка с категории от базата данни
        private IEnumerable<ItemCategoryModel> GetCategories()//*
         => _data
             .Categories
             .Select(x => new ItemCategoryModel()
             {
                 Id = x.Id,
                 Name = x.Name
             });
        // Get currently logged-in user's Id//Извличане на Id на текущия потребител
        private string GetUserId()
           => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}