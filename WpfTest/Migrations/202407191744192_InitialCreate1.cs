namespace WpfTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Users", "Pass", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "Pass");
            DropColumn("dbo.Users", "Login");
        }
    }
}
