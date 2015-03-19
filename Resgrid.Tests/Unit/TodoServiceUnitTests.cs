using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Resgrid.Model;
using Resgrid.Services;

namespace Resgrid.Tests.Unit
{
	/* Unit Testing Example
	 * Here we will mock out the Generic Repository so that we can 
	 * just test service code. 
	 *
	 */
 
	namespace TodoServiceUnitTests
	{
		public class with_the_todo_service : TestBase
		{
			protected Mock<IGenericRepository<TodoList>> _todoListRepositoryMock;
			protected Mock<IGenericRepository<TodoListItem>> _todoListItemRepositoryMock;
			protected ITodoService _todoService;

			protected with_the_todo_service()
			{
				_todoListRepositoryMock = new Mock<IGenericRepository<TodoList>>();
				_todoListItemRepositoryMock = new Mock<IGenericRepository<TodoListItem>>();

				_todoService = new TodoService(_todoListRepositoryMock.Object, _todoListItemRepositoryMock.Object);
			}
		}

		[TestFixture]
		public class when_saving_todos : with_the_todo_service
		{
			[Test]
			public void should_call_the_repo_on_save()
			{
				var todoList = new TodoList
				{
					Name = "Unit Test"
				};

				_todoService.Save(todoList);
				_todoListRepositoryMock.Verify(x => x.SaveOrUpdate(todoList));
			}
		}
	}
}
