using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using AutoMapper;
using TravelDAL;
using System.Data.Entity;
using TravelDAL.Repository;
using TravelDAL.Repository.Interface;
using TravelBLL.Implementation;
using TravelBLL.Interfaces;

namespace TravelAgenncyUI.Utils
{
    public static class AutofacConfiguration
    {
        public static void Configurate()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ApplicationContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<TourService>().As<ITourService>();

            var configurationManager = new MapperConfiguration(cfg => cfg.AddProfile(new AutomapperConfiguration()));
            builder.RegisterInstance(configurationManager.CreateMapper());

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}