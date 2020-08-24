namespace DemoApp.Business.Group.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="GroupSearchReadModel" />.
    /// </summary>
    public class GroupSearchReadModel : ModelWithName, IModelWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupSearchReadModel"/> class.
        /// </summary>
        public GroupSearchReadModel()
        {
            ContactGroups = new List<ContactGroupSearchReadModel>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the ContactGroups.
        /// </summary>
        public IEnumerable<ContactGroupSearchReadModel> ContactGroups { get; set; }
    }
}
