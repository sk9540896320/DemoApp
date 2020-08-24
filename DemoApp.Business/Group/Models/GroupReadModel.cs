namespace DemoApp.Business.Group.Models
{
    /// <summary>
    /// Defines the <see cref="GroupReadModel" />.
    /// </summary>
    public class GroupReadModel : GroupUpdateModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupReadModel"/> class.
        /// </summary>
        public GroupReadModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupReadModel"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="isNotifySubAdmins">The isNotifySubAdmins<see cref="bool"/>.</param>
        /// <param name="isNotifyFullAdmins">The isNotifyFullAdmins<see cref="bool?"/>.</param>
        /// <param name="isNotifyComments">The isNotifyComments<see cref="bool?"/>.</param>
        /// <param name="isNotifySignatures">The isNotifySignatures<see cref="bool?"/>.</param>
        /// <param name="isNotifyForms">The isNotifyForms<see cref="bool?"/>.</param>
        public GroupReadModel(long id, string name, bool isNotifySubAdmins, bool? isNotifyFullAdmins = null,
            bool? isNotifyComments = null, bool? isNotifySignatures = null, bool? isNotifyForms = null)
            : base(id, name, isNotifySubAdmins, isNotifyFullAdmins, isNotifyComments, isNotifySignatures, isNotifyForms)
        {
        }

        /// <summary>
        /// Gets or sets the MemberCount.
        /// </summary>
        public int MemberCount { get; set; }
    }
}
