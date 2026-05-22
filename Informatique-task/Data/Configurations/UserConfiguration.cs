using Informatique_task.Models.TaskManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Informatique_task.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);

            Property(x=>x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.PasswordHash)
                .IsRequired();

            Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Role)
                .IsRequired();

            HasIndex(x => x.Username)
                .IsUnique();

            ToTable("Users");
        }
    }
}