using FluentMigrator;
using System;

namespace MyProject.Data.Migrations._1._0._1._0
{
    [Migration(201410192215)]
    public class CreateTestTableSeedData : Migration
    {
        public override void Up()
        {
            if ((MigratorEnvironment)this.ApplicationContext == MigratorEnvironment.Development)
            {
                Insert.IntoTable("Test").Row(new { Id = Guid.NewGuid(), Test = "Test 01" });
                Insert.IntoTable("Test").Row(new { Id = Guid.NewGuid(), Test = "Test 02" });
                Insert.IntoTable("Test").Row(new { Id = Guid.NewGuid(), Test = "Test 03" });
                Insert.IntoTable("Test").Row(new { Id = Guid.NewGuid(), Test = "Test 04" });
                Insert.IntoTable("Test").Row(new { Id = Guid.NewGuid(), Test = "Test 05" });
            }
        }

        public override void Down()
        {
        }
    }
}