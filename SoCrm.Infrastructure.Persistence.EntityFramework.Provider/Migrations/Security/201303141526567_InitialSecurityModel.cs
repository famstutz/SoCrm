namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Security
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSecurityModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 4000),
                        Role = c.Int(nullable: false),
                        Password = c.String(maxLength: 4000),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
