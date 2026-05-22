using Informatique_task.Data;
using Informatique_task.Enums;
using Informatique_task.Models;
using Informatique_task.Models.TaskManagementSystem.Models;
using Informatique_task.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Informatique_task.Seed
{
    public class DbSeeder
    {
        public static void Seed()
        {
            using (var db = new ApplicationDbContext()) {

                if (db.Users.Any())
                    return;

                var admin = new User
                {
                    Username = "admin",
                    PasswordHash = PasswordService.Hash("Admin@123"),
                    FullName = "System Admin",
                    Role = UserRole.Admin,
                    CreatedAt = DateTime.Now
                };

                db.Users.Add(admin);

                // MEMBERS
                var user1 = new User
                {
                    Username = "ahmed",
                    PasswordHash = PasswordService.Hash("123456"),
                    FullName = "Ahmed Ali",
                    Role = UserRole.Member,
                    CreatedAt = DateTime.Now
                };

                var user2 = new User
                {
                    Username = "mona",
                    PasswordHash = PasswordService.Hash("123456"),
                    FullName = "Mona Hassan",
                    Role = UserRole.Member,
                    CreatedAt = DateTime.Now
                };

                db.Users.Add(user1);
                db.Users.Add(user2);

                db.SaveChanges();

                // TASKS
                db.Tasks.Add(new TaskItem
                {
                    Title = "Prepare Report",
                    Description = "Monthly report",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now,
                    AssignedDate = DateTime.Now.AddDays(-4),
                    CreatedById = admin.Id,
                    AssignedToId = user1.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Fix UI Bug",
                    Description = "Navbar issue",
                    Status = TaskStatus.InProgress,
                    CreatedDate = DateTime.Now,
                    AssignedDate = DateTime.Now.AddDays(-2),
                    CreatedById = admin.Id,
                    AssignedToId = user2.Id
                });

                db.SaveChanges();

            }
        }
    }
}