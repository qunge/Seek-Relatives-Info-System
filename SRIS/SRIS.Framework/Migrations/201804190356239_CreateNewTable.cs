namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisterInfo", "UserInfo_UserInfoId", "dbo.UserInfo");
            DropIndex("dbo.RegisterInfo", new[] { "UserInfo_UserInfoId" });
            RenameColumn(table: "dbo.RegisterInfo", name: "UserInfo_UserInfoId", newName: "UserInfoId");
            RenameColumn(table: "dbo.RegisterInfo", name: "SRTypeId_SRTypeId", newName: "SRType_SRTypeId");
            RenameIndex(table: "dbo.RegisterInfo", name: "IX_SRTypeId_SRTypeId", newName: "IX_SRType_SRTypeId");
            CreateTable(
                "dbo.BBHJInfo",
                c => new
                    {
                        BBHJInfoId = c.String(nullable: false, maxLength: 128),
                        RegisterInfoId = c.String(maxLength: 128),
                        BBHJCode = c.String(nullable: false, maxLength: 20),
                        Volunteer = c.String(),
                        GuideTime = c.DateTime(nullable: false),
                        Remark = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BBHJInfoId)
                .ForeignKey("dbo.RegisterInfo", t => t.RegisterInfoId)
                .Index(t => t.RegisterInfoId);
            
            CreateTable(
                "dbo.LinkMan",
                c => new
                    {
                        LinkManId = c.String(nullable: false, maxLength: 128),
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
                .PrimaryKey(t => t.LinkManId);
            
            AddColumn("dbo.RegisterInfo", "DNAState", c => c.Int(nullable: false));
            AddColumn("dbo.RegisterInfo", "ReturnReason", c => c.String(maxLength: 50));
            AddColumn("dbo.RegisterInfo", "SucessCaseCode", c => c.String(maxLength: 50));
            AddColumn("dbo.RegisterInfo", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RegisterInfo", "LinkManId", c => c.String(maxLength: 128));
            AddColumn("dbo.RegisterInfo", "SRTypeId", c => c.String());
            AlterColumn("dbo.RegisterInfo", "GetTaskDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RegisterInfo", "ReturnTaskDateTime", c => c.DateTime());
            AlterColumn("dbo.RegisterInfo", "IsBBHJ", c => c.String());
            AlterColumn("dbo.RegisterInfo", "UserInfoId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.RegisterInfo", "UserInfoId");
            CreateIndex("dbo.RegisterInfo", "LinkManId");
            AddForeignKey("dbo.RegisterInfo", "LinkManId", "dbo.LinkMan", "LinkManId");
            AddForeignKey("dbo.RegisterInfo", "UserInfoId", "dbo.UserInfo", "UserInfoId", cascadeDelete: true);
            DropColumn("dbo.RegisterInfo", "LinkManPhone");
            DropColumn("dbo.RegisterInfo", "QQ");
            DropColumn("dbo.RegisterInfo", "WeiXin");
            DropColumn("dbo.RegisterInfo", "Volunteer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterInfo", "Volunteer", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.RegisterInfo", "WeiXin", c => c.String());
            AddColumn("dbo.RegisterInfo", "QQ", c => c.String());
            AddColumn("dbo.RegisterInfo", "LinkManPhone", c => c.String(nullable: false));
            DropForeignKey("dbo.RegisterInfo", "UserInfoId", "dbo.UserInfo");
            DropForeignKey("dbo.BBHJInfo", "RegisterInfoId", "dbo.RegisterInfo");
            DropForeignKey("dbo.RegisterInfo", "LinkManId", "dbo.LinkMan");
            DropIndex("dbo.RegisterInfo", new[] { "LinkManId" });
            DropIndex("dbo.RegisterInfo", new[] { "UserInfoId" });
            DropIndex("dbo.BBHJInfo", new[] { "RegisterInfoId" });
            AlterColumn("dbo.RegisterInfo", "UserInfoId", c => c.String(maxLength: 128));
            AlterColumn("dbo.RegisterInfo", "IsBBHJ", c => c.Int(nullable: false));
            AlterColumn("dbo.RegisterInfo", "ReturnTaskDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RegisterInfo", "GetTaskDateTime", c => c.String());
            DropColumn("dbo.RegisterInfo", "SRTypeId");
            DropColumn("dbo.RegisterInfo", "LinkManId");
            DropColumn("dbo.RegisterInfo", "CreateDateTime");
            DropColumn("dbo.RegisterInfo", "SucessCaseCode");
            DropColumn("dbo.RegisterInfo", "ReturnReason");
            DropColumn("dbo.RegisterInfo", "DNAState");
            DropTable("dbo.LinkMan");
            DropTable("dbo.BBHJInfo");
            RenameIndex(table: "dbo.RegisterInfo", name: "IX_SRType_SRTypeId", newName: "IX_SRTypeId_SRTypeId");
            RenameColumn(table: "dbo.RegisterInfo", name: "SRType_SRTypeId", newName: "SRTypeId_SRTypeId");
            RenameColumn(table: "dbo.RegisterInfo", name: "UserInfoId", newName: "UserInfo_UserInfoId");
            CreateIndex("dbo.RegisterInfo", "UserInfo_UserInfoId");
            AddForeignKey("dbo.RegisterInfo", "UserInfo_UserInfoId", "dbo.UserInfo", "UserInfoId");
        }
    }
}
