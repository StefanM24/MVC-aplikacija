namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prvi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Iznajmljivanje", "DatumPocetka", c => c.DateTime(nullable: false));
            DropColumn("dbo.Iznajmljivanje", "DatumRodjenja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Iznajmljivanje", "DatumRodjenja", c => c.DateTime(nullable: false));
            DropColumn("dbo.Iznajmljivanje", "DatumPocetka");
        }
    }
}
