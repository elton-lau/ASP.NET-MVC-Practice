namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exercise3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateAdded = c.DateTime(nullable: false),
                        RelesaseDate = c.DateTime(nullable: false),
                        StockNumber = c.Int(nullable: false),
                        GenreId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId_Id, cascadeDelete: true)
                .Index(t => t.GenreId_Id);

            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (4, 'Romance')");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId_Id" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
