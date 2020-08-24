namespace DemoApp.DataAccess.Configuration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Defines the <see cref="GroupConfiguration" />.
    /// </summary>
    public class GroupConfiguration : EntityWithIdTenantIdNameConfiguration<Group>
    {
        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="entityTypeBuilder">The entityTypeBuilder<see cref="EntityTypeBuilder{Group}"/>.</param>
        public override void Configure(EntityTypeBuilder<Group> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(group => group.IsNotifyFullAdmins)
               .IsRequired(false);
            entityTypeBuilder.Property(group => group.IsNotifySubAdmins)
               .IsRequired();
            entityTypeBuilder.Property(group => group.IsNotifyComments)
               .IsRequired(false);
            entityTypeBuilder.Property(group => group.IsNotifySignatures)
               .IsRequired(false);
            entityTypeBuilder.Property(group => group.IsNotifyPolls)
               .IsRequired(false);
            entityTypeBuilder.HasIndex(group => new { group.TenantId, group.Name }).IsUnique();
        }
    }
}
