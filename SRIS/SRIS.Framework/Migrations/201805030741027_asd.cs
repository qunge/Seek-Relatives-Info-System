namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BBHJInfo", "RegisterInfoID", "dbo.RegisterInfo");
            DropIndex("dbo.BBHJInfo", new[] { "RegisterInfoID" });
            AlterColumn("dbo.BBHJInfo", "RegisterInfoID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.BBHJInfo", "BBHJCode", c => c.String(maxLength: 20));
            CreateIndex("dbo.BBHJInfo", "RegisterInfoID");
            AddForeignKey("dbo.BBHJInfo", "RegisterInfoID", "dbo.RegisterInfo", "RegisterInfoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BBHJInfo", "RegisterInfoID", "dbo.RegisterInfo");
            DropIndex("dbo.BBHJInfo", new[] { "RegisterInfoID" });
            AlterColumn("dbo.BBHJInfo", "BBHJCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.BBHJInfo", "RegisterInfoID", c => c.String(maxLength: 128));
            CreateIndex("dbo.BBHJInfo", "RegisterInfoID");
            AddForeignKey("dbo.BBHJInfo", "RegisterInfoID", "dbo.RegisterInfo", "RegisterInfoID");
        }
    }
}
