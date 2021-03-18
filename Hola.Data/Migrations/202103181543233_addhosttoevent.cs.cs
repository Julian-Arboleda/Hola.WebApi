namespace Hola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhosttoeventcs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Host", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "Host");
        }
    }
}
