using System.Collections.Generic;

namespace Terabaitas.Data.Repositories.Abstract
{
    public interface IEntityRepository<TEntity>
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        TEntity Get(int i);
        List<TEntity> GetAll();
        void Remove(TEntity entity);
    }
}
