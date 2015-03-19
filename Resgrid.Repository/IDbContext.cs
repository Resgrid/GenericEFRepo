using System.Data.Entity;

namespace Resgrid.Repository
{
	public interface IDbContext
	{
		IDbSet<TEntity> Set<TEntity>() where TEntity : class;
		int SaveChanges();
		bool IsSqlCe();
	}
}