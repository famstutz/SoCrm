// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201303141427102_InitialLoggingModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The initial logging model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Migrations.Logging
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The initial logging model.
    /// </summary>
    public partial class InitialLoggingModel : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
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

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropTable("dbo.LogEvents");
        }
    }
}
