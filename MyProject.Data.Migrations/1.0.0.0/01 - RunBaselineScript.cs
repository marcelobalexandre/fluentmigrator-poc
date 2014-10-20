using FluentMigrator;
using System;
using System.IO;

namespace MyProject.Data.Migrations._1._0._0._0
{
    [Migration(01)]
    public class RunBaselineScript : Migration
    {
        public override void Up()
        {
            Execute.Script(Path.Combine(Environment.CurrentDirectory, @"Scripts\02 - BaselineScrit.sql"));
        }

        public override void Down()
        {
        }
    }
}