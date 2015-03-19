using Ninject.Modules;
using Resgrid.Model;
using Resgrid.Repository.Contexts;

namespace Resgrid.Repository
{
	public class RepositoryModule : NinjectModule
	{
		public override void Load()
		{
			Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
			Bind<DataContext>().ToSelf();
		}
	}
}