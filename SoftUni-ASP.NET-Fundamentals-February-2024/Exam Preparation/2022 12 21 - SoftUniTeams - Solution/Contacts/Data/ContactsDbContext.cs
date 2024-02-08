using Contacts.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext<ApplicationUser>
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
            this.Database.Migrate();//add migrations
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUserContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserContact>()
                .HasKey(e => new { e.ApplicationUserId, e.ContactId });

            //builder.Entity<ApplicationUserContact>()
            //    .HasOne(e => e.ApplicationUser)
            //    .WithMany()
            //    .HasForeignKey(e => e.ApplicationUserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<ApplicationUserContact>()
            //    .HasOne(e => e.ApplicationUser)
            //    .WithMany()
            //    .HasForeignKey(e => e.ContactId)
            //    .OnDelete(DeleteBehavior.NoAction);



            //builder
            //   .Entity<Contact>()
            //   .HasData(new Contact()
            //   {
            //       Id = 1,
            //       FirstName = "Bruce",
            //       LastName = "Wayne",
            //       PhoneNumber = "+359881223344",
            //       Address = "Gotham City",
            //       Email = "imbatman@batman.com",
            //       Website = "www.batman.com"
            //   });
            base.OnModelCreating(builder);
        }
    }
}
           