using MyProject.Data.Migrations;
using System;

namespace MyProjectMigratorRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting migration...");

            string connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", ".", "MyProject");
            var environment = MigratorEnvironment.Production;
#if DEBUG
            environment = MigratorEnvironment.Development;
#endif

            try
            {
                MyProjectMigrator.Migrate(migrationRunner => migrationRunner.MigrateUp(),
                                          connectionString,
                                          environment);

                Console.WriteLine("Finished migration.");
                Console.Read();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("\nFinished migration with errors.");
                Console.Read();
            }
        }
    }
}