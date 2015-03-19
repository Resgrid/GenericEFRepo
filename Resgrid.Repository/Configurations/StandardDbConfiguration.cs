using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Resgrid.Repository.Contexts;
using Resgrid.Repository.Migrations;

namespace Resgrid.Repository.Configurations
{
	public class StandardDbConfiguration : DbConfiguration
	{
		public StandardDbConfiguration()
		{
			SetDefaultConnectionFactory(new SqlConnectionFactory());
			SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
		}
	} 
}