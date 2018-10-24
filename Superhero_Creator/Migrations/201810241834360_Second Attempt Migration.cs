namespace Superhero_Creator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondAttemptMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Superheros", newName: "Superheroes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Superheroes", newName: "Superheros");
        }
    }
}
