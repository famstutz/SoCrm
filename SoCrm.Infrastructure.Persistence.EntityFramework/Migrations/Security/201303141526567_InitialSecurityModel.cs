// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201303141526567_InitialSecurityModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The initial security model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Migrations.Security
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The initial security model.
    /// </summary>
    public partial class InitialSecurityModel : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
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

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropTable("dbo.Users");
        }
    }
}
