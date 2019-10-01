namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emprestimos", "DataDevolucao", c => c.DateTime());
            AlterColumn("dbo.Emprestimos", "DataEmprestimo", c => c.DateTime());
            AlterColumn("dbo.Emprestimos", "DataPrevistaDevolucao", c => c.DateTime());
            DropColumn("dbo.Emprestimos", "Status");
            DropColumn("dbo.Emprestimos", "StatusEmprestimo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emprestimos", "StatusEmprestimo", c => c.Int(nullable: false));
            AddColumn("dbo.Emprestimos", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Emprestimos", "DataPrevistaDevolucao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Emprestimos", "DataEmprestimo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Emprestimos", "DataDevolucao", c => c.DateTime(nullable: false));
        }
    }
}
