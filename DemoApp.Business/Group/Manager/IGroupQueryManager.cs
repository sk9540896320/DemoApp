namespace DemoApp.Business.Group.Manager
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IGroupQueryManager" />.
    /// </summary>
    public interface IGroupQueryManager : ITenantIdQueryManager<GroupErrorCode, GroupReadModel>
    {
        /// <summary>
        /// The GetByNamesAsync.
        /// </summary>
        /// <param name="tenantId">The tenantId<see cref="long"/>.</param>
        /// <param name="searchTerm">The searchTerm<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ManagerResponseTyped{GroupErrorCode, GroupSearchReadModel}}"/>.</returns>
        Task<ManagerResponseTyped<GroupErrorCode, GroupSearchReadModel>> GetByNamesAsync(long tenantId, string searchTerm);

        /// <summary>
        /// The GetGroupListingAsync.
        /// </summary>
        /// <param name="tenantIds">The tenantIds<see cref="IEnumerable{long}"/>.</param>
        /// <returns>The <see cref="Task{ManagerResponseTyped{GroupErrorCode, GroupListingReadModel}}"/>.</returns>
        Task<ManagerResponseTyped<GroupErrorCode, GroupListingReadModel>> GetGroupListingAsync(IEnumerable<long> tenantIds);
    }
}
