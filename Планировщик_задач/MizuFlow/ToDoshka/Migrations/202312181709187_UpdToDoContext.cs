namespace MizuFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdToDoContext : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tasks", new[] { "Task_ID_Group" });
            AlterColumn("dbo.Tasks", "Task_ID_Group", c => c.Int());
            CreateIndex("dbo.Tasks", "Task_ID_Group");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tasks", new[] { "Task_ID_Group" });
            AlterColumn("dbo.Tasks", "Task_ID_Group", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "Task_ID_Group");
        }
    }
}
