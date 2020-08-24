namespace DemoApp.DataAccess.Repository
{
    using Demo.Framework.DataAccess.Repository;
    using Entity.Entities;

    /// <summary>
    /// Defines the <see cref="IGroupCommandRepository" />.
    /// </summary>
    public interface IGroupCommandRepository : IGenericCommandRepository<DemoDbContext, Group>
    {
    }
}
