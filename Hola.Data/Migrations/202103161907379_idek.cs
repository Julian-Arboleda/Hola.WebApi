namespace Hola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "IsLiked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Message", "IsLiked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Message", "IsLiked");
            DropColumn("dbo.Event", "IsLiked");
        }
    }
}
