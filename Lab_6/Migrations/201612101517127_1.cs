namespace Lab_6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriesId = c.Int(nullable: false),
                        Name = c.String(),
                        Duration = c.Time(nullable: false, precision: 7),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .Index(t => t.SeriesId);
            
            DropColumn("dbo.Series", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Duration", c => c.Time(nullable: false, precision: 7));
            DropForeignKey("dbo.Episodes", "SeriesId", "dbo.Series");
            DropIndex("dbo.Episodes", new[] { "SeriesId" });
            DropTable("dbo.Episodes");
        }
    }
}
