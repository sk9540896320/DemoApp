namespace DemoApp.Business.Group.Models
{
    /// <summary>
    /// Defines the <see cref="GroupListing" />.
    /// </summary>
    public class GroupListingReadModel : ModelWithName, IModelWithId
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public long Id { get; set; }
    }
}
