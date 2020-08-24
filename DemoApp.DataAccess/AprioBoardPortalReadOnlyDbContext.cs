namespace DemoApp.DataAccess
{
    using Demo.Framework.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DemoReadOnlyDbContext : BaseReadOnlyDbContext<DemoReadOnlyDbContext>
    {

        public DemoReadOnlyDbContext(DbContextOptions<DemoReadOnlyDbContext> options)
            : base(options)
        {
        }

        public override string SchemaName => DemoDbContext.DefaultSchemaName;

        public override string MigrationTableName => DemoDbContext.DefaultMigrationTableName;

        public override Assembly[] GetTypeAssemblies()
        {
            return new[] { typeof(DemoReadOnlyDbContext).Assembly };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
