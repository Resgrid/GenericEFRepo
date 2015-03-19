using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Resgrid.Model
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();
		void Delete(T entity);
		void DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
		void SaveOrUpdate(T entity);
		void SaveOrUpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
		void DeleteAll(IEnumerable<T> entites);
		void DeleteAllAsync(IEnumerable<T> entitesToDelete, CancellationToken cancellationToken = default(CancellationToken));
		void SaveOrUpdateAll(IEnumerable<T> entitiesToAdd);
		void SaveOrUpdateAllAsync(IEnumerable<T> entitiesToAdd, CancellationToken cancellationToken = default(CancellationToken));
	}
}