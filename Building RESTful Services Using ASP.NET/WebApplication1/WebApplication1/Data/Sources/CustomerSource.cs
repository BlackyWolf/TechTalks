using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data.Sources
{
    public class CustomerSource : ISource<Customer>
    {
        private static ICollection<Customer> customers;

        public CustomerSource()
        {
            if (customers == null) customers = new List<Customer>();
        }

        public void Add(Customer entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.Id = customers.Count < 1 ? 1 : customers.Count + 1;

            customers.Add(entity);
        }

        public Customer Read<TKey>(TKey key)
        {
            int.TryParse(key.ToString(), out int id);

            return customers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> Read()
        {
            return customers;
        }

        public IEnumerable<Customer> Read(int skip, int take)
        {
            return customers.Skip(skip).Take(take);
        }

        public void Remove(Customer entity)
        {
            customers.Remove(entity);
        }

        public void Update(Customer entity)
        {

        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return customers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return customers.GetEnumerator();
        }
    }
}