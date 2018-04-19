namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesdfs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RegisterInfo", "SucessCaseCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterInfo", "SucessCaseCode", c => c.String(maxLength: 50));
        }
    }
}
