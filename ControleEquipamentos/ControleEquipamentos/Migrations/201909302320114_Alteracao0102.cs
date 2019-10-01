namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao0102 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ocorrencias", "OrdemDeServico", c => c.Int(nullable: false));
            AlterColumn("dbo.Ocorrencias", "DataOcorrencia", c => c.DateTime());
            AlterColumn("dbo.Ocorrencias", "PrevisaoRetorno", c => c.DateTime());
            DropColumn("dbo.Ocorrencias", "Registro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ocorrencias", "Registro", c => c.Int(nullable: false));
            AlterColumn("dbo.Ocorrencias", "PrevisaoRetorno", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ocorrencias", "DataOcorrencia", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ocorrencias", "OrdemDeServico");
        }
    }
}
