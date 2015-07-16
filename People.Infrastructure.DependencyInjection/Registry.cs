using System.Configuration;
using People.Core.Interfaces;
using People.Core.Services;
using People.Infrastucture.Data;
using People.Infrastucture.Data.Interfaces;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace People.Infrastructure.DependencyInjection
{
    public class Registry : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterWebApiRequest<IDbFactory>(() => new DbFactory(ConfigurationManager.ConnectionStrings["People"].ConnectionString));
            container.Register<IPeopleRepository, PeopleRepository>();
            container.Register<IPeopleService, PeopleService>();
            container.Verify();
        }
    }
}
