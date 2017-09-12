using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Data.Sources
{
    public class ProductSource : ISource<Product>
    {
        private static ICollection<Product> products;

        public ProductSource()
        {
            if (products == null) products = new List<Product>();
        }

        public void Add(Product entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.Id = products.Count < 1 ? 1 : products.Count + 1;

            products.Add(entity);
        }

        public Product Read<TKey>(TKey key)
        {
            int.TryParse(key.ToString(), out int id);

            return products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> Read()
        {
            return products;
        }

        public IEnumerable<Product> Read(int skip, int take)
        {
            return products.Skip(skip).Take(take);
        }

        public void Remove(Product entity)
        {
            products.Remove(entity);
        }

        public void Update(Product entity)
        {

        }

        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}