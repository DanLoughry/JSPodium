namespace Podium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedthepostfunctionforstudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Loggedin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Loggedin");
        }
    }
}
