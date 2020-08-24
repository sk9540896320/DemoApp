namespace DemoApp.Business.Group.Validators
{
    using Models;

    /// <summary>
    /// Defines the <see cref="GroupUpdateModelValidator" />.
    /// </summary>
    public class GroupUpdateModelValidator : GroupBaseModelValidator<GroupUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUpdateModelValidator"/> class.
        /// </summary>
        public GroupUpdateModelValidator()
        {
            RuleFor(groupUpdateModel => groupUpdateModel.Id).IdValidation(GroupErrorCode.IdMustBeGreaterThanZero);
        }
    }
}
