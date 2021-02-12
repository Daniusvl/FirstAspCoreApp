using System.Collections.Generic;

namespace Terabaitas.Core
{
    public interface IDbAccess<TEntity>
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        TEntity Get(int i);
        public List<TEntity> GetAll();
        void Remove(TEntity entity);
    }
}
