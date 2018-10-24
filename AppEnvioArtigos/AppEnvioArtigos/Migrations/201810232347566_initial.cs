namespace AppEnvioArtigos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artigos_Participante", "ArtigoId", "dbo.Artigos");
            DropForeignKey("dbo.Artigos_Participante", "ParticipanteId", "dbo.Participante");
            DropIndex("dbo.Artigos_Participante", new[] { "ArtigoId" });
            DropIndex("dbo.Artigos_Participante", new[] { "ParticipanteId" });
            RenameColumn(table: "dbo.AvaliarArtigo", name: "EnvioArtigos_ArtigoID", newName: "Artigos_ArtigoID");
            RenameIndex(table: "dbo.AvaliarArtigo", name: "IX_EnvioArtigos_ArtigoID", newName: "IX_Artigos_ArtigoID");
            CreateTable(
                "dbo.Participante_Artigos",
                c => new
                    {
                        Participante_ArtigosID = c.Int(nullable: false, identity: true),
                        ParticipanteID = c.Int(nullable: false),
                        ArtigoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Participante_ArtigosID)
                .ForeignKey("dbo.Artigos", t => t.ArtigoID, cascadeDelete: true)
                .ForeignKey("dbo.Participante", t => t.ParticipanteID, cascadeDelete: true)
                .Index(t => t.ParticipanteID)
                .Index(t => t.ArtigoID);
            
            AddColumn("dbo.Participante", "Perfil", c => c.Int(nullable: false));
            DropTable("dbo.Artigos_Participante");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Artigos_Participante",
                c => new
                    {
                        Artigos_ParticipanteId = c.Int(nullable: false, identity: true),
                        ArtigoId = c.Int(nullable: false),
                        ParticipanteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Artigos_ParticipanteId);
            
            DropForeignKey("dbo.Participante_Artigos", "ParticipanteID", "dbo.Participante");
            DropForeignKey("dbo.Participante_Artigos", "ArtigoID", "dbo.Artigos");
            DropIndex("dbo.Participante_Artigos", new[] { "ArtigoID" });
            DropIndex("dbo.Participante_Artigos", new[] { "ParticipanteID" });
            DropColumn("dbo.Participante", "Perfil");
            DropTable("dbo.Participante_Artigos");
            RenameIndex(table: "dbo.AvaliarArtigo", name: "IX_Artigos_ArtigoID", newName: "IX_EnvioArtigos_ArtigoID");
            RenameColumn(table: "dbo.AvaliarArtigo", name: "Artigos_ArtigoID", newName: "EnvioArtigos_ArtigoID");
            CreateIndex("dbo.Artigos_Participante", "ParticipanteId");
            CreateIndex("dbo.Artigos_Participante", "ArtigoId");
            AddForeignKey("dbo.Artigos_Participante", "ParticipanteId", "dbo.Participante", "ParticipanteID", cascadeDelete: true);
            AddForeignKey("dbo.Artigos_Participante", "ArtigoId", "dbo.Artigos", "ArtigoID", cascadeDelete: true);
        }
    }
}
