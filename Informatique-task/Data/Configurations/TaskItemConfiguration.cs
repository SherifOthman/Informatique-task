using Informatique_task.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Informatique_task.Data.Configurations
{
    public class TaskItemConfiguration : EntityTypeConfiguration<TaskItem>
    {
        public TaskItemConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.Description)
                .IsRequired();

            Property(t => t.AttachmentPath)
                .HasMaxLength(500);
            
            Property(t => t.AssignedDate)
                .IsRequired();

            HasRequired(t => t.CreatedBy)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.CreatedById)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.AssignedTo)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedToId)
                .WillCascadeOnDelete(false);

            ToTable("Tasks");
        }
    }
}