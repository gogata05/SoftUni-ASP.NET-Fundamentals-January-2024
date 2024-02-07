

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

//1.8: replace "AdBuyers" with the "AdBuyer" Ctrl+H//ManyToManyEntityName//careful
//1.9: replace "AdBuyer" with the "AdBuyer" Ctrl+H//ManyToManyEntityName//careful




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
//All,Add,Edit,Details,Cart,AddToCart,RemoveFromCart1
//copy URLs here:

//All,Add,Edit,Details,Team,AddToTeam,RemoveFromTeam


using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Entities;
using SoftUniBazar.Models.Ad;
using SoftUniBazar.Models.Category;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext _data;//replace BazarDbContext
        public AdController(BazarDbContext data)//replace BazarDbContext
        {
            _data = data;
        }

        //"Add" button//Get
        public async Task<IActionResult> Add()//"Add" get
        {
            AdFormModel adModel = new AdFormModel()
            {
                Categories = GetCategories()//If there is no "category" entity remove this line and leave it empty//*
            };
            return View(adModel);
        }

        //Add,All,Edit:
        //Details sometimes:

        //"Add" button/Post
        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel adModel)//"Add" post
        {
            if (!GetCategories().Any(e => e.Id == adModel.CategoryId))//*
            {
                ModelState.AddModelError(nameof(adModel.CategoryId), "Category does not exist!");
            }
            if (!ModelState.IsValid)
            {
                return View(adModel);
            }
            string currentUserId = GetUserId();//!
            var adToAdd = new Ad()
            {
                OwnerId = currentUserId,//F2 - OwnerId
                Name = adModel.Name,
                ImageUrl = adModel.ImageUrl,
                CreatedOn = DateTime.Now,
                CategoryId = adModel.CategoryId,
                Price = adModel.Price,
                Description = adModel.Description,


                //we skip/dont post this: model.Categories; 

                //Name = adModel.Name,

                //fix names:
                //copy "Add" shape here from ItemFormModel.cs:
                //Model.Name
                //Model.Description
                //Model.ImageUrl
                //Model.Price
                //Model.CategoryId
                //Model.Categories

            };
            await _data.Ads.AddAsync(adToAdd);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Ad");//!
        }

        //"All" button
        //replace "All" with "AllAdsName" button
        public async Task<IActionResult> All()
        {
            var adsToDisplay = await _data
                .Ads
                .Select(e => new AdViewModel()
                {
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    CreatedOn = e.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                    Category = e.Category.Name,
                    Description = e.Description,
                    Price = e.Price,
                    Owner = e.Owner.UserName,
                    Id = e.Id,

                    //fix names:
                    //copy shape here from AdViewModel.cs:
                    //a.Name
                    //a.ImageUrl
                    //a.CreatedOn
                    //a.Category
                    //a.Description
                    //a.Price
                    //a.Owner
                    //a.Id

                }).ToListAsync();
            return View(adsToDisplay);
        }

        //If "Edit" button exist//Get
        //replace "Edit" with "EditName" button
        public async Task<IActionResult> Edit(int id)//"Edit" get
        {
            var adToEdit = await _data.Ads.FindAsync(id);
            if (adToEdit == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != adToEdit.OwnerId)
            {
                return Unauthorized();
            }
            AdFormModel adModel = new AdFormModel()
            {
                Categories = GetCategories(),
                Name = adToEdit.Name,
                Description = adToEdit.Description,
                ImageUrl = adToEdit.ImageUrl,
                Price = adToEdit.Price,
                CategoryId = adToEdit.CategoryId,


                //fix names:
                //copy "Edit" shape here from AdFormModel.cs:
                //Model.Name
                //Model.Description
                //Model.ImageUrl
                //Model.Price
                //Model.CategoryId
                //Model.Categories

            };
            return View(adModel);
        }

        //If "Edit" button exist//Post
        //replace "Edit" with "EditName" button
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdFormModel model)//"Edit" post
        {
            var adToEdit = await _data.Ads.FindAsync(id);
            if (adToEdit == null)
            {
                return BadRequest();
            }
            string currentUser = GetUserId();
            if (currentUser != adToEdit.OwnerId)//!
            {
                return Unauthorized();
            }
            if (!GetCategories().Any(e => e.Id == model.CategoryId))//*
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }
            adToEdit.Name = model.Name;
            adToEdit.Description = model.Description;
            adToEdit.ImageUrl = model.ImageUrl;
            adToEdit.Price = model.Price;
            adToEdit.CategoryId = model.CategoryId;

            //we skip/dont post this: model.Categories; 

            //fix names:
            //copy "Edit" shape here from AdFormModel.cs:
            //Model.Name
            //Model.Description
            //Model.ImageUrl
            //Model.Price
            //Model.CategoryId
            //Model.Categories


            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Ad");//!
        }


        //"MyProfileName" button
        //replace "Cart" with "MyProfileName" button
        public async Task<IActionResult> Cart()//"My Profile" button
        {
            string currentUserId = GetUserId();
            var userAds = await _data
                .AdBuyers//F2 - AdBuyers
                .Where(ab => ab.BuyerId == currentUserId)//F2 - BuyerId 
                .Select(ab => new AdViewModel()
                {
                    Name = ab.Ad.Name,
                    ImageUrl = ab.Ad.ImageUrl,
                    CreatedOn = ab.Ad.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                    Category = ab.Ad.Category.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price,
                    Owner = ab.Ad.Owner.UserName,
                    Id = ab.Ad.Id,

                    //Owner = ab.Ad.Owner.ToString(),
                    //CreatedOn = ab.Ad.CreatedOn.ToString("dd/MM/yyyy H:mm"),

                    //fix names:
                    //copy "All" shape here from AdViewModel.cs:
                    //a.Name
                    //a.ImageUrl
                    //a.CreatedOn
                    //a.Category
                    //a.Description
                    //a.Price
                    //a.Owner
                    //a.Id

                }).ToListAsync();
            return View(userAds);
        }

        //"AddAdToProfile" button
        //replace "AddToCart" with "AddAdToProfile" button
        //replace "Cart" with "profileName" : Ctrl+H
        public async Task<IActionResult> AddToCart(int id)//"AddToCart" Button
        {
            var adToAdd = await _data
                .Ads
                .FindAsync(id);
            if (adToAdd == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();//!
            var entry = new AdBuyer()
            {
                AdId = adToAdd.Id,
                BuyerId = currentUserId,//!
            };
            if (await _data.AdBuyers.ContainsAsync(entry))
            {
                return RedirectToAction("Cart", "Ad");//!
            }
            await _data.AdBuyers.AddAsync(entry);
            await _data.SaveChangesAsync();
            return RedirectToAction("Cart", "Ad");//!
        }

        //"RemoveAdFromProfile" button
        //replace "RemoveFromCart" with "RemoveAdFromProfile" button
        public async Task<IActionResult> RemoveFromCart(int id)//"RemoveFromCart" Button
        {
            var adId = id;
            var currentUser = GetUserId();//!
            var adToRemove = await _data.Ads.FindAsync(adId);
            if (adToRemove == null)
            {
                return BadRequest();
            }
            var entry = await _data.AdBuyers
            .FirstOrDefaultAsync(ab => ab.BuyerId == currentUser
            && ab.AdId == adId);
            _data.AdBuyers.Remove(entry);
            await _data.SaveChangesAsync();
            return RedirectToAction("Cart", "Ad");//!
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