using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Resgrid.Model;

namespace Resgrid.Services
{
	public class TodoService : ITodoService
	{
		private readonly IGenericRepository<TodoList> _todoListRepository;
		private readonly IGenericRepository<TodoListItem> _todoListItemRepository;

		public TodoService(IGenericRepository<TodoList> todoListRepository, IGenericRepository<TodoListItem> todoListItemRepository)
		{
			_todoListRepository = todoListRepository;
			_todoListItemRepository = todoListItemRepository;
		}

		public List<TodoList> GetAll()
		{
			return _todoListRepository.GetAll().ToList();
		}

		public TodoList GetListById(int todoListId)
		{
			return _todoListRepository.GetAll().FirstOrDefault(x => x.TodoListId == todoListId);
		}

		public TodoList Save(TodoList list)
		{
			_todoListRepository.SaveOrUpdate(list);

			return list;
		}
	}
}