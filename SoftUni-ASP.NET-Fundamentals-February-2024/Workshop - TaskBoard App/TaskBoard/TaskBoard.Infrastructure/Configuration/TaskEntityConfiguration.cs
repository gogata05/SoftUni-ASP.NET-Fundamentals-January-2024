namespace TaskBoard.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Task = Data.Models.Task;

    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
               .HasOne(t => t.Board)
               .WithMany(b => b.Tasks)
               .HasForeignKey(t => t.BoardId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {                  
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = "07bf414a-5aba-4b74-b0b8-aa9c2f0d1609",
                    BoardId = 1
                },
                new Task()
                {                    
                    Title = "Android Client App",
                    Description = "Create Android client App for the RESTful TaskBoard service",
                    CreatedOn = DateTime.UtcNow.AddMonths(-5),
                    OwnerId = "07bf414a-5aba-4b74-b0b8-aa9c2f0d1609",
                    BoardId = 1
                },
                new Task()
                {                    
                    Title = "Desktop Client App",
                    Description = "Create Desktop client App for the RESTful TaskBoard service",
                    CreatedOn = DateTime.UtcNow.AddMonths(-1),
                    OwnerId = "07bf414a-5aba-4b74-b0b8-aa9c2f0d1609",
                    BoardId = 2
                },
                new Task()
                {                  
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding tasks",
                    CreatedOn = DateTime.UtcNow.AddYears(-1),
                    OwnerId = "fd276457-f3b5-4f2a-a452-11a81bc8764c",
                    BoardId = 3
                }
            };

            return tasks;
        }
    }
    
}
