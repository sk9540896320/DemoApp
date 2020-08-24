namespace DemoApp.Business.Group.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Defines the <see cref="GroupCreateModel" />.
    /// </summary>
    public class GroupCreateModel : ModelWithName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCreateModel"/> class.
        /// </summary>
        public GroupCreateModel()
        {
            ContactGroupCreateModels = new List<ContactGroupCreateModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCreateModel"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="isNotifySubAdmins">The isNotifySubAdmins<see cref="bool"/>.</param>
        /// <param name="isNotifyFullAdmins">The isNotifyFullAdmins<see cref="bool?"/>.</param>
        /// <param name="isNotifyComments">The isNotifyComments<see cref="bool?"/>.</param>
        /// <param name="isNotifySignatures">The isNotifySignatures<see cref="bool?"/>.</param>
        /// <param name="isNotifyPolls">The isNotifyPolls<see cref="bool?"/>.</param>
        public GroupCreateModel(string name, bool isNotifySubAdmins, bool? isNotifyFullAdmins = null,
            bool? isNotifyComments = null, bool? isNotifySignatures = null, bool? isNotifyPolls = null)
            : this()
        {
            Name = name;
            IsNotifyFullAdmins = isNotifyFullAdmins;
            IsNotifySubAdmins = isNotifySubAdmins;
            IsNotifyComments = isNotifyComments;
            IsNotifySignatures = isNotifySignatures;
            IsNotifyPolls = isNotifyPolls;
        }

        /// <summary>
        /// Gets or sets the IsNotifyFullAdmins.
        /// </summary>
        public bool? IsNotifyFullAdmins { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsNotifySubAdmins.
        /// </summary>
        public bool IsNotifySubAdmins { get; set; }

        /// <summary>
        /// Gets or sets the IsNotifyComments.
        /// </summary>
        public bool? IsNotifyComments { get; set; }

        /// <summary>
        /// Gets or sets the IsNotifySignatures.
        /// </summary>
        public bool? IsNotifySignatures { get; set; }

        /// <summary>
        /// Gets or sets the IsNotifyPolls.
        /// </summary>
        public bool? IsNotifyPolls { get; set; }

        /// <summary>
        /// Gets or sets the ContactGroupCreateModels.
        /// </summary>
        [JsonIgnore]
        public IList<ContactGroupCreateModel> ContactGroupCreateModels { get; set; }
    }
}
