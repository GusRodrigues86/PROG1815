/* Assignment 3
 * IRepository<T>.cs
 *  Representation of persistence unit behaviour
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.14: Created
 */
using System.Collections.Generic;

namespace PurchaseOrder.Repository
{
    /// <summary>
    /// The expected behaviour of all Repositories
    /// </summary>
    /// <typeparam name="T">The type that will be saved in the repository</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Save the object into the persistence unit.
        /// </summary>
        /// <param name="entity">Entity to be created.</param>
        /// <returns>A copy to the unit that has been persisted.</returns>
        T Create(T entity);
        /// <summary>
        /// Fetch all records from the persistence unit.
        /// </summary>
        /// <returns>Retrieve a list with all records.</returns>
        List<T> GetAll();
        /// <summary>
        /// Fetch entity based on the ID.
        /// </summary>
        /// <param name="id">The Id to be searched.</param>
        /// <returns>The entity with the given Id.</returns>
        /// <exception cref="KeyNotFoundException">If no such element exists</exception>
        T GetById(int id);
        /// <summary>
        /// Update the values in the persistence unit with the new data.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>The updated entity</returns>
        bool Update(T entity);
        /// <summary>
        /// Removes the element from the persistence unit.
        /// </summary>
        /// <param name="key">The ID of the object to be removed.</param>
        /// <returns>True iff the persistence unit was changed because of the operation.</returns>
        bool Delete(int key);
        /// <summary>
        /// Search for the desired entity.
        /// </summary>
        /// <param name="entity">to be found.</param>
        /// <returns>True iff the persistence unit contains the entity.</returns>
        bool HasItem(T entity);
        /// <summary>
        /// Returns the actual ammount of itens in the system.
        /// </summary>
        /// <returns>The total ammount of unique itens in the system.</returns>
        int Size();
    }
}
