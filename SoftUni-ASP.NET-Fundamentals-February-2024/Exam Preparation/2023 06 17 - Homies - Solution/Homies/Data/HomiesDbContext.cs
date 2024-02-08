using Homies.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Entities.Type;
namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>()
                .HasKey(e => new { e.EventId, e.HelperId});
            
            modelBuilder.Entity<EventParticipant>()
                .HasOne(e => e.Event)
                .WithMany()
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(e => e.Helper)
                .WithMany()
                .HasForeignKey(e => e.HelperId)
                .OnDelete(DeleteBehavior.NoAction);

            //if(false)
            //{
            //    modelBuilder.Entity<Event>()
            //            .HasOne(b => b.Type)
            //            .WithMany(c => c.Events)
            //        .HasForeignKey(t => t.TypeId)
            //        .OnDelete(DeleteBehavior.Restrict);
            //}


            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}