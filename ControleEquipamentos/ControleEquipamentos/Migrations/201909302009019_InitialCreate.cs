namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emprestimos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        DataDevolucao = c.DateTime(nullable: false),
                        DataEmprestimo = c.DateTime(nullable: false),
                        StatusEmprestimo = c.Int(nullable: false),
                        DataPrevistaDevolucao = c.DateTime(nullable: false),
                        Operador_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Operador_Id)
                .ForeignKey("dbo.Pessoas", t => t.Usuario_Id)
                .Index(t => t.Operador_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Equipamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        NumeroRegistro = c.Int(nullable: false),
                        DataRegistro = c.DateTime(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        Contador = c.Int(nullable: false),
                        Registro = c.Int(nullable: false),
                        Inativo = c.Boolean(nullable: false),
                        Operador_Id = c.Int(),
                        Emprestimo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Operador_Id)
                .ForeignKey("dbo.Emprestimos", t => t.Emprestimo_Id)
                .Index(t => t.Operador_Id)
                .Index(t => t.Emprestimo_Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Usuario = c.String(),
                        Cpf = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ocorrencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        DataOcorrencia = c.DateTime(nullable: false),
                        Registro = c.Int(nullable: false),
                        PrevisaoRetorno = c.DateTime(nullable: false),
                        Equipamento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipamentos", t => t.Equipamento_Id)
                .Index(t => t.Equipamento_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ocorrencias", "Equipamento_Id", "dbo.Equipamentos");
            DropForeignKey("dbo.Emprestimos", "Usuario_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Emprestimos", "Operador_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Equipamentos", "Emprestimo_Id", "dbo.Emprestimos");
            DropForeignKey("dbo.Equipamentos", "Operador_Id", "dbo.Pessoas");
            DropIndex("dbo.Ocorrencias", new[] { "Equipamento_Id" });
            DropIndex("dbo.Equipamentos", new[] { "Emprestimo_Id" });
            DropIndex("dbo.Equipamentos", new[] { "Operador_Id" });
            DropIndex("dbo.Emprestimos", new[] { "Usuario_Id" });
            DropIndex("dbo.Emprestimos", new[] { "Operador_Id" });
            DropTable("dbo.Ocorrencias");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Equipamentos");
            DropTable("dbo.Emprestimos");
        }
    }
}
