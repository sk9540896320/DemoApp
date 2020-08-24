namespace DemoApp.Business.Group.Manager
{
    using Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IGroupCommandManager" />.
    /// </summary>
    public interface IGroupCommandManager : ITenantIdCommandManager<GroupErrorCode, GroupCreateModel, GroupUpdateModel>
    {
        /// <summary>
        /// The CloneAsync.
        /// </summary>
        /// <param name="tenantId">The tenantId<see cref="long"/>.</param>
        /// <param name="groupCreateDuplicateModel">The groupCreateDuplicateModel<see cref="GroupCreateDuplicateModel"/>.</param>
        /// <returns>The <see cref="Task{ManagerResponse{GroupErrorCode}}"/>.</returns>
        Task<ManagerResponse<GroupErrorCode>> CloneAsync(long tenantId, GroupCreateDuplicateModel groupCreateDuplicateModel);
    }
}
