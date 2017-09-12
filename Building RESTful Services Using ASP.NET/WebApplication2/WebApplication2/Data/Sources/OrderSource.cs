using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Data.Sources
{
    public class OrderSource : ISource<Order>
    {
        private static ICollection<Order> orders;

        public OrderSource()
        {
            if (orders == null) orders = new List<Order>();
        }

        public void Add(Order entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.Id = orders.Count < 1 ? 1 : orders.Count + 1;

            orders.Add(entity);
        }

        public Order Read<TKey>(TKey key)
        {
            int.TryParse(key.ToString(), out int id);

            return orders.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> Read()
        {
            return orders;
        }

        public IEnumerable<Order> Read(int skip, int take)
        {
            return orders.Skip(skip).Take(take);
        }

        public void Remove(Order entity)
        {
            orders.Remove(entity);
        }

        public void Update(Order entity)
        {

        }

        public IEnumerator<Order> GetEnumerator()
        {
            return orders.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return orders.GetEnumerator();
        }
    }
}