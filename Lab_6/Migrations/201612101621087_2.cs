namespace Lab_6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Episodes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Series", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Series", "Name", c => c.String());
            AlterColumn("dbo.Episodes", "Name", c => c.String());
        }
    }
}
