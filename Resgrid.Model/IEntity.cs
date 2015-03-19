namespace Resgrid.Model
{
	/// <summary>
	/// Interface that allows the Generic EF Report to get PK/ID values
	/// </summary>
	public interface IEntity
	{
		object Id { get; set; }
	}
}
