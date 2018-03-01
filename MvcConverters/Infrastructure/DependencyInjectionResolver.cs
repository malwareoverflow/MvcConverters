using MvcConverters.AbstractRepository;
using MvcConverters.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcConverters.Method;
namespace MvcConverters.Infrastructure
{
    public class DependencyInjectionResolver : NinjectModule
    {

        public override void Load()
        {
            try
            {
               
                Bind<ISelectList>().To<SelectList>();
                Bind<IConveters>().To<Converters>();
                Bind<IMethods>().To<Methods>();
       
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }
    }
}