namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bmb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RegisterInfo", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterInfo", "IsDelete", c => c.Int(nullable: false));
        }
    }
}
