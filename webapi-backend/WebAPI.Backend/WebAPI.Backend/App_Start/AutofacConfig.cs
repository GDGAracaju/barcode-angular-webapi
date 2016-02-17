using Autofac;
using Autofac.Integration.WebApi;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using WebApi.Core.Application.Servicies;
using WebApi.Infraestructure;
using WebApi.Infraestructure.Repositories;

namespace WebAPI.Backend.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterDependencyInjection(this HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<BibliotecaDbContext>().As<DbContext>().InstancePerRequest();

            builder
                .RegisterGeneric(typeof(RepositoryEf<>))
                .As(typeof(IRepository<>))
                .InstancePerRequest();

            builder.RegisterType<ServicoDePessoas>().As<IServicoDePessoas>().InstancePerRequest();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}