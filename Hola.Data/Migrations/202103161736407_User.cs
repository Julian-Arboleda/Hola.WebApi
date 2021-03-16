namespace Hola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "MessageId", "dbo.Message");
            DropIndex("dbo.Event", new[] { "MessageId" });
            CreateTable(
                "dbo.EventMessage",
                c => new
                    {
                        EventMessageId = c.Int(nullable: false, identity: true),
                        CreatorId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDateCreated = c.DateTimeOffset(precision: 7),
                        EventId = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventMessageId)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .Index(t => t.EventId)
                .Index(t => t.Id);
            
            DropColumn("dbo.Event", "IsLiked");
            DropColumn("dbo.Event", "MessageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "MessageId", c => c.Int());
            AddColumn("dbo.Event", "IsLiked", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.EventMessage", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.EventMessage", "EventId", "dbo.Event");
            DropIndex("dbo.EventMessage", new[] { "Id" });
            DropIndex("dbo.EventMessage", new[] { "EventId" });
            DropTable("dbo.EventMessage");
            CreateIndex("dbo.Event", "MessageId");
            AddForeignKey("dbo.Event", "MessageId", "dbo.Message", "MessageId");
        }
    }
}
