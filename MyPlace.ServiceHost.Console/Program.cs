using Core.Common.Core;
using MyPlace.Business.Bootstrapper;
using MyPlace.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM = System.ServiceModel;

namespace MyPlace.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectBase.Container = MEFLoader.Init();
            Console.WriteLine("Starting up services ...");
            Console.WriteLine("");

            //ToDo: Add other services here as well.
            SM.ServiceHost hostSecurityManager = new SM.ServiceHost(typeof(SecurityManager));

            StartService(hostSecurityManager, "SecurityManager");

            Console.WriteLine("");
            Console.WriteLine("Press [Enter]  to exit");
            Console.ReadLine();

            StopService(hostSecurityManager, "SecurityManager");
        }

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            host.Open();

            Console.WriteLine("Service {0} started", serviceDescription);

            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine(string.Format("Listening on endpoint:"));
                Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri));
                Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                Console.WriteLine(string.Format("Contract {0}", endpoint.Contract.ConfigurationName));
            }

            Console.WriteLine();
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            Console.WriteLine("Service {0} stopped", serviceDescription);
        }
    }
}
