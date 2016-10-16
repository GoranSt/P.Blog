namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repliesAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replays", "CommentId", "dbo.Comments");
            AddColumn("dbo.Comments", "Comment_CommentId", c => c.Int());
            CreateIndex("dbo.Comments", "Comment_CommentId");
            AddForeignKey("dbo.Replays", "CommentId", "dbo.Comments", "CommentId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "Comment_CommentId", "dbo.Comments", "CommentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.Replays", "CommentId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "Comment_CommentId" });
            DropColumn("dbo.Comments", "Comment_CommentId");
            AddForeignKey("dbo.Replays", "CommentId", "dbo.Comments", "CommentId", cascadeDelete: true);
        }
    }
}
