/* ICRUD.cs
 *  Interface describing the behaviour for simple CRUD
 *  Create, Read, Update and Delete
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.10: Created
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Repository
{
    /// <summary>
    /// ICRUD describe the simple behaviour expected from CRUD Repositories.
    /// </summary>
    interface ICRUD<T>
    {
        /// <summary>
        /// Retrieves all items persisted
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        /// <summary>
        /// Retrieves entity By ID
        /// </summary>
        /// <param name="id">The entity ID</param>
        /// <returns>The entity</returns>
        T GetId(int id);
        /// <summary>
        /// Create a new Entity
        /// </summary>
        /// <param name="entity">The entity to be persisted</param>
        /// <returns>A copy of the persisted entity</returns>
        T Create(T entity);
        /// <summary>
        /// Update the entity to the desired parameters
        /// </summary>
        /// <param name="entity">The entity to be updated</param>
        /// <returns></returns>
        T Update(T entity);
        /// <summary>
        /// Permanently removes the entity from persistence
        /// </summary>
        /// <param name="entity">The entity to be removed</param>
        /// <returns>true iff the operation was successfull</returns>
        bool Delete(T entity);
    }
}
