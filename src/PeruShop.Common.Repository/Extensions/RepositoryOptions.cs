namespace PeruShop.Common.Repository
{
    using System;
    using System.Collections.Generic;

    public class RepositoryOptions<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Seed { get; set; }
    }
}