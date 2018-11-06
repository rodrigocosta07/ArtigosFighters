namespace AppEnvioArtigos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAlteracaoClasse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artigos", "Genero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artigos", "Genero", c => c.String());
        }
    }
}
