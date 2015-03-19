using System.Collections.Generic;

namespace Resgrid.Model
{
	public interface ITodoService
	{
		List<TodoList> GetAll();
		TodoList GetListById(int todoListId);
		TodoList Save(TodoList list);
	}
}