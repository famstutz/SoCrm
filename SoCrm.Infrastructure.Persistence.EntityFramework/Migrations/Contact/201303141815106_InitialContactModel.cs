// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201303141815106_InitialContactModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The initial contact model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Migrations.Contact
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The initial contact model.
    /// </summary>
    public partial class InitialContactModel : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
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

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropTable("dbo.Contacts");
        }
    }
}
