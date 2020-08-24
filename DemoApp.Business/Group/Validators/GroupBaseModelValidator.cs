namespace DemoApp.Business.Group.Validators
{
    using Models;

    /// <summary>
    /// Defines the <see cref="GroupBaseModelValidator{TGroupCreateModel}" />.
    /// </summary>
    /// <typeparam name="TGroupCreateModel">.</typeparam>
    public abstract class GroupBaseModelValidator<TGroupCreateModel> : ModelValidator<TGroupCreateModel> where TGroupCreateModel : GroupCreateModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupBaseModelValidator{TGroupCreateModel}"/> class.
        /// </summary>
        protected GroupBaseModelValidator()
        {
            RuleFor(groupCreateModel => groupCreateModel.Name)
                .CustomStringLengthValidationWithRquired(GroupErrorCode.NameRequired, GroupErrorCode.NameTooLong);
        }
    }
}
