using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseOrder.Repository
{
    class InMemoryRepository : IRepository<Purchase>
    {
        private readonly Dictionary<Purchase, String> MemoryDB;

        /// <summary>
        /// Creates a new Memor InMemoryRepository with the values from the supplied non-empty list
        /// </summary>
        /// <param name="list">List of Items from the memory</param>
        public InMemoryRepository(List<Purchase> list)
        {
            this.MemoryDB = new Dictionary<Purchase, string>();
            list.ForEach(e => MemoryDB.Add(e, ""));
        }

        public Purchase Create(Purchase entity)
        {
            if (MemoryDB.ContainsKey(entity))
            {
                throw new ArgumentException("Database already contains this value.");
            }
            MemoryDB.Add(entity,"");
            return entity.Copy();
        }

        public bool Delete(Purchase entity)
        {
            if (!MemoryDB.ContainsKey(entity))
            {
                throw new ArgumentException("Database doesn't contain this value.");
            }

            return MemoryDB.Remove(entity);
        }

        public List<Purchase> GetAll()
        {
            if (MemoryDB.Count == 0)
            {
                return new List<Purchase>();
            }
            return MemoryDB.Keys.ToList();
        }

        public Purchase GetById(int id)
        {
            foreach (var order in MemoryDB.Keys)
            {
                if (order.GetId() == id)
                {
                    return order.Copy();
                }
            }
            throw new ArgumentException("Database doesn't contain this value.");

        }

        public bool HasItem(Purchase entity) => this.MemoryDB.ContainsKey(entity);

        public Purchase Update(Purchase entity)
        {
            if (MemoryDB.ContainsKey(entity))
            {
                MemoryDB.Add(entity,"");
                return entity.Copy();
            }
            throw new ArgumentException("Database doesn't contain this value.");
        }
    }
}
