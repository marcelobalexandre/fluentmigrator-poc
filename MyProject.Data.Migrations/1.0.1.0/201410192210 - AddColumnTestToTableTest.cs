using FluentMigrator;

namespace MyProject.Data.Migrations._1._0._1._0
{
    [Migration(201410192210)]
    public class AddColumnTestToTableTest : Migration
    {
        public override void Up()
        {
            Alter.Table("Test")
                 .AddColumn("Test").AsString(255).NotNullable();
        }

        public override void Down()
        {
            Delete.Column("Test").FromTable("Test");
        }
    }
}