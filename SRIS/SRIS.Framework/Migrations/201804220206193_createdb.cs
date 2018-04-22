namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisterInfo", "UserInfoID", "dbo.UserInfo");
            DropIndex("dbo.RegisterInfo", new[] { "UserInfoID" });
            RenameColumn(table: "dbo.RegisterInfo", name: "UserInfoID", newName: "UserInfo_UserInfoID");
            AlterColumn("dbo.RegisterInfo", "UserInfo_UserInfoID", c => c.String(maxLength: 128));
            CreateIndex("dbo.RegisterInfo", "UserInfo_UserInfoID");
            AddForeignKey("dbo.RegisterInfo", "UserInfo_UserInfoID", "dbo.UserInfo", "UserInfoID");
            DropColumn("dbo.RegisterInfo", "SRTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterInfo", "SRTypeID", c => c.String());
            DropForeignKey("dbo.RegisterInfo", "UserInfo_UserInfoID", "dbo.UserInfo");
            DropIndex("dbo.RegisterInfo", new[] { "UserInfo_UserInfoID" });
            AlterColumn("dbo.RegisterInfo", "UserInfo_UserInfoID", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.RegisterInfo", name: "UserInfo_UserInfoID", newName: "UserInfoID");
            CreateIndex("dbo.RegisterInfo", "UserInfoID");
            AddForeignKey("dbo.RegisterInfo", "UserInfoID", "dbo.UserInfo", "UserInfoID", cascadeDelete: true);
        }
    }
}
