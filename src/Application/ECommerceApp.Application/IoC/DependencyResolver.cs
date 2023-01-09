using Autofac;
using AutoMapper;
using ECommerceApp.Application.AutoMapper;
using ECommerceApp.Application.Services.AdminService;
using ECommerceApp.Application.Services.LoginService;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repositories;
using ECommerceApp.Infastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<BaseRepo>().As<IBaseRepo>().InsatancePerLifeTimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                //Mapping dosyamızıda buraya ekliyoruz gidip startup'ta eklemek zorunda kalmayalım zaten burasının görevi oraya sağlamak olacak.
                cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();

            builder.RegisterType<EmployeeRepo>().As<IEmployeeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<AdminService>().As<IAdminService>().InstancePerLifetimeScope();
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerLifetimeScope();


            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
