namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsAndCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Posts", "Category_CategoryId", c => c.Int());
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Posts", "Category_CategoryId");
            AddForeignKey("dbo.Posts", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_CategoryId" });
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
            DropColumn("dbo.Posts", "Category_CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
