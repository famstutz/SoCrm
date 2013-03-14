// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201303141429586_InitialCustomerModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The inital customer model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Customer
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The initial customer model.
    /// </summary>
    public partial class InitialCustomerModel : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
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

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropIndex("dbo.Companies", new[] { "Address_ObjectId" });
            this.DropIndex("dbo.People", new[] { "Address_ObjectId" });
            this.DropIndex("dbo.People", new[] { "Employer_ObjectId" });
            this.DropForeignKey("dbo.Companies", "Address_ObjectId", "dbo.Addresses");
            this.DropForeignKey("dbo.People", "Address_ObjectId", "dbo.Addresses");
            this.DropForeignKey("dbo.People", "Employer_ObjectId", "dbo.Companies");
            this.DropTable("dbo.EMailAddresses");
            this.DropTable("dbo.PhoneNumbers");
            this.DropTable("dbo.Addresses");
            this.DropTable("dbo.Companies");
            this.DropTable("dbo.People");
        }
    }
}
