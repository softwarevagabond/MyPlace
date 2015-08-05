using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using MyPlace.Business.Contracts;

namespace MyPlace.ServiceHost.Tests
{
    [TestClass]
    public class ServiceAccessTests
    {
        [TestMethod]
        public void test_security_manager_as_service()
        {
            ChannelFactory<ISecurityService> channelFactory =
                new ChannelFactory<ISecurityService>("");

            ISecurityService proxy = channelFactory.CreateChannel();

            (proxy as ICommunicationObject).Open();

          var res=  proxy.GetResident("U10000");

            channelFactory.Close();
        }
    }
}
