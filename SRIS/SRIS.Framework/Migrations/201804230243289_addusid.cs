namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisterInfo", "UserInfo_UserInfoID", "dbo.UserInfo");
            DropIndex("dbo.RegisterInfo", new[] { "UserInfo_UserInfoID" });
            RenameColumn(table: "dbo.RegisterInfo", name: "UserInfo_UserInfoID", newName: "UserInfoID");
            AlterColumn("dbo.RegisterInfo", "UserInfoID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.RegisterInfo", "UserInfoID");
            AddForeignKey("dbo.RegisterInfo", "UserInfoID", "dbo.UserInfo", "UserInfoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisterInfo", "UserInfoID", "dbo.UserInfo");
            DropIndex("dbo.RegisterInfo", new[] { "UserInfoID" });
            AlterColumn("dbo.RegisterInfo", "UserInfoID", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.RegisterInfo", name: "UserInfoID", newName: "UserInfo_UserInfoID");
            CreateIndex("dbo.RegisterInfo", "UserInfo_UserInfoID");
            AddForeignKey("dbo.RegisterInfo", "UserInfo_UserInfoID", "dbo.UserInfo", "UserInfoID");
        }
    }
}
