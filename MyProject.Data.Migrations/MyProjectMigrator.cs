using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;
using System;
using System.Reflection;

namespace MyProject.Data.Migrations
{
    public enum MigratorEnvironment
    {
        Development,
        Test,
        Production
    }

    public static class MyProjectMigrator
    {
        private class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }

            public int Timeout { get; set; }

            public string ProviderSwitches
            {
                get { throw new NotImplementedException(); }
            }
        }

        public static void Migrate(Action<IMigrationRunner> migrationRunnerAction,
                                   string connectionString,
                                   MigratorEnvironment migratorEnvironment)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var textWriterAnnouncer = new TextWriterAnnouncer(write => Console.WriteLine(write));
            var runnerContext = new RunnerContext(textWriterAnnouncer);
            runnerContext.ApplicationContext = migratorEnvironment;

            var migrationOptions = new MigrationOptions { PreviewOnly = false, Timeout = 0 };
            var processorFactory = new SqlServer2012ProcessorFactory();
            var processor = processorFactory.Create(connectionString,
                                                    textWriterAnnouncer,
                                                    migrationOptions);

            var migrationRunner = new MigrationRunner(assembly, runnerContext, processor);
            migrationRunnerAction(migrationRunner);
        }
    }
}