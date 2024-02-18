// DbContext
//dbset
//dbw-DBContextWeb

//using Type = Solution.Data.Entities.Type; //sometimes needed
namespace Solution.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }
        //dbset
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemUser> ItemsUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
                builder.Entity<Book>()
                  .HasOne(b => b.Category)
                  .WithMany(c => c.Books)
                  .HasForeignKey(t => t.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
            }








            //seed data
            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}