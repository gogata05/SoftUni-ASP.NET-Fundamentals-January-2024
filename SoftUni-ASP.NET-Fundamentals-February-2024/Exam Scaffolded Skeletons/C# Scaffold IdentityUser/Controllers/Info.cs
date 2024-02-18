//its not used//only for information




// Use   //*   to remove "Category" everywhere if "type" doesn't exists

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


//2: check problem Description redirections


namespace SoftUniBazar.Controllers//change namespace
{
    [Authorize]// Позволява достъп само на упълномощени потребители
    public class ItemController : Controller
    {
        private readonly BazarDbContext _data;
        public ItemController(BazarDbContext data)
        {
            _data = data;//private
        }

        //Add
        public async Task<IActionResult> Add()
        {
           ItemFormModel itemModel = new ItemFormModel()
            {
                Categories = GetCategories()//ItemFormModel Categories List = GetCategories method down below
                //Зареждане на списъка с категории от метода GetCategories//*
            };
            return View(itemModel);
        }

        //Add,All,Edit:
        //Details sometimes:

        //Add
        [HttpPost]
        public async Task<IActionResult> Add(ItemFormModel itemModel)
        {
            //Проверка за валидност на модела и валидност на избраната категория
            if (!GetCategories().Any(e => e.Id == itemModel.CategoryId))//Проверка за съществуваща категория//*
            {
                ModelState.AddModelError(nameof(itemModel.CategoryId), "Category does not exist!");
            }
            if (!ModelState.IsValid)//Проверка за валидност на модела
            {
                return View(itemModel);//Връщане на изгледа с модела
            }
            string currentUserId = GetUserId();//Вземане на Id на текущия потребител
            var itemToAdd = new Item()//Създаване на итем
            {
                Name = itemModel.Name,
                Description = itemModel.Description,
                ImageUrl = itemModel.ImageUrl,
                Price = itemModel.Price,
                CategoryId = itemModel.CategoryId,//*
                CreatedOn = DateTime.Now,//!
                OwnerId = currentUserId,//!
                //fix names:
                //copy shape here:


            };
            // Добавяне на итема към базата данни и запазване на промените
            await _data.Items.AddAsync(ItemToAdd);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Item");// Пренасочване към списъка с итеми
        }

        //All
        public async Task<IActionResult> All()
        {
            var itemsToDisplay = await _data//създаване на dashboard
                .Items
                .Select(e => new ItemViewModel()
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
                    //copy shape here:


                }).ToListAsync();
            return View(itemsToDisplay);
        }

        //If "Edit" button exist
        //replace "Edit" with "EditName" button
        public async Task<IActionResult> Edit(int id)//"Edit" button
        {
            var itemToEdit = await _data.Items.FindAsync(id);// Търсене на итема по Id
            if (itemToEdit == null)// Проверка дали итема не е намерен
            {
                return BadRequest();// Грешка: Заявката е невалидна
            }
            string currentUserId = GetUserId();//Вземане на Id на текущия потребител
            if (currentUserId != itemToEdit.OwnerId)// Проверка дали текущият потребител е собственик на итема
            {
                return Unauthorized();// Грешка: Неоторизиран достъп
            }
            ItemFormModel itemModel = new ItemFormModel()// Модел за редакция на итем
            {
                Name = itemToEdit.Name,
                Description = itemToEdit.Description,
                ImageUrl = itemToEdit.ImageUrl,
                Price = itemToEdit.Price,
                CategoryId = itemToEdit.CategoryId,//*
                Categories = GetCategories(),//list of categories options
                //fix names:
                //copy shape here:


            };
            return View(itemModel);
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
                //fix names
                //copy shape here:


                   id = e.Id,
                   name = e.Name,
                   start = e.Start.ToString("dd/mm/yyyy h:mm"),
                   end = e.End.ToString("dd/mm/yyyy h:mm"),
                   organiser = e.Organiser.Username,
                   type = e.Type.Name,
                   description = e.Description,
                   createdOn = e.CreatedOn.ToString("dd/mm/yyyy h:mm")
               }).FirstOrDefaultAsync();
            if (itemDetails == null)
            {
                return BadRequest();
            }
            return View(itemDetails);
        }

        //HttpPost Edit#2
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ItemFormModel model)//HttpPost Edit#2
        {
            var itemToEdit = await _data.Items.FindAsync(id);// Търсене на итема по Id
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

        //My Profile
        //replace "Cart" with "MyProfileName" button
        public async Task<IActionResult> Cart()//"My Profile" button
        {
            string currentUserId = GetUserId();// Вземане на Id на текущия потребител
            var userItems = await _data// Получаване на итемите на потребителя
                .Names1Names2
                .Where(ab => ab.BuyerId == currentUserId)
                .Select(ab => new ItemViewModel()// Изграждане на модел за итем
                {
                    Name = ab.Item.Name,
                    ImageUrl = ab.Item.ImageUrl,
                    CreatedOn = ab.Item.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                    Category = ab.Item.Category.Name,
                    Description = ab.Item.Description,
                    Price = ab.Item.Price,
                    Owner = ab.Item.Owner.ToString()
                    Id = ab.Item.Id,//!
                    //fix names:
                    //copy shape here:


                }).ToListAsync();
            return View(userItems);
        }

        //AddToProfile
        //replace "AddToCart" with "AddItemToProfile" button
        //replace "Cart" with "profileName" : Ctrl+H
        public async Task<IActionResult> AddToCart(int id)//"AddToCart" Button
        {
            var itemToAdd = await _data// Търсене на итема по Id
                .Items
                .FindAsync(id);
            if (itemToAdd == null)
            {
                return BadRequest();// Грешка: Заявката е невалидна
            }
            string currentUserId = GetUserId();// Вземане на Id на текущия потребител
            var entry = new Name1Name2()// Създаване на запис за итема в профила на потребителя
            {
                ItemId = itemToAdd.Id,// Id на итема
                BuyerId = currentUserId,// Id на потребителя
            };
            if (await _data.Names1Names2.ContainsAsync(entry))// Проверка дали итема вече е в профила
            {
                return RedirectToAction("Cart", "Item");// Пренасочване към профила
            }
            await _data.Names1Names2.AddAsync(entry);// Пренасочване към профила
            await _data.SaveChangesAsync();// Запазване на промените
            return RedirectToAction("Cart", "Item");// Пренасочване към профила
        }

        //RemoveFromProfile
        //replace "RemoveFromCart" with "RemoveItemFromProfile" button
        public async Task<IActionResult> RemoveFromCart(int id)//"RemoveFromCart" Button
        {
            var itemId = id;// Id на итема
            var currentUser = GetUserId();// Вземане на Id на текущия потребител
            var itemToRemove = _data.Items.FindAsync(itemId);// Търсене на итема по Id
            if (itemToRemove == null)// Проверка дали итема не е намерен
            {
                return BadRequest();// Грешка: Заявката е невалидна
            }
            var entry = await _data.Names1Names2.FirstOrDefaultAsync(ab => ab.BuyerId == currentUser && ab.ItemId == itemId);// Търсене на итема в профила
            _data.Names1Names2.Remove(entry);// Премахване на итема от профила
            await _data.SaveChangesAsync();// Запазване на промените
            return RedirectToAction("All", "Item");// Пренасочване към всички итеми
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