namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Date");
            DropColumn("dbo.Posts", "Date");
            DropColumn("dbo.Categories", "Date");
        }
    }
}
