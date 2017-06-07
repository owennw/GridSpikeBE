using Ninject.Modules;
using ShoppingApp.Repositories;

namespace ShoppingApp.Controllers
{
    public class UnitOfWorkModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}