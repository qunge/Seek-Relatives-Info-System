namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserInfo");
            CreateTable(
                "dbo.RegisterInfo",
                c => new
                    {
                        RegisterInfoId = c.String(nullable: false, maxLength: 128),
                        CaseCode = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 50),
                        BeSeekerName = c.String(nullable: false, maxLength: 50),
                        GetTaskDateTime = c.String(),
                        RegisterLink = c.String(nullable: false),
                        PostLink = c.String(nullable: false),
                        LinkManPhone = c.String(nullable: false),
                        QQ = c.String(),
                        WeiXin = c.String(),
                        IsReturnTask = c.Int(nullable: false),
                        ReturnTaskDateTime = c.DateTime(nullable: false),
                        IsBBHJ = c.Int(nullable: false),
                        Volunteer = c.String(nullable: false, maxLength: 50),
                        Remarks = c.String(nullable: false),
                        SRTypeId_SRTypeId = c.Int(),
                        UserInfo_UserInfoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RegisterInfoId)
                .ForeignKey("dbo.SRType", t => t.SRTypeId_SRTypeId)
                .ForeignKey("dbo.UserInfo", t => t.UserInfo_UserInfoId)
                .Index(t => t.SRTypeId_SRTypeId)
                .Index(t => t.UserInfo_UserInfoId);
            
            CreateTable(
                "dbo.SRType",
                c => new
                    {
                        SRTypeId = c.Int(nullable: false, identity: true),
                        SRTypeName = c.String(),
                    })
                .PrimaryKey(t => t.SRTypeId);
            
            AddColumn("dbo.UserInfo", "UserInfoId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserInfo", "UserInfoId");
            DropColumn("dbo.UserInfo", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfo", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.RegisterInfo", "UserInfo_UserInfoId", "dbo.UserInfo");
            DropForeignKey("dbo.RegisterInfo", "SRTypeId_SRTypeId", "dbo.SRType");
            DropIndex("dbo.RegisterInfo", new[] { "UserInfo_UserInfoId" });
            DropIndex("dbo.RegisterInfo", new[] { "SRTypeId_SRTypeId" });
            DropPrimaryKey("dbo.UserInfo");
            DropColumn("dbo.UserInfo", "UserInfoId");
            DropTable("dbo.SRType");
            DropTable("dbo.RegisterInfo");
            AddPrimaryKey("dbo.UserInfo", "Id");
        }
    }
}
