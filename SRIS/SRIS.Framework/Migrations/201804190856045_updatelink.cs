namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelink : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterInfo", "PostLink", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterInfo", "PostLink", c => c.String(nullable: false));
        }
    }
}
