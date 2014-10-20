using FluentMigrator;

namespace MyProject.Data.Migrations._1._0._1._0
{
    [Migration(201410192200)]
    public class CreateTestTable : Migration
    {
        public override void Up()
        {
            Create.Table("Test")
                  .WithColumn("Id").AsGuid().NotNullable().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table("Test"); ;
        }
    }
}