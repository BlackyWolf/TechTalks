using System.Collections.Generic;

namespace WebApplication2.Data
{
    public interface ISource<TEntity> : IEnumerable<TEntity> where TEntity : class, new()
    {
        void Add(TEntity entity);

        TEntity Read<TKey>(TKey key);

        IEnumerable<TEntity> Read();

        void Remove(TEntity entity);

        void Update(TEntity entity);
    }
}