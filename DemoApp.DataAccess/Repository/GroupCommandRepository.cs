namespace DemoApp.DataAccess.Repository
{
    using DataAccess;

    /// <summary>
    /// Defines the <see cref="GroupCommandRepository" />.
    /// </summary>
    public class GroupCommandRepository : GenericCommandRepository<DemoDbContext, DemoReadOnlyDbContext, Group>, IGroupCommandRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCommandRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="DemoDbContext"/>.</param>
        /// <param name="queryRepository">The queryRepository<see cref="IGroupQueryRepository"/>.</param>
        public GroupCommandRepository(DemoDbContext dbContext, IGroupQueryRepository queryRepository)
            : base(dbContext, queryRepository)
        {
            EnsureArg.IsNotNull(queryRepository, nameof(queryRepository));
        }
    }
}
