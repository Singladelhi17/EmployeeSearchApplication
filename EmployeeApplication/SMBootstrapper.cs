using EmployeeApplication.Repository;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Web;

namespace EmployeeApplication
{
    public class SMBootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ObjectRegistry>();
                x.Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                });
            });
        }
    }
    public class ObjectRegistry : Registry
    {
        // NOTE: Any types from the WebApp that follow the default conventions are wired up by default
        public ObjectRegistry()
        {
            For<IEmployeeRepository>().HttpContextScoped().Use<EmployeeRepository>();

        }
    }
}