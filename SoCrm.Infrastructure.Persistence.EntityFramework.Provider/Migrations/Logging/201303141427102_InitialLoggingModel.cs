namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Logging
{
    using System.Data.Entity.Migrations;

    public partial class InitialLoggingModel : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.LogEvents",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        Message = c.String(maxLength: 4000),
                        Severity = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectId);
            
        }
        
        public override void Down()
        {
            this.DropTable("dbo.LogEvents");
        }
    }
}
