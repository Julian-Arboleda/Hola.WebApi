namespace Hola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mnu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Message", "Title");
        }
    }
}
