

// Use   //*   to remove "Category" everywhere if "type" doesn't exists
//"Details", "Edit", "Category" not always exists
//namespace/usings?





//Ctrl+H - Replace "Item" 1st with uppercase then lowercase
//0.1.uppercase
//0.2.lowercase
//1.1: replace "Item" with the "Name" Ctrl+H//all 4 versions: Item,item,Item...,item...

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



//copy URLs here:

//All,Cart,Add,Edit,AddToCart,RemoveFromCart

namespace Library.Controllers
{
    [Authorize]// Позволява достъп само на упълномощени потребители
    public class ItemController : Controller
    {
        private readonly LibraryDbContext data;//replace LibraryDbContext
        public ItemController(LibraryDbContext data)//replace LibraryDbContext 
        {
            this.data = data;
        }
        
        //Add button//Get
        public IActionResult Add()
        {
            ItemFormModel itemModel = new ItemFormModel()
            {
                Categories = GetCategories()//If there is no "category" entity remove this line and leave it empty//*
            };
            return View(itemModel);
        }

        //Add,All,Edit:
        //Details sometimes:

        //Add button/Post
        [HttpPost]
        public IActionResult Add(ItemFormModel itemModel)
        {
            //Проверка за валидност на модела и валидност на избраната категория
            if (!GetCategories().Any(b => b.Id == itemModel.CategoryId))//Проверка за съществуваща категория//*
            {
                this.ModelState.AddModelError(nameof(itemModel.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)//Проверка за валидност на модела
            {
                itemModel.Categories = GetCategories();

                return View(itemModel);//Връщане на изгледа с модела
            }
            //string currentUserId = GetUserId();//Вземане на Id на текущия потребител
            var item = new Item()
            {
                Title = itemModel.Title,
                Author = itemModel.Author,
                Description = itemModel.Description,
                ImageUrl = itemModel.Url,
                Rating = itemModel.Rating,
                CategoryId = itemModel.CategoryId,//*
                //CreatedOn = DateTime.Now,//!
                //OwnerId = currentUserId,//!

                //fix names:
                //copy shape here:


            };
            // Добавяне на итема към базата данни и запазване на промените
            this.data.Items.Add(item);
            this.data.SaveChanges();
            var boards = this.data.Categories;
            return RedirectToAction("All", "Items");// Пренасочване към списъка с итеми
        }

        //"All" button
        //replace "All" with "AllItemsName" button
        public IActionResult All()
        {
            var allItems = new AllItemsQueryModel()//създаване на dashboard
            {
                Items = this.data.Items
                    .Select(b => new ItemDetailsViewModel()
                    {
                        Id = b.Id,
                        ImageUrl = b.ImageUrl,
                        Title = b.Title,
                        Author = b.Author,
                        Rating = b.Rating.ToString(),
                        Category = b.Category.Name,
                        Description = b.Description,
                        //CreatedOn = e.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                        
                        //fix names:
                        //copy shape here:


                    })
            };
            return View(allItems);
        }

        //If "Edit" button exist//Get
        //replace "Edit" with "EditName" button 
        public IActionResult Edit(int id)
        {
            var item = _context.Items.Find(id);// Търсене на итема по Id
            if (item == null)// Проверка дали итема не е намерен
            {
                return BadRequest();// Грешка: Заявката е невалидна
            }
            // string currentUserId = GetUserId();//Вземане на Id на текущия потребител

            // if (currentUserId != itemToEdit.OwnerId)// Проверка дали текущият потребител е собственик на итема
            // {
            //     return Unauthorized();// Грешка: Неоторизиран достъп
            // }
            ItemFormModel itemModel = new ItemFormModel()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                PhoneNumber = item.PhoneNumber,
                Website = item.Website,
                Email = item.Email
                //CategoryId = itemToEdit.CategoryId,//*
                //Categories = GetCategories(),//list of categories options

                //fix names:
                //copy shape here:


            };
            return View(itemModel);
        }

        //If "Edit" button exist//Post
        //replace "Edit" with "EditName" button
        [HttpPost]//?
        public IActionResult Edit(int id, ItemFormModel model)
        {
            var itemToEdit = _context.Items.FindAsync(id);// Търсене на итема по Id
            if (itemToEdit == null)// Проверка дали итема не е намерена
            {
                return BadRequest();// Грешка: Заявката е невалидна
            }
            string currentUser = GetUserId();// Вземане на Id на текущия потребител
            if (currentUser != itemToEdit.OwnerId)// Проверка дали текущият потребител е собственик на итема
            {
                return Unauthorized();// Грешка: Неоторизиран достъп
            }
            if (!GetCategories().Any(e => e.Id == model.CategoryId))// Проверка дали категорията съществува//*
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");// Грешка: Категорията не съществува
            }
            itemToEdit.Name = model.Name;
            itemToEdit.Description = model.Description;
            itemToEdit.ImageUrl = model.ImageUrl;
            itemToEdit.Price = model.Price;
            itemToEdit.CategoryId = model.CategoryId;//*
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Item");
        }

        //Details//if exists
        //details in dashboard/not in myprofile//in myprofile only add/remove item
        public IActionResult Details(int id)
        {
            var itemDetails = _context
               .Items
               .Where(e => e.Id == id)
               .Select(e => new ItemViewDetailsModel()
               {
                   id = e.Id,
                   name = e.Name,
                   start = e.Start.ToString("dd/mm/yyyy h:mm"),
                   end = e.End.ToString("dd/mm/yyyy h:mm"),
                   organiser = e.Organiser.Username,
                   type = e.Type.Name,
                   description = e.Description,
                   createdOn = e.CreatedOn.ToString("dd/mm/yyyy h:mm")
               }).FirstOrDefault();
            if (itemDetails == null)
            {
                return BadRequest();
            }
            return View(itemDetails);
        }

        //"MyProfileName" button
        //replace "Cart" with "MyProfileName" button
        public IActionResult Profile()//"MyBooks" button
        {
            string currentUserId = GetUserId();
            var currentUser = this.data.Users.Find(currentUserId);
            var allItems = new AllItemsQueryModel()
            {
                Items = this.data.UsersItems
                    .Where(um => um.CollectorId == currentUserId)
                    .Select(um => new ItemDetailsViewModel()
                    {
                        Id = um.Item.Id,
                        Title = um.Item.Title,
                        ImageUrl = um.Item.ImageUrl,
                        Rating = um.Item.Rating.ToString(),
                        Author = um.Item.Author,
                        Category = um.Item.Category.Name,
                        Description = um.Item.Description

                       //fix names:
                       //copy shape here:

                       
                    })
            };
            return View(allItems);
        }

        //Add to my Profile
        [HttpPost]
        public IActionResult AddToCollection(int id)//"AddToCollection" button
        {
            var item = this.data.Items.Find(id);
            if (item == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            var entry = new UserItem()
            {
                ItemId = item.Id,
                CollectorId = currentUserId
            };
            if (this.data.UsersItems.Contains(entry))
            {
                return RedirectToAction("All", "Items");
            }
            this.data.UsersItems.Add(entry);
            this.data.SaveChanges();
            return RedirectToAction("All", "Items");
        }

        //Remove from Profile
        [HttpPost]
        public IActionResult RemoveFromCollection(int id)//"RemoveFromCollection" button
        {
            var itemId = id;// Id на итема
            var currentUser = GetUserId();// Вземане на Id на текущия потребител
            var item = this.data.Items.Find(id);// Търсене на итема по Id
            if (item == null)// Проверка дали итема не е намерен
            {
                return BadRequest();// Грешка: Заявката е невалидна
            }
            var entry = this.data.UsersItems.FirstOrDefault(um => um.CollectorId == currentUser && um.ItemId == id);
            this.data.UsersItems.Remove(entry);// Търсене на итема в профила
            this.data.SaveChanges();// Премахване на итема от профила
            return RedirectToAction("All", "Items");// Пренасочване към всички итеми
        }


        // Helper methods
        // Get Categories//Извличане на списъка с категории от базата данни
        private IEnumerable<ItemCategoryModel> GetCategories()//*
         => this.data
             .Categories
             .Select(b => new ItemCategoryModel()
             {
                 Id = b.Id,
                 Name = b.Name
             });
        // Get currently logged-in user's Id//Извличане на Id на текущия потребител
        private string GetUserId()
           => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}