namespace Hola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendee", "CreatorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Event", "HostId", c => c.Guid(nullable: false));
            AddColumn("dbo.Event", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Event", "ModifiedDateCreated", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Location", "CreatorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Message", "CreatorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Message", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Message", "ModifiedDateCreated", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Event", "Host");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Host", c => c.String());
            DropColumn("dbo.Message", "ModifiedDateCreated");
            DropColumn("dbo.Message", "DateCreated");
            DropColumn("dbo.Message", "CreatorId");
            DropColumn("dbo.Location", "CreatorId");
            DropColumn("dbo.Event", "ModifiedDateCreated");
            DropColumn("dbo.Event", "DateCreated");
            DropColumn("dbo.Event", "HostId");
            DropColumn("dbo.Attendee", "CreatorId");
        }
    }
}
