using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPlace.Business.Entities;
using Moq;
using Core.Common.Contracts;
using MyPlace.Data.Contracts;

namespace MyPlace.Business.Managers.Tests
{
    [TestClass]
    public class SecurityManagerTests
    {
        [TestMethod]
        public void GetResident()
        {
            Resident res = new Resident() { FirstName = "Roni", LastName = "Thomas" };
            string userId = "U10000";
            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IResidentRepository>().GetByUserId(userId)).Returns(res);
            SecurityManager secManager = new SecurityManager(mockDataRepository.Object);

            var res1 = secManager.GetResident(userId);

            Assert.IsTrue(res1 == res);
        }
    }
}
