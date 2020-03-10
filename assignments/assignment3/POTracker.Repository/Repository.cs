/* Repository.cs
 *  Repository for CRUD files
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.10: Created
 */
using System;
using System.Collections.Generic;

namespace PurchaseOrder.Repository
{
    /// <summary>
    /// Repository allows the persistence and retrieval of saved data, including changing the data.
    /// 
    /// The Repository implements a simple CRUD operations from ICRUD
    /// </summary>
    public class Repository<Purchase> : ICRUD<Purchase>
    {
        public Purchase Create(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Purchase GetId(int id)
        {
            throw new NotImplementedException();
        }

        public Purchase Update(Purchase entity)
        {
            throw new NotImplementedException();
        }
    }
}
