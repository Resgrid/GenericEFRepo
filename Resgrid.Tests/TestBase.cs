using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using Ninject;
using NUnit.Framework;
using Resgrid.Repository.Configurations;
using System.IO;

namespace Resgrid.Tests
{
	public class TestBase
	{
		static TestBase()
		{
			if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\DataContext.sdf"))
				File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\DataContext.sdf");

			File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\DataContext.sdf");

			Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

			var migrator = new DbMigrator(new TestDbConfiguration());
			migrator.Update();

			Bootstrapper.Initialize();
		}

		protected T Resolve<T>()
		{
			return Bootstrapper.GetKernel().Get<T>();
		}

		[TestFixtureSetUp]
		public void SetupContext_ALL()
		{
			Before_all_tests();
		}

		[TestFixtureTearDown]
		public void TearDownContext_ALL()
		{
			After_all_tests();
		}

		protected virtual void Before_all_tests()
		{
		}

		protected virtual void After_all_tests()
		{
		}
	}
}
