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
        
        /// <summary>
        /// Creates a new Memor InMemoryRepository with the values from the supplied non-empty list
        /// </summary>
        /// <param name="list">List of Items from the memory</param>
        public InMemoryRepository(List<Purchase> list)
        {
            this.MemoryDB = new Dictionary<int, Purchase>();

            if (list.Count > 0)
            {
                list.ForEach(e => MemoryDB.Add(e.GetId(), e));
            }
        }

        #region CRUD
        #region Creation
        public Purchase Create(Purchase entity)
        {
            if (MemoryDB.ContainsKey(entity.GetId()))
            {
                throw new ArgumentException("Database already contains this value.");
            }
            MemoryDB.Add(entity.GetId(), entity);
            return entity.Copy();
        }
        #endregion
        #region Read
        public List<Purchase> GetAll()
        {
            if (MemoryDB.Count == 0)
            {
                return new List<Purchase>();
            }
            List<int> sortedKeys = MemoryDB.Keys.ToList();
            sortedKeys.Sort();
            var sortedOrders = new List<Purchase>();
            foreach (int key in sortedKeys)
            {
                sortedOrders.Add(MemoryDB[key]);
            }
            return sortedOrders;
        }

        public Purchase GetById(int id)
        {
            if (MemoryDB.ContainsKey(id))
            {
                return MemoryDB[id].Copy();

            }
            throw new ArgumentException("Database doesn't contain this value.");

        }

        public bool HasItem(Purchase entity) => 
            this.MemoryDB.ContainsKey(entity.GetId());
        #endregion
        #region Update
        /// <summary>
        /// Updates the purchase information.
        /// </summary>
        /// <param name="pruchase">The entity that will be updated.</param>
        /// <returns>True IFF the operation updates the value.</returns>
        public bool Update(Purchase pruchase)
        {
            if (MemoryDB.ContainsKey(pruchase.GetId()))
            {
                MemoryDB[pruchase.GetId()] = pruchase;
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public bool Delete(int id)
        {
            if (!MemoryDB.ContainsKey(id))
            {
                return false;
            }

            return MemoryDB.Remove(id);
        }
        #endregion
        #endregion

        public int Size() => 
            this.MemoryDB.Keys.Count;
    }
}
