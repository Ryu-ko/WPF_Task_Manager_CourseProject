namespace MizuFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task_Attachments",
                c => new
                    {
                        ID_Task_Attachments = c.Int(nullable: false, identity: true),
                        TA_UserID = c.Int(),
                        TA_TaskID = c.Int(),
                        TA_SubtaskID = c.Int(),
                        ImagePath = c.String(maxLength: 100),
                        Image = c.Binary(),
                        FilePath = c.String(maxLength: 100),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.ID_Task_Attachments)
                .ForeignKey("dbo.Subtasks", t => t.TA_SubtaskID)
                .ForeignKey("dbo.Tasks", t => t.TA_TaskID)
                .ForeignKey("dbo.Users", t => t.TA_UserID)
                .Index(t => t.TA_UserID)
                .Index(t => t.TA_TaskID)
                .Index(t => t.TA_SubtaskID);
            
            CreateTable(
                "dbo.Subtasks",
                c => new
                    {
                        ID_Subtask = c.Int(nullable: false, identity: true),
                        TaskID = c.Int(),
                        Subtask_Name = c.String(nullable: false),
                        isCheck = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID_Subtask)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true)
                .Index(t => t.TaskID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID_Task = c.Int(nullable: false, identity: true),
                        Task_UserID = c.Int(nullable: false),
                        Task_Name = c.String(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        Deadline = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        Priority = c.Int(),
                        isWork = c.Boolean(),
                        isCheck = c.Boolean(),
                        CheckTime = c.DateTime(storeType: "smalldatetime"),
                        Task_ID_Group = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Task)
                .ForeignKey("dbo.Task_Group", t => t.Task_ID_Group)
                .ForeignKey("dbo.Users", t => t.Task_UserID)
                .Index(t => t.Task_UserID)
                .Index(t => t.Task_ID_Group);
            
            CreateTable(
                "dbo.Task_Group",
                c => new
                    {
                        ID_Group = c.Int(nullable: false, identity: true),
                        Group_Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_Group);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID_User = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        User_Name = c.String(nullable: false, maxLength: 40),
                        User_Surname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Contact = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID_User);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Task_UserID", "dbo.Users");
            DropForeignKey("dbo.Task_Attachments", "TA_UserID", "dbo.Users");
            DropForeignKey("dbo.Subtasks", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "Task_ID_Group", "dbo.Task_Group");
            DropForeignKey("dbo.Task_Attachments", "TA_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Task_Attachments", "TA_SubtaskID", "dbo.Subtasks");
            DropIndex("dbo.Tasks", new[] { "Task_ID_Group" });
            DropIndex("dbo.Tasks", new[] { "Task_UserID" });
            DropIndex("dbo.Subtasks", new[] { "TaskID" });
            DropIndex("dbo.Task_Attachments", new[] { "TA_SubtaskID" });
            DropIndex("dbo.Task_Attachments", new[] { "TA_TaskID" });
            DropIndex("dbo.Task_Attachments", new[] { "TA_UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Task_Group");
            DropTable("dbo.Tasks");
            DropTable("dbo.Subtasks");
            DropTable("dbo.Task_Attachments");
        }
    }
}
