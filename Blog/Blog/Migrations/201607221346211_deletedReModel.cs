namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedReModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replays", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Replays", "CommentId", "dbo.Comments");
            DropIndex("dbo.Replays", new[] { "CommentId" });
            DropIndex("dbo.Replays", new[] { "PostId" });
            DropTable("dbo.Replays");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ReplayId);
            
            CreateIndex("dbo.Replays", "PostId");
            CreateIndex("dbo.Replays", "CommentId");
            AddForeignKey("dbo.Replays", "CommentId", "dbo.Comments", "CommentId", cascadeDelete: true);
            AddForeignKey("dbo.Replays", "PostId", "dbo.Posts", "PostId", cascadeDelete: true);
        }
    }
}
