namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Customer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsingCollections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneNumbers", "Person_ObjectId", c => c.Guid());
            AddColumn("dbo.EMailAddresses", "Person_ObjectId", c => c.Guid());
            AddForeignKey("dbo.PhoneNumbers", "Person_ObjectId", "dbo.People", "ObjectId");
            AddForeignKey("dbo.EMailAddresses", "Person_ObjectId", "dbo.People", "ObjectId");
            CreateIndex("dbo.PhoneNumbers", "Person_ObjectId");
            CreateIndex("dbo.EMailAddresses", "Person_ObjectId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EMailAddresses", new[] { "Person_ObjectId" });
            DropIndex("dbo.PhoneNumbers", new[] { "Person_ObjectId" });
            DropForeignKey("dbo.EMailAddresses", "Person_ObjectId", "dbo.People");
            DropForeignKey("dbo.PhoneNumbers", "Person_ObjectId", "dbo.People");
            DropColumn("dbo.EMailAddresses", "Person_ObjectId");
            DropColumn("dbo.PhoneNumbers", "Person_ObjectId");
        }
    }
}
