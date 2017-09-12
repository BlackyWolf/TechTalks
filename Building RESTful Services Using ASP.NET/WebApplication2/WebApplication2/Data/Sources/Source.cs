using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Data.Sources
{
    public class Source<TEntity> : ISource<TEntity> where TEntity : class, new()
    {
        private static ICollection<TEntity> entities;

        public Source()
        {
            if (entities == null) entities = new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var id = entities.Count < 1 ? 1 : entities.Count + 1;

            entity.GetType().GetProperty("Id")?.SetValue(id, entity);

            entities.Add(entity);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        public TEntity Read<TKey>(TKey key)
        {
            return entities.FirstOrDefault(
                x => x.GetType().GetProperty("Id")?.GetValue(x) == (object)key);
        }

        public IEnumerable<TEntity> Read()
        {
            return entities;
        }

        public IEnumerable<TEntity> Read(int skip, int take)
        {
            return entities.Skip(skip).Take(take);
        }

        public void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            //
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }
    }
}