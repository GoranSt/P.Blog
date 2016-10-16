namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReplyFunc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Replays",
                c => new
                    {
                        ReplayId = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        ReplayText = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReplayId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: false)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: false)
                .Index(t => t.CommentId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replays", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Replays", "PostId", "dbo.Posts");
            DropIndex("dbo.Replays", new[] { "PostId" });
            DropIndex("dbo.Replays", new[] { "CommentId" });
            DropTable("dbo.Replays");
        }
    }
}
