using Library.Data;
using Library.Data.Entities;
using Library.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly LibraryDbContext data;
        public BooksController(LibraryDbContext data)
            => this.data = data;

        public IActionResult Add()
        {
            BookFormModel bookModel = new BookFormModel()
            {
                Categories = GetCategories()
            };

            return View(bookModel);
        }

        [HttpPost]

        public IActionResult Add(BookFormModel bookModel)
        {
            if (!GetCategories().Any(b => b.Id == bookModel.CategoryId))
            {
                this.ModelState.AddModelError(nameof(bookModel.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                bookModel.Categories = GetCategories();

                return View(bookModel);
            }

            var book = new Book()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                ImageUrl = bookModel.Url,
                Rating = bookModel.Rating,
                CategoryId = bookModel.CategoryId,
            };

            this.data.Books.Add(book);
            this.data.SaveChanges();

            var boards = this.data.Categories;

            return RedirectToAction("All", "Books");
        }

        public IActionResult All()
        {
            var allBooks = new AllBooksQueryModel()
            {
                Books = this.data.Books
                    .Select(b => new AllBookViewModel()
                    {
                        Id = b.Id,
                        ImageUrl = b.ImageUrl,
                        Title = b.Title,
                        Author = b.Author,
                        Rating = b.Rating.ToString(),
                        Category = b.Category.Name,
                        Description = b.Description
                    })
            };

            return View(allBooks);
        }

        [HttpPost]
        public IActionResult AddToCollection(int id)
        {
            var book = this.data.Books.Find(id);

            if (book == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var entry = new ApplicationUserBook()
            {
                BookId = book.Id,
                ApplicationUserId = currentUserId
                
            };

            if (this.data.UsersBooks.Contains(entry))
            {
                return RedirectToAction("All", "Books");
            }

            this.data.UsersBooks.Add(entry);
            this.data.SaveChanges();
            return RedirectToAction("All", "Books");
        }


        [HttpPost]
        public IActionResult RemoveFromCollection(int id)
        {
            var bookId = id;
            var currentUser = GetUserId();
            var book = this.data.Books.Find(id);

            if (book == null)
            {
                return BadRequest();
            }

            var entry = this.data.UsersBooks.FirstOrDefault(um => um.ApplicationUserId == currentUser && um.BookId == id);
            this.data.UsersBooks.Remove(entry);
            this.data.SaveChanges();

            return RedirectToAction("Mine", "Books");
        }


        public IActionResult Mine()
        {
            string currentUserId = GetUserId();
            var currentUser = this.data.Users.Find(currentUserId);

            var allBooks = new AllBooksQueryModel()
            {
                Books = this.data.UsersBooks
                    .Where(um => um.ApplicationUserId == currentUserId)
                    .Select(um => new AllBookViewModel()
                    {
                        Id = um.Book.Id,
                        Title = um.Book.Title,
                        ImageUrl = um.Book.ImageUrl,
                        Rating = um.Book.Rating.ToString(),
                        Author = um.Book.Author,
                        Category = um.Book.Category.Name,
                        Description = um.Book.Description
                    })
            };

            return View(allBooks);
        }

        private string GetUserId()
           => this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<BookCategoryModel> GetCategories()
         => this.data
             .Categories
             .Select(b => new BookCategoryModel()
             {
                 Id = b.Id,
                 Name = b.Name
             });
    }
}