namespace Resgrid.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoListItems",
                c => new
                    {
                        TodoListItemId = c.Int(nullable: false, identity: true),
                        TodoListId = c.Int(nullable: false),
                        Task = c.String(nullable: false),
                        Complete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TodoListItemId)
                .ForeignKey("dbo.TodoLists", t => t.TodoListId, cascadeDelete: true)
                .Index(t => t.TodoListId);
            
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        TodoListId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TodoListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoListItems", "TodoListId", "dbo.TodoLists");
            DropIndex("dbo.TodoListItems", new[] { "TodoListId" });
            DropTable("dbo.TodoLists");
            DropTable("dbo.TodoListItems");
        }
    }
}
