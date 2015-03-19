using Resgrid.Model;
using Resgrid.Repository.Contexts;

namespace Resgrid.Repository
{
	/// <summary>
	/// Generic Repo Implemenation of the BaseRepository
	/// </summary>
	/// <typeparam name="T">IEntity object to implement</typeparam>
	public class GenericRepository<T> : RepositoryBase<T>, IGenericRepository<T> where T : class, IEntity
	{
		public GenericRepository(DataContext context)
			: base(context) { }
	}
}
