using FluentAssertions;
using NUnit.Framework;
using Resgrid.Model;

namespace Resgrid.Tests.Intergration
{
	/* Intergration tests will write back to our SQLCE data store
	 * you can get these for free so it makes sense to use this 
	 * as your normal testing path.
	 * 
	 * It may not be 'unit testing' but it's super lightweight and
	 * allows you to test your schema. 
	 */ 


	namespace TodoServiceIntergrationTests
	{
		public class with_the_todo_service : TestBase
		{
			protected ITodoService _todoService;

			protected with_the_todo_service()
			{
				_todoService = Resolve<ITodoService>();
			}
		}

		[TestFixture]
		public class when_saving_todos : with_the_todo_service
		{
			[Test]
			public void should_be_able_to_save()
			{
				var todoList = new TodoList
				{
					Name = "Intergration Test"
				};

				_todoService.Save(todoList);
			}
		}

		[TestFixture]
		public class when_reading_todos : with_the_todo_service
		{
			[Test]
			public void should_be_able_to_get_saved_todo()
			{
				var todo = _todoService.GetListById(1);
				todo.Should().NotBeNull();
			}
		}
	}
}
