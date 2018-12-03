namespace AppEnvioArtigos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artigos",
                c => new
                    {
                        ArtigoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        ResumoArtigo = c.String(nullable: false),
                        Genero = c.Int(nullable: false),
                        Artigopdf = c.Binary(),
                        ContentType = c.String(),
                    })
                .PrimaryKey(t => t.ArtigoID);
            
            CreateTable(
                "dbo.AvaliarArtigo",
                c => new
                    {
                        AvaliacaoID = c.Int(nullable: false, identity: true),
                        NotaArtigo = c.Single(nullable: false),
                        ComentarioRevisao = c.String(nullable: false),
                        Artigos_ArtigoID = c.Int(),
                    })
                .PrimaryKey(t => t.AvaliacaoID)
                .ForeignKey("dbo.Artigos", t => t.Artigos_ArtigoID)
                .Index(t => t.Artigos_ArtigoID);
            
            CreateTable(
                "dbo.Participante",
                c => new
                    {
                        ParticipanteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Perfil = c.Int(nullable: false),
                        Telefone = c.String(),
                        Email = c.String(),
                        NumInscricao = c.Int(nullable: false),
                        Senha = c.String(),
                        RepitaSenha = c.String(),
                        Endereco_Rua = c.String(),
                        Endereco_Cep = c.String(),
                        Endereco_Numero = c.Int(nullable: false),
                        Endereco_Complemento = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_Estado = c.String(),
                    })
                .PrimaryKey(t => t.ParticipanteID);
            
            CreateTable(
                "dbo.ParticipanteArtigos",
                c => new
                    {
                        Participante_ParticipanteID = c.Int(nullable: false),
                        Artigos_ArtigoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Participante_ParticipanteID, t.Artigos_ArtigoID })
                .ForeignKey("dbo.Participante", t => t.Participante_ParticipanteID, cascadeDelete: true)
                .ForeignKey("dbo.Artigos", t => t.Artigos_ArtigoID, cascadeDelete: true)
                .Index(t => t.Participante_ParticipanteID)
                .Index(t => t.Artigos_ArtigoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipanteArtigos", "Artigos_ArtigoID", "dbo.Artigos");
            DropForeignKey("dbo.ParticipanteArtigos", "Participante_ParticipanteID", "dbo.Participante");
            DropForeignKey("dbo.AvaliarArtigo", "Artigos_ArtigoID", "dbo.Artigos");
            DropIndex("dbo.ParticipanteArtigos", new[] { "Artigos_ArtigoID" });
            DropIndex("dbo.ParticipanteArtigos", new[] { "Participante_ParticipanteID" });
            DropIndex("dbo.AvaliarArtigo", new[] { "Artigos_ArtigoID" });
            DropTable("dbo.ParticipanteArtigos");
            DropTable("dbo.Participante");
            DropTable("dbo.AvaliarArtigo");
            DropTable("dbo.Artigos");
        }
    }
}
