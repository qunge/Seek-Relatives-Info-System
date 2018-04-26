namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterInfo", "IsDelete", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterInfo", "IsDelete");
        }
    }
}
