namespace DemoApp.DataAccess
{
    using Demo.Framework.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DemoDbContext : BaseDbContext<DemoDbContext>
    {
        public const string DefaultSchemaName = "Demo";

        public const string DefaultMigrationTableName = "migrations";        

        public DemoDbContext(DbContextOptions<DemoDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public override string SchemaName
        {
            get { return DefaultSchemaName; }
        }

        public override string MigrationTableName
        {
            get { return DefaultMigrationTableName; }
        }

        public override Assembly[] GetTypeAssemblies()
        {
            return new[] { typeof(DemoDbContext).Assembly };
        }
    }
}
