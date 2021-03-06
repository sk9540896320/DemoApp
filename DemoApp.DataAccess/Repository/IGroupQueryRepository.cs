﻿namespace DemoApp.DataAccess.Repository
{
    using Demo.Framework.DataAccess.Repository;
    using Entity.Entities;

    /// <summary>
    /// Defines the <see cref="IGroupQueryRepository" />.
    /// </summary>
    public interface IGroupQueryRepository : IGenericQueryRepository<DemoReadOnlyDbContext, Group>
    {
    }
}
