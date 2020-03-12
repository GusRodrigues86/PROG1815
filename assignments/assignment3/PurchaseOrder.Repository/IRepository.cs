using System;
using System.Collections.Generic;

namespace PurchaseOrder.Repository
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Save the object into the persistence unit.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>A copy to the unit that has been persisted</returns>
        T Create(T entity);
        /// <summary>
        /// Fetch all records from the persistence unit.
        /// </summary>
        /// <returns>Retrieve a list with all records</returns>
        List<T> GetAll();
        /// <summary>
        /// Fetch entity based on the ID.
        /// </summary>
        /// <param name="id">The Id to be searched.</param>
        /// <returns>The entity with the given Id</returns>
        /// <exception cref="KeyNotFoundException">If no such element exists</exception>
        T GetById(int id);
        /// <summary>
        /// Update the values in the persistence unit with the new data.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The updated entity</returns>
        T Update(T entity);
        /// <summary>
        /// Removes the element from the persistence unit.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True iff the persistence unit was changed because of the operation.</returns>
        bool Delete(T entity);
        /// <summary>
        /// Search for the desired entity.
        /// </summary>
        /// <param name="entity">to be found.</param>
        /// <returns>True iff the persistence unit contains the entity.</returns>
        bool HasItem(T entity);
    }
}
