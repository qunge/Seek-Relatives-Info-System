namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSRTypeID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterInfo", "SRTypeID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterInfo", "SRTypeID");
        }
    }
}
