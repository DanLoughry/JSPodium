namespace Podium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdteacherclassctrlandupdateddbcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Classname = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "Firstname", c => c.String());
            AddColumn("dbo.Students", "Lastname", c => c.String());
            AddColumn("dbo.Students", "Classname", c => c.String());
            AddColumn("dbo.Students", "IsAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.Students", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "IsAdmin");
            DropColumn("dbo.Students", "Classname");
            DropColumn("dbo.Students", "Lastname");
            DropColumn("dbo.Students", "Firstname");
            DropTable("dbo.Teachers");
        }
    }
}
