// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201303161702337_UsingCollections.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The using collections.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Migrations.Customer
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The using collections.
    /// </summary>
    public partial class UsingCollections : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("dbo.PhoneNumbers", "Person_ObjectId", c => c.Guid());
            this.AddColumn("dbo.EMailAddresses", "Person_ObjectId", c => c.Guid());
            this.AddForeignKey("dbo.PhoneNumbers", "Person_ObjectId", "dbo.People", "ObjectId");
            this.AddForeignKey("dbo.EMailAddresses", "Person_ObjectId", "dbo.People", "ObjectId");
            this.CreateIndex("dbo.PhoneNumbers", "Person_ObjectId");
            this.CreateIndex("dbo.EMailAddresses", "Person_ObjectId");
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropIndex("dbo.EMailAddresses", new[] { "Person_ObjectId" });
            this.DropIndex("dbo.PhoneNumbers", new[] { "Person_ObjectId" });
            this.DropForeignKey("dbo.EMailAddresses", "Person_ObjectId", "dbo.People");
            this.DropForeignKey("dbo.PhoneNumbers", "Person_ObjectId", "dbo.People");
            this.DropColumn("dbo.EMailAddresses", "Person_ObjectId");
            this.DropColumn("dbo.PhoneNumbers", "Person_ObjectId");
        }
    }
}
