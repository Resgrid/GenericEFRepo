using Ninject;
using Ninject.Modules;
using Resgrid.Repository;
using Resgrid.Services;

namespace Resgrid.Tests
{
	public static class Bootstrapper
	{
		private static IKernel _kernel;

		public static void Initialize()
		{
			if (_kernel == null)
			{
				var modules = new INinjectModule[]
					              {
						              new ServicesModule(),
						              new RepositoryModule(),
					              };

				_kernel = new StandardKernel(modules);
			}
		}

		public static IKernel GetKernel()
		{
			if (_kernel == null)
				Initialize();

			return _kernel;
		}
	}
}
