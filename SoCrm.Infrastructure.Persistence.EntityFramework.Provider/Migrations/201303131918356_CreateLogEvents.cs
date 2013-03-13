namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEvents",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        Message = c.String(),
                        Severity = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogEvents");
        }
    }
}
