// DbContext
//db3Context-DbSet
//dbw-DBContextWeb
using Solution.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Type = Solution.Data.Entities.Type;//sometimes needed
namespace Solution.Data
{
    public class LibraryDbContext : IdentityDbContext<User>//replace "User" if needed
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
             : base(options)
        {
            this.Database.Migrate();//add migrations
        }
        //db3Context-DbSet:
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UsersBooks { get; set; }
        //we dont add the User DbSet here!

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //dbw-DBContextWeb:

            modelBuilder.Entity<ItemUser>()
                .HasKey(e => new { e.UserId, e.ItemId });
                //Ако в UserBook има UserID и BookId значи 1ви вариант,ако едното от двете липсва значи 2-ри вариант,ако и двете липсват значи "нищо" не пишем

            //Често се използва
            //Ако изтриете запис, системата няма да предприеме никакви действия по отношение на свързаните записи. Тези свързани записи остават в базата данни без да бъдат променени или изтрити,дори ако връзката им вече не е валидна.
            modelBuilder.Entity<ItemUser>()
               .HasOne(e => e.Item)
               .WithMany()
               .HasForeignKey(e => e.ItemId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ItemUser>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);





            //По-рядко
            //Обикновенно става въпрост за "категория"
            //Ако опитате да изтриете запис, който е свързан с други записи, системата ще даде грешка              и няма да позволи изтриването. Не изтрива никакви записи.
            if (false)
            {
                builder
                  .Entity<Book>()
                  .HasOne(b => b.Category)
                  .WithMany(c => c.Books)
                  .HasForeignKey(t => t.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
            }








            //seed data
            builder
                .Entity<Book>()
                .HasData(new Book()
                {
                    Id = 5,
                    Title = "Lorem Ipsum",
                    Author = "Dolor Sit",
                    ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    CategoryId = 1,
                    Rating = 9.5m
                });

            builder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Action"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Biography"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Children"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Crime"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Fantasy"
                });
                
            base.OnModelCreating(builder);
        }
    }
}