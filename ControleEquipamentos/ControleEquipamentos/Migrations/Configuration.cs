﻿namespace ControleEquipamentos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleEquipamentos.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ControleEquipamentos.Models.Context";
        }

        protected override void Seed(ControleEquipamentos.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
