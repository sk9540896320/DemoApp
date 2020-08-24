namespace DemoApp.Business.Group.Models
{

    /// <summary>
    /// Defines the <see cref="GroupCreateDuplicateModel" />.
    /// </summary>
    public class GroupCreateDuplicateModel : ModelWithName, IModelWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCreateDuplicateModel"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <param name="name">The name<see cref="string"/>.</param>
        public GroupCreateDuplicateModel(long id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public long Id { get; set; }
    }
}