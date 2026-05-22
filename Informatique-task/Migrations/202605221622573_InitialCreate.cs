namespace Informatique_task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        AttachmentPath = c.String(maxLength: 500),
                        CreatedById = c.Int(nullable: false),
                        AssignedToId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedToId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.AssignedToId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Role = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AssignedToId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Tasks", new[] { "AssignedToId" });
            DropIndex("dbo.Tasks", new[] { "CreatedById" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
