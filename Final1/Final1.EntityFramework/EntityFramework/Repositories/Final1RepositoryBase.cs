using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Final1.EntityFramework.Repositories
{
    public abstract class Final1RepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<Final1DbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected Final1RepositoryBase(IDbContextProvider<Final1DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class Final1RepositoryBase<TEntity> : Final1RepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected Final1RepositoryBase(IDbContextProvider<Final1DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
