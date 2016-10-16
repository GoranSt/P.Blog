namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostContentAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Content");
        }
    }
}
