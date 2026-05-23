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

                var user3 = new User
                {
                    Username = "khaled",
                    PasswordHash = PasswordService.Hash("123456"),
                    FullName = "Khaled Ibrahim",
                    Role = UserRole.Member,
                    CreatedAt = DateTime.Now
                };

                var user4 = new User
                {
                    Username = "nora",
                    PasswordHash = PasswordService.Hash("123456"),
                    FullName = "Nora Youssef",
                    Role = UserRole.Member,
                    CreatedAt = DateTime.Now
                };

                var user5 = new User
                {
                    Username = "sami",
                    PasswordHash = PasswordService.Hash("123456"),
                    FullName = "Sami Tarek",
                    Role = UserRole.Member,
                    CreatedAt = DateTime.Now
                };

                var user6 = new User
                {
                    Username = "layla",
                    PasswordHash = PasswordService.Hash("123456"),
                    FullName = "Layla Mahmoud",
                    Role = UserRole.Member,
                    CreatedAt = DateTime.Now
                };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);
                db.Users.Add(user4);
                db.Users.Add(user5);
                db.Users.Add(user6);

                db.SaveChanges();

                // TASKS — Ahmed (user1)
                db.Tasks.Add(new TaskItem
                {
                    Title = "Prepare Monthly Report",
                    Description = "Monthly sales report for Q2",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-10),
                    AssignedDate = DateTime.Now.AddDays(-8),
                    CreatedById = admin.Id,
                    AssignedToId = user1.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Database Backup Script",
                    Description = "Write automated backup script for production DB",
                    Status = TaskStatus.Completed,
                    CreatedDate = DateTime.Now.AddDays(-14),
                    AssignedDate = DateTime.Now.AddDays(-13),
                    CreatedById = admin.Id,
                    AssignedToId = user1.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Inventory Audit",
                    Description = "Audit current inventory records and fix discrepancies",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-15),
                    AssignedDate = DateTime.Now.AddDays(-10),
                    CreatedById = admin.Id,
                    AssignedToId = user1.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Vendor Contract Review",
                    Description = "Review and renew vendor contracts for next quarter",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-7),
                    AssignedDate = DateTime.Now.AddDays(-5),
                    CreatedById = admin.Id,
                    AssignedToId = user1.Id
                });

                // TASKS — Mona (user2)
                db.Tasks.Add(new TaskItem
                {
                    Title = "Fix UI Navigation Bug",
                    Description = "Navbar dropdown not closing on mobile",
                    Status = TaskStatus.InProgress,
                    CreatedDate = DateTime.Now.AddDays(-7),
                    AssignedDate = DateTime.Now.AddDays(-5),
                    CreatedById = admin.Id,
                    AssignedToId = user2.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Create Unit Tests",
                    Description = "Write unit tests for the task service layer",
                    Status = TaskStatus.InProgress,
                    CreatedDate = DateTime.Now.AddDays(-4),
                    AssignedDate = DateTime.Now.AddDays(-3),
                    CreatedById = admin.Id,
                    AssignedToId = user2.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Update Login Page Styles",
                    Description = "Apply new branding to the login page",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-9),
                    AssignedDate = DateTime.Now.AddDays(-7),
                    CreatedById = admin.Id,
                    AssignedToId = user2.Id
                });

                // TASKS — Khaled (user3)
                db.Tasks.Add(new TaskItem
                {
                    Title = "Design New Dashboard",
                    Description = "Create wireframes for the admin dashboard redesign",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-6),
                    AssignedDate = DateTime.Now.AddDays(-6),
                    CreatedById = admin.Id,
                    AssignedToId = user3.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Deploy Staging Environment",
                    Description = "Set up staging server with latest build",
                    Status = TaskStatus.Completed,
                    CreatedDate = DateTime.Now.AddDays(-20),
                    AssignedDate = DateTime.Now.AddDays(-19),
                    CreatedById = admin.Id,
                    AssignedToId = user3.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Database Migration Plan",
                    Description = "Plan schema migration for new feature module",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-12),
                    AssignedDate = DateTime.Now.AddDays(-10),
                    CreatedById = admin.Id,
                    AssignedToId = user3.Id
                });

                // TASKS — Nora (user4)
                db.Tasks.Add(new TaskItem
                {
                    Title = "Update User Documentation",
                    Description = "Revise user guide for the new features",
                    Status = TaskStatus.InProgress,
                    CreatedDate = DateTime.Now.AddDays(-5),
                    AssignedDate = DateTime.Now.AddDays(-4),
                    CreatedById = admin.Id,
                    AssignedToId = user4.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Security Review",
                    Description = "Review authentication and authorization flows",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-1),
                    AssignedDate = DateTime.Now,
                    CreatedById = admin.Id,
                    AssignedToId = user4.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "GDPR Compliance Check",
                    Description = "Ensure data handling complies with GDPR requirements",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-8),
                    AssignedDate = DateTime.Now.AddDays(-6),
                    CreatedById = admin.Id,
                    AssignedToId = user4.Id
                });

                // TASKS — Sami (user5)
                db.Tasks.Add(new TaskItem
                {
                    Title = "Email Service Integration",
                    Description = "Integrate SendGrid for transactional emails",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-3),
                    AssignedDate = DateTime.Now.AddDays(-3),
                    CreatedById = admin.Id,
                    AssignedToId = user5.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "API Rate Limiting",
                    Description = "Implement rate limiting on public API endpoints",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now,
                    AssignedDate = DateTime.Now,
                    CreatedById = admin.Id,
                    AssignedToId = user5.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Logging System Upgrade",
                    Description = "Upgrade logging framework to structured logging",
                    Status = TaskStatus.InProgress,
                    CreatedDate = DateTime.Now.AddDays(-6),
                    AssignedDate = DateTime.Now.AddDays(-4),
                    CreatedById = admin.Id,
                    AssignedToId = user5.Id
                });

                // TASKS — Layla (user6)
                db.Tasks.Add(new TaskItem
                {
                    Title = "Performance Audit",
                    Description = "Audit page load times and recommend optimizations",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-2),
                    AssignedDate = DateTime.Now.AddDays(-2),
                    CreatedById = admin.Id,
                    AssignedToId = user6.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Mobile Responsive Fixes",
                    Description = "Fix layout issues on screens under 768px",
                    Status = TaskStatus.InProgress,
                    CreatedDate = DateTime.Now.AddDays(-8),
                    AssignedDate = DateTime.Now.AddDays(-7),
                    CreatedById = admin.Id,
                    AssignedToId = user6.Id
                });

                db.Tasks.Add(new TaskItem
                {
                    Title = "Cross-browser Testing",
                    Description = "Test application in Chrome, Firefox, Safari, and Edge",
                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now.AddDays(-14),
                    AssignedDate = DateTime.Now.AddDays(-10),
                    CreatedById = admin.Id,
                    AssignedToId = user6.Id
                });

                db.SaveChanges();

            }
        }
    }
}