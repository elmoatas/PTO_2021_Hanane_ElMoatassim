namespace WPF_Schoolbib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Library1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libraries", "Availability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libraries", "Availability");
        }
    }
}
