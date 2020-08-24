namespace DemoApp.Entity.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Group" />.
    /// </summary>
    public class Group : EntityWithIdTenantIdName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        public Group()
        {
            ContactGroups = new List<ContactGroup>();
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
        /// Gets or sets the ContactGroups.
        /// </summary>
        public IList<ContactGroup> ContactGroups { get; set; }
    }
}
