namespace DemoApp.Business.Group
{
    /// <summary>
    /// Defines the GroupErrorCode.
    /// </summary>
    public enum GroupErrorCode
    {
        /// <summary>
        /// Unknown error
        /// </summary>
        UnknownError = 0,
        /// <summary>
        /// The identifier must be greater than zero
        /// </summary>
        IdMustBeGreaterThanZero,
        /// <summary>
        /// The identifier does not exist
        /// </summary>
        IdDoesNotExist,
        /// <summary>
        /// The iso code required
        /// </summary>
        IsoCodeRequired,
        /// <summary>
        /// The iso code too long
        /// </summary>
        IsoCodeTooLong,
        /// <summary>
        /// Iso Code not unique
        /// </summary>
        IsoCodeNotUnique,
        /// <summary>
        /// State is Attached to this country
        /// </summary>
        StateAttached,
        /// <summary>
        /// The name is required
        /// </summary>
        NameRequired,
        /// <summary>
        /// The name is too long
        /// </summary>
        NameTooLong,
        /// <summary>
        /// Id not unique
        /// </summary>
        IdNotUnique,
        /// <summary>
        /// The Code is required
        /// </summary>
        CodeRequired,
        /// <summary>
        /// The Code is too long
        /// </summary>
        CodeTooLong,
        /// <summary>
        /// The Description is required
        /// </summary>
        DescriptionRequired,
        /// <summary>
        /// The Description is too long
        /// </summary>
        DescriptionTooLong,
        /// <summary>
        /// Code not unique
        /// </summary>
        CodeNotUnique,
        /// <summary>
        /// MasterKey not unique
        /// </summary>
        MasterKeyNotUnique,
        /// <summary>
        /// Name not unique
        /// </summary>
        NameNotUnique
    }
}
