using Resgrid.Model;
using Resgrid.Repository.Contexts;

namespace Resgrid.Repository
{
	public class GenericRepository<T> : RepositoryBase<T>, IGenericRepository<T> where T : class, IEntity
	{
		public GenericRepository(DataContext context)
			: base(context) { }
	}
}
