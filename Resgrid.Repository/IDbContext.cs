using System.Data.Entity;

namespace Resgrid.Repository
{
	/// <summary>
	/// Interface for the DataContext
	/// </summary>
	public interface IDbContext
	{
		/// <summary>
		/// Set accessor for the object in the database
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <returns></returns>
		IDbSet<TEntity> Set<TEntity>() where TEntity : class;

		/// <summary>
		/// Save Changes back to the database
		/// </summary>
		/// <returns></returns>
		int SaveChanges();

		/// <summary>
		/// Determmines if this Data Context is tied to a SQLCE databaSE
		/// </summary>
		/// <returns></returns>
		bool IsSqlCe();
	}
}