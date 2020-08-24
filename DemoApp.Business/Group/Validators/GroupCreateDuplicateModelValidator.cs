namespace DemoApp.Business.Group.Validators
{
    /// <summary>
    /// Defines the <see cref="GroupCreateDuplicateModelValidator" />.
    /// </summary>
    public sealed class GroupCreateDuplicateModelValidator : ModelValidator<GroupCreateDuplicateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCreateDuplicateModelValidator"/> class.
        /// </summary>
        public GroupCreateDuplicateModelValidator()
        {
            RuleFor(groupCreateDuplicateModel => groupCreateDuplicateModel.Id).IdValidation(GroupErrorCode.IdMustBeGreaterThanZero);
        }
    }
}
