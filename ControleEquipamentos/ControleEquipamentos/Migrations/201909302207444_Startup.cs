namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Startup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Nascimento", c => c.DateTime());
            DropColumn("dbo.Pessoas", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pessoas", "Tipo", c => c.Int(nullable: false));
            AlterColumn("dbo.Pessoas", "Nascimento", c => c.DateTime(nullable: false));
        }
    }
}
