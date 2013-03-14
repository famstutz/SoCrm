namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Contact
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialContactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                        Content = c.String(maxLength: 4000),
                        Medium = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectId);         
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
