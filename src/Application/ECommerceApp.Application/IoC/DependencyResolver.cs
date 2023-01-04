using Autofac;
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
            base.Load(builder);
        }
    }
}
