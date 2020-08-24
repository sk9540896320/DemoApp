namespace DemoApp.Constant.Extensions
{
    using System;

    /// <summary>
    /// Defines the <see cref="DateTimeExtensions" />.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// The Between.
        /// </summary>
        /// <param name="value">The value<see cref="DateTime"/>.</param>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool Between(this DateTime value, DateTime startDate, DateTime endDate)
        {
            return value >= startDate && value <= endDate;
        }

        /// <summary>
        /// The Between.
        /// </summary>
        /// <param name="value">The value<see cref="DateTime?"/>.</param>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool Between(this DateTime? value, DateTime startDate, DateTime endDate)
        {
            return !value.HasValue || Between(value.Value, startDate, endDate);
        }

        /// <summary>
        /// The NotBetween.
        /// </summary>
        /// <param name="value">The value<see cref="DateTime"/>.</param>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool NotBetween(this DateTime value, DateTime startDate, DateTime endDate)
        {
            return value < startDate || value > endDate;
        }

        /// <summary>
        /// The NotBetween.
        /// </summary>
        /// <param name="value">The value<see cref="DateTime?"/>.</param>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool NotBetween(this DateTime? value, DateTime startDate, DateTime endDate)
        {
            return value.HasValue && NotBetween(value.Value, startDate, endDate);
        }
    }
}
