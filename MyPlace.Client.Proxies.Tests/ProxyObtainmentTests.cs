using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Core;
using MyPlace.Client.Bootstrapper;
using MyPlace.Client.Contracts;
using MyPlace.Client.Proxies.ServiceProxies;
using Core.Common.Contracts;

namespace MyPlace.Client.Proxies.Tests
{
    [TestClass]
    public class ProxyObtainmentTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void obtain_proxy_from_container_using_service_contract()
        {
            ISecurityService proxy = ObjectBase.Container.GetExportedValue<ISecurityService>();
            Assert.IsTrue(proxy is SecurityClient);

            var res =proxy.GetResident("U10000");
        }

        [TestMethod]
        public void obtain_proxy_from_service_factory()
        {
            IServiceFactory factory = new ServiceFactory();

            ISecurityService proxy = factory.CreateClient<ISecurityService>();
            Assert.IsTrue(proxy is SecurityClient);

            var res = proxy.GetResident("U10000");
        }

        [TestMethod]
        public void obtain_service_factory_and_proxy_from_container()
        {
            IServiceFactory factory =
                ObjectBase.Container.GetExportedValue<IServiceFactory>();
            ISecurityService proxy = factory.CreateClient<ISecurityService>();
            Assert.IsTrue(proxy is SecurityClient);

            var res = proxy.GetResident("U10000");
        }
    }
}
