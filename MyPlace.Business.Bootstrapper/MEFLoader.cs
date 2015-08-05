using MyPlace.Business.BusinessEngines;
using MyPlace.Data.DataRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Business.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            // Add items to catalog -- any one class from the assembly
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ResidentRepository).Assembly));

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(SecurityEngine).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);
            return container;
        }
    }
}
