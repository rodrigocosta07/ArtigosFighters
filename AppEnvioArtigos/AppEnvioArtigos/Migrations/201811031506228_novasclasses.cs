namespace AppEnvioArtigos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novasclasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AvaliarArtigoArtigos", "AvaliarArtigo_AvaliacaoID", "dbo.AvaliarArtigo");
            DropForeignKey("dbo.AvaliarArtigoArtigos", "Artigos_ArtigoID", "dbo.Artigos");
            DropIndex("dbo.AvaliarArtigoArtigos", new[] { "AvaliarArtigo_AvaliacaoID" });
            DropIndex("dbo.AvaliarArtigoArtigos", new[] { "Artigos_ArtigoID" });
            AddColumn("dbo.Artigos", "Genero", c => c.String());
            AddColumn("dbo.AvaliarArtigo", "Artigos_ArtigoID", c => c.Int());
            CreateIndex("dbo.AvaliarArtigo", "Artigos_ArtigoID");
            AddForeignKey("dbo.AvaliarArtigo", "Artigos_ArtigoID", "dbo.Artigos", "ArtigoID");
            DropTable("dbo.AvaliarArtigoArtigos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AvaliarArtigoArtigos",
                c => new
                    {
                        AvaliarArtigo_AvaliacaoID = c.Int(nullable: false),
                        Artigos_ArtigoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AvaliarArtigo_AvaliacaoID, t.Artigos_ArtigoID });
            
            DropForeignKey("dbo.AvaliarArtigo", "Artigos_ArtigoID", "dbo.Artigos");
            DropIndex("dbo.AvaliarArtigo", new[] { "Artigos_ArtigoID" });
            DropColumn("dbo.AvaliarArtigo", "Artigos_ArtigoID");
            DropColumn("dbo.Artigos", "Genero");
            CreateIndex("dbo.AvaliarArtigoArtigos", "Artigos_ArtigoID");
            CreateIndex("dbo.AvaliarArtigoArtigos", "AvaliarArtigo_AvaliacaoID");
            AddForeignKey("dbo.AvaliarArtigoArtigos", "Artigos_ArtigoID", "dbo.Artigos", "ArtigoID", cascadeDelete: true);
            AddForeignKey("dbo.AvaliarArtigoArtigos", "AvaliarArtigo_AvaliacaoID", "dbo.AvaliarArtigo", "AvaliacaoID", cascadeDelete: true);
        }
    }
}
