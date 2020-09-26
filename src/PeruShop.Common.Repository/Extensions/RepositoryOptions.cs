namespace PeruShop.Common.Repository
{
    using System.Collections.Generic;

    public class RepositoryOptions<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> Seed { get; set; }
    }
}