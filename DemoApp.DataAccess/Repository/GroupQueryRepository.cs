namespace DemoApp.DataAccess.Repository
{
    using DataAccess;

    /// <summary>
    /// Defines the <see cref="GroupQueryRepository" />.
    /// </summary>
    public class GroupQueryRepository : GenericQueryRepository<DemoReadOnlyDbContext, Group>, IGroupQueryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupQueryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="DemoReadOnlyDbContext"/>.</param>
        public GroupQueryRepository(DemoReadOnlyDbContext dbContext) :
            base(dbContext)
        {
        }
    }
}
