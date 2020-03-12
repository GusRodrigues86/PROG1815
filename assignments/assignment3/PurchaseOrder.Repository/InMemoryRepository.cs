using PurchaseOrder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseOrder.Repository
{
    public class InMemoryRepository : IRepository<Purchase>
    {
        private readonly Dictionary<int, Purchase> MemoryDB;
        private int lastIndex;
        /// <summary>
        /// Creates a new Memor InMemoryRepository with the values from the supplied non-empty list
        /// </summary>
        /// <param name="list">List of Items from the memory</param>
        public InMemoryRepository(List<Purchase> list)
        {
            this.MemoryDB = new Dictionary<int, Purchase>();
            this.lastIndex = 0;

            if (list.Count > 0)
            {
                list.ForEach(e => MemoryDB.Add(e.GetId(), e));
            }
        }

        public Purchase Create(Purchase entity)
        {
            if (MemoryDB.ContainsKey(entity.GetId()))
            {
                throw new ArgumentException("Database already contains this value.");
            }
            MemoryDB.Add(entity.GetId(), entity);
            lastIndex++;
            return entity.Copy();
        }

        public bool Delete(Purchase entity)
        {
            if (!MemoryDB.ContainsKey(entity.GetId()))
            {
                throw new ArgumentException("Database doesn't contain this value.");
            }

            return MemoryDB.Remove(entity.GetId());
        }

        public List<Purchase> GetAll()
        {
            if (MemoryDB.Count == 0)
            {
                return new List<Purchase>();
            }
            return MemoryDB.Values.ToList();
        }

        public Purchase GetById(int id)
        {
            if (MemoryDB.ContainsKey(id))
            {
                return MemoryDB[id].Copy();

            }
            throw new ArgumentException("Database doesn't contain this value.");

        }

        public bool HasItem(Purchase entity) => this.MemoryDB.ContainsValue(entity);

        public int Size() => this.MemoryDB.Keys.Count;

        public Purchase Update(Purchase entity)
        {
            if (MemoryDB.ContainsKey(entity.GetId()))
            {
                MemoryDB.Remove(entity.GetId());
                MemoryDB.Add(entity.GetId(), entity);
                return entity.Copy();
            }
            throw new ArgumentException("Database doesn't contain this value.");
        }
    }
}
