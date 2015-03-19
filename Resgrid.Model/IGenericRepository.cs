namespace Resgrid.Model
{
	/// <summary>
	/// Interface for the generic repo. Useful for DI/IoC
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IGenericRepository<T> : IRepository<T> where T : class, IEntity
	{
	}
}