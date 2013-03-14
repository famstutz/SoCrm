namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Customer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCustomerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                        Employer_ObjectId = c.Guid(),
                        Address_ObjectId = c.Guid(),
                    })
                .PrimaryKey(t => t.ObjectId)
                .ForeignKey("dbo.Companies", t => t.Employer_ObjectId)
                .ForeignKey("dbo.Addresses", t => t.Address_ObjectId)
                .Index(t => t.Employer_ObjectId)
                .Index(t => t.Address_ObjectId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 4000),
                        Website = c.String(maxLength: 4000),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                        Address_ObjectId = c.Guid(),
                    })
                .PrimaryKey(t => t.ObjectId)
                .ForeignKey("dbo.Addresses", t => t.Address_ObjectId)
                .Index(t => t.Address_ObjectId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        AddressLine = c.String(maxLength: 4000),
                        ZipCode = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        Country = c.String(maxLength: 4000),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        Number = c.String(maxLength: 4000),
                        ContactType = c.Int(nullable: false),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectId);
            
            CreateTable(
                "dbo.EMailAddresses",
                c => new
                    {
                        ObjectId = c.Guid(nullable: false),
                        Address = c.String(maxLength: 4000),
                        ContactType = c.Int(nullable: false),
                        CreationTimeStamp = c.DateTime(nullable: false),
                        LastUpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Companies", new[] { "Address_ObjectId" });
            DropIndex("dbo.People", new[] { "Address_ObjectId" });
            DropIndex("dbo.People", new[] { "Employer_ObjectId" });
            DropForeignKey("dbo.Companies", "Address_ObjectId", "dbo.Addresses");
            DropForeignKey("dbo.People", "Address_ObjectId", "dbo.Addresses");
            DropForeignKey("dbo.People", "Employer_ObjectId", "dbo.Companies");
            DropTable("dbo.EMailAddresses");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Addresses");
            DropTable("dbo.Companies");
            DropTable("dbo.People");
        }
    }
}
