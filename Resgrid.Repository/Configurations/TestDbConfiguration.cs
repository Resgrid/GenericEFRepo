﻿using System;
using System.Data.Entity.Migrations;
using Resgrid.Model;
using Resgrid.Repository.Contexts;

namespace Resgrid.Repository.Configurations
{
	public class TestDbConfiguration : DbMigrationsConfiguration<DataContext>
	{
		public TestDbConfiguration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(DataContext context)
		{
			context.TodoLists.AddOrUpdate(a => a.TodoListId,
													new TodoList
													{
														TodoListId = 1,
														Name = "Test List 1"
													});

			context.TodoLists.AddOrUpdate(a => a.TodoListId,
													new TodoList
													{
														TodoListId = 2,
														Name = "Test List 2"
													});

			context.TodoListItems.AddOrUpdate(a => a.TodoListItemId,
													new TodoListItem
													{
														TodoListItemId = 1,
														TodoListId = 1,
														Task = "Test List 1 Task 1"
													});

			context.TodoListItems.AddOrUpdate(a => a.TodoListItemId,
													new TodoListItem
													{
														TodoListItemId = 2,
														TodoListId = 1,
														Task = "Test List 1 Task 2"
													});

			context.TodoListItems.AddOrUpdate(a => a.TodoListItemId,
													new TodoListItem
													{
														TodoListItemId = 3,
														TodoListId = 2,
														Task = "Test List 2 Task 1"
													});

		}
	}
}
