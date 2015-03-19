using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Resgrid.Model
{
	public interface IRepository<T> where T : class
	{
		/// <summary>
		/// Get all objects from the database of an IEntity type
		/// </summary>
		/// <returns>IQueryable of selected IEntity type</returns>
		IQueryable<T> GetAll();

		/// <summary>
		/// Deletes/Remotes an object from the database
		/// </summary>
		/// <param name="entity">IEntity object to delete</param>
		void Delete(T entity);

		/// <summary>
		/// Async implementation of Delete
		/// </summary>
		/// <param name="entity">IEntity to remove</param>
		/// <param name="cancellationToken">Cancellation token (Optional)</param>
		void DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Saves an new IEntity object or updates an existing IEntity object
		/// </summary>
		/// <param name="entity">IEntity object to save or update</param>
		void SaveOrUpdate(T entity);

		/// <summary>
		/// Async implemenation of SaveOrUpdate
		/// </summary>
		/// <param name="entity">IEntity object to save or update</param>
		/// <param name="cancellationToken">Cancellation token (Optional)</param>
		void SaveOrUpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Deletes all IEntity objects from the database
		/// </summary>
		/// <param name="entites">IEntity objects to remove</param>
		void DeleteAll(IEnumerable<T> entites);

		/// <summary>
		/// Async implemenation of DeleteAll
		/// </summary>
		/// <param name="entitesToDelete">IEntity objects to delete</param>
		/// <param name="cancellationToken">Cancellation token (Optional)</param>
		void DeleteAllAsync(IEnumerable<T> entitesToDelete, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Save or Update all objects (can be mixed updates and saves)
		/// </summary>
		/// <param name="entitiesToAdd">IEntity objects to save or update</param>
		void SaveOrUpdateAll(IEnumerable<T> entitiesToAdd);

		/// <summary>
		/// Async implemenation of SaveOrUpdateAll
		/// </summary>
		/// <param name="entitiesToAdd">IEntity objects to save or update</param>
		/// <param name="cancellationToken">Cancellation token (Optional)</param>
		void SaveOrUpdateAllAsync(IEnumerable<T> entitiesToAdd, CancellationToken cancellationToken = default(CancellationToken));
	}
}