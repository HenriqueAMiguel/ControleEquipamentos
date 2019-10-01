namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao0101 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Equipamentos", "DataRegistro");
            DropColumn("dbo.Equipamentos", "Registro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipamentos", "Registro", c => c.Int(nullable: false));
            AddColumn("dbo.Equipamentos", "DataRegistro", c => c.DateTime(nullable: false));
        }
    }
}
