namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BBHJInfo",
                c => new
                    {
                        BBHJInfoID = c.String(nullable: false, maxLength: 128),
                        RegisterInfoID = c.String(maxLength: 128),
                        BBHJCode = c.String(nullable: false, maxLength: 20),
                        Volunteer = c.String(),
                        GuideTime = c.DateTime(nullable: false),
                        Remark = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BBHJInfoID)
                .ForeignKey("dbo.RegisterInfo", t => t.RegisterInfoID)
                .Index(t => t.RegisterInfoID);
            
            CreateTable(
                "dbo.RegisterInfo",
                c => new
                    {
                        RegisterInfoID = c.String(nullable: false, maxLength: 128),
                        CaseCode = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 50),
                        BeSeekerName = c.String(nullable: false, maxLength: 50),
                        GetTaskDateTime = c.DateTime(nullable: false),
                        RegisterLink = c.String(nullable: false),
                        PostLink = c.String(),
                        DNAState = c.Int(),
                        IsReturnTask = c.Int(nullable: false),
                        ReturnTaskDateTime = c.DateTime(),
                        ReturnReason = c.String(maxLength: 50),
                        IsBBHJ = c.String(),
                        Remarks = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        UserInfoID = c.String(nullable: false, maxLength: 128),
                        SRTypeID = c.String(),
                        SRType_SRTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.RegisterInfoID)
                .ForeignKey("dbo.SRType", t => t.SRType_SRTypeID)
                .ForeignKey("dbo.UserInfo", t => t.UserInfoID, cascadeDelete: true)
                .Index(t => t.UserInfoID)
                .Index(t => t.SRType_SRTypeID);
            
            CreateTable(
                "dbo.LinkMan",
                c => new
                    {
                        RegisterInfoId = c.String(nullable: false, maxLength: 128),
                        LinkManID = c.String(nullable: false),
                        LinkManName = c.String(nullable: false, maxLength: 50),
                        Sex = c.Int(nullable: false),
                        Birthday = c.DateTime(),
                        Relationship = c.String(maxLength: 50),
                        IdCardNo = c.String(maxLength: 18),
                        Career = c.String(maxLength: 50),
                        Address = c.String(),
                        Phone = c.String(nullable: false, maxLength: 11),
                        TelPhone = c.String(),
                        QQ = c.String(maxLength: 50),
                        WeiXin = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        OtherLink = c.String(maxLength: 50),
                        Remark = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RegisterInfoId)
                .ForeignKey("dbo.RegisterInfo", t => t.RegisterInfoId)
                .Index(t => t.RegisterInfoId);
            
            CreateTable(
                "dbo.SRType",
                c => new
                    {
                        SRTypeID = c.Int(nullable: false, identity: true),
                        SRTypeName = c.String(),
                    })
                .PrimaryKey(t => t.SRTypeID);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        UserInfoID = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false, maxLength: 50),
                        Salt = c.String(nullable: false, maxLength: 10),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserInfoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BBHJInfo", "RegisterInfoID", "dbo.RegisterInfo");
            DropForeignKey("dbo.RegisterInfo", "UserInfoID", "dbo.UserInfo");
            DropForeignKey("dbo.RegisterInfo", "SRType_SRTypeID", "dbo.SRType");
            DropForeignKey("dbo.LinkMan", "RegisterInfoId", "dbo.RegisterInfo");
            DropIndex("dbo.LinkMan", new[] { "RegisterInfoId" });
            DropIndex("dbo.RegisterInfo", new[] { "SRType_SRTypeID" });
            DropIndex("dbo.RegisterInfo", new[] { "UserInfoID" });
            DropIndex("dbo.BBHJInfo", new[] { "RegisterInfoID" });
            DropTable("dbo.UserInfo");
            DropTable("dbo.SRType");
            DropTable("dbo.LinkMan");
            DropTable("dbo.RegisterInfo");
            DropTable("dbo.BBHJInfo");
        }
    }
}
