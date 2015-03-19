using FluentAssertions;
using NUnit.Framework;
using Resgrid.Model;

namespace Resgrid.Tests.Intergration
{
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
