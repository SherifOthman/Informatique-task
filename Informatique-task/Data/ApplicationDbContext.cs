using Informatique_task.Data.Configurations;
using Informatique_task.Models;
using Informatique_task.Models.TaskManagementSystem.Models;
using System.Data.Entity;


namespace Informatique_task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskItemConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}