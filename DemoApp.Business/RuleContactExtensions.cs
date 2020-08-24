namespace DemoApp.Business
{
    using System;

    /// <summary>
    /// Defines the <see cref="RuleContactExtensions" />.
    /// </summary>
    public static class RuleContactExtensions
    {
        /// <summary>
        /// The CustomNameRelatedValidation.
        /// </summary>
        /// <typeparam name="TModel">.</typeparam>
        /// <param name="ruleBuilder">The ruleBuilder<see cref="IRuleBuilder{TModel, string}"/>.</param>
        /// <param name="nameRequired">The nameRequired<see cref="Enum"/>.</param>
        /// <param name="nameTooLong">The nameTooLong<see cref="Enum"/>.</param>
        /// <param name="maximumLength">The maximumLength<see cref="int"/>.</param>
        /// <returns>The <see cref="IRuleBuilderOptions{TModel, string}"/>.</returns>
        public static IRuleBuilderOptions<TModel, string> CustomNameRelatedValidation<TModel>(this IRuleBuilder<TModel, string> ruleBuilder, Enum nameRequired, Enum nameTooLong, int maximumLength = DataLengths.Name)
            where TModel : class, IModel
        {
            return ruleBuilder
                .NotEmpty().WithErrorEnum(nameRequired)
                .MaximumLength(maximumLength).WithErrorEnum(nameTooLong);
        }

        /// <summary>
        /// The CustomNameMaxLengthValidation.
        /// </summary>
        /// <typeparam name="TModel">.</typeparam>
        /// <param name="ruleBuilder">The ruleBuilder<see cref="IRuleBuilder{TModel, string}"/>.</param>
        /// <param name="nameTooLong">The nameTooLong<see cref="Enum"/>.</param>
        /// <param name="maximumLength">The maximumLength<see cref="int"/>.</param>
        /// <returns>The <see cref="IRuleBuilderOptions{TModel, string}"/>.</returns>
        public static IRuleBuilderOptions<TModel, string> CustomNameMaxLengthValidation<TModel>(this IRuleBuilder<TModel, string> ruleBuilder, Enum nameTooLong, int maximumLength = DataLengths.Name)
            where TModel : class, IModel
        {
            return ruleBuilder
                .MaximumLength(maximumLength).WithErrorEnum(nameTooLong);
        }
    }
}
