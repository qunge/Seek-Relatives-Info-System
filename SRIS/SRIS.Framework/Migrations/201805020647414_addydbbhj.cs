namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addydbbhj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterInfo", "IsSuccess", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterInfo", "IsSuccess");
        }
    }
}
