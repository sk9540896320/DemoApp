namespace DemoApp.Business.Group.Models
{
    /// <summary>
    /// Defines the <see cref="GroupUpdateModel" />.
    /// </summary>
    public class GroupUpdateModel : GroupCreateModel, IModelWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUpdateModel"/> class.
        /// </summary>
        public GroupUpdateModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUpdateModel"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="isNotifySubAdmins">The isNotifySubAdmins<see cref="bool"/>.</param>
        /// <param name="isNotifyFullAdmins">The isNotifyFullAdmins<see cref="bool?"/>.</param>
        /// <param name="isNotifyComments">The isNotifyComments<see cref="bool?"/>.</param>
        /// <param name="isNotifySignatures">The isNotifySignatures<see cref="bool?"/>.</param>
        /// <param name="isNotifyForms">The isNotifyForms<see cref="bool?"/>.</param>
        public GroupUpdateModel(long id, string name, bool isNotifySubAdmins, bool? isNotifyFullAdmins = null,
            bool? isNotifyComments = null, bool? isNotifySignatures = null, bool? isNotifyForms = null)
            : base(name, isNotifySubAdmins, isNotifyFullAdmins, isNotifyComments, isNotifySignatures, isNotifyForms)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public long Id { get; set; }
    }
}
