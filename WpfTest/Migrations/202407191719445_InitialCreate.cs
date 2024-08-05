namespace WpfTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.id);

        }

        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
