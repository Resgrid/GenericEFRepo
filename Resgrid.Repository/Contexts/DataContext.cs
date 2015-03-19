using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Resgrid.Model;
using Resgrid.Repository.Configurations;

namespace Resgrid.Repository.Contexts
{
	[DbConfigurationType(typeof(StandardDbConfiguration))]
	public class DataContext : DbContext, IDbContext
	{
		public DbSet<TodoList> TodoLists { get; set; }
		public DbSet<TodoListItem> TodoListItems { get; set; }

		public DataContext()
			: base("DataContext")
		{

		}

		public DataContext(string connectionStringName)
			: base(connectionStringName)
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			//modelBuilder.Configurations.Add(new Some_Mapping());

			base.OnModelCreating(modelBuilder);
		}

		public string CreateDatabaseScript()
		{
			return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
		}

		public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
		{
			return base.Set<TEntity>();
		}

		public bool IsSqlCe()
		{
			return Database.Connection.ConnectionString.Contains(".sdf");
		}
	}
}