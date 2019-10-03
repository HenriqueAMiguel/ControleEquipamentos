namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracao0401 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "Sexo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoas", "Sexo");
        }
    }
}
