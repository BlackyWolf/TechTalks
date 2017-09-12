using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data.Sources
{
    public class InvoiceSource : ISource<Invoice>
    {
        private static ICollection<Invoice> invoices;

        public InvoiceSource()
        {
            if (invoices == null) invoices = new List<Invoice>();
        }

        public void Add(Invoice entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.Id = invoices.Count < 1 ? 1 : invoices.Count + 1;

            invoices.Add(entity);
        }

        public Invoice Read<TKey>(TKey key)
        {
            int.TryParse(key.ToString(), out int id);

            return invoices.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Invoice> Read()
        {
            return invoices;
        }

        public IEnumerable<Invoice> Read(int skip, int take)
        {
            return invoices.Skip(skip).Take(take);
        }

        public void Remove(Invoice entity)
        {
            invoices.Remove(entity);
        }

        public void Update(Invoice entity)
        {

        }

        public IEnumerator<Invoice> GetEnumerator()
        {
            return invoices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return invoices.GetEnumerator();
        }
    }
}