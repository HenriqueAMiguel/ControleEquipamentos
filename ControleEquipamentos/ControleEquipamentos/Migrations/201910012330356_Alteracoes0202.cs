namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracoes0202 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emprestimos", "StatusDoEmprestimo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emprestimos", "StatusDoEmprestimo");
        }
    }
}
