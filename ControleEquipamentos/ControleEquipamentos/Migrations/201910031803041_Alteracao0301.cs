namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao0301 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ocorrencias", "DataDevolucao", c => c.DateTime());
            AddColumn("dbo.Ocorrencias", "Finalizado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ocorrencias", "Finalizado");
            DropColumn("dbo.Ocorrencias", "DataDevolucao");
        }
    }
}
