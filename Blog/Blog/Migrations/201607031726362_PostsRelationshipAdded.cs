namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostsRelationshipAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Posts", name: "Category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Posts", "Category_CategoryId");
            AddForeignKey("dbo.Posts", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
