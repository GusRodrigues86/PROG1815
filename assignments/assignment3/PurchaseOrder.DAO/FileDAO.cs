using System;
using System.Collections.Generic;

namespace PurchaseOrder.DAL
{
    /// <summary>
    /// The PurchaseFileDAO will interact with the Persistence unit to perform basic CRUD operations.
    /// </summary>
    /// <typeparam name="Purchase"></typeparam>
    public class PurchaseFileDAO<Purchase> : IDAO<Purchase>
    {
        // Needs a DataSource injected.
        public Purchase Create(Purchase entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Purchase entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Purchase> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Purchase GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Purchase Update(Purchase entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
