using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPlace.Client.Proxies.ServiceProxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Client.Proxies.Tests
{
     [TestClass]
   public class ServiceAccessTests
    {

         [TestMethod]
         public void test_security_client_test()
         {
             SecurityClient proxy = new SecurityClient();
             proxy.Open();
             var r = proxy.GetResident("U10000");


         } 
    }
}
