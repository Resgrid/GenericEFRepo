using Ninject.Modules;
using Resgrid.Model;

namespace Resgrid.Services
{
	public class ServicesModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ITodoService>().To<TodoService>();
		}
	}
}