using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPlace.Business.Bootstrapper;
using Core.Common.Core;
using MyPlace.Data.Contracts;
using MyPlace.Business.Entities;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Moq;
using Core.Common.Contracts;

namespace MyPlace.Data.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();

            IEnumerable<Resident> residents = repositoryTest.GetResidents();

            Assert.IsTrue(residents != null);
        }

        [TestMethod]
        public void test_repository_mocking()
        {
            List<Resident> residents = new List<Resident>()
            {
                new Resident()
                { Id=Guid.NewGuid(),FirstName="Arvind",LastName="Ghadge"},
                new Resident()
                { Id=Guid.NewGuid(),FirstName="SAchin",LastName="Gaikwad"}
            };

            Mock<IResidentRepository> residentRepository = new Mock<IResidentRepository>();
            residentRepository.Setup(obj => obj.Get()).Returns(residents);

            RepositoryTestClass repositoryTest = new RepositoryTestClass(residentRepository.Object);

            IEnumerable<Resident> ret = repositoryTest.GetResidents();

            Assert.IsTrue(ret == residents);

        }

        [TestMethod]
        public void test_repository_factory_usage()
        {
            RepositoryFactoryTestClass repositoryFactoryTest = new RepositoryFactoryTestClass();

            IEnumerable<Resident> residents = repositoryFactoryTest.GetResidents();

            Assert.IsTrue(residents != null);
        }

        [TestMethod]
        public void test_factory_mocking_1()
        {
            List<Resident> residents = new List<Resident>()
            {
                new Resident()
                { Id=Guid.NewGuid(),FirstName="Arvind",LastName="Ghadge"},
                new Resident()
                { Id=Guid.NewGuid(),FirstName="SAchin",LastName="Gaikwad"}
            };

            Mock<IResidentRepository> mockResidentRepository = new Mock<IResidentRepository>();
            mockResidentRepository.Setup(obj => obj.Get()).Returns(residents);

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IResidentRepository>()).Returns(mockResidentRepository.Object);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<Resident> ret = factoryTest.GetResidents();

            Assert.IsTrue(ret == residents);
        }

        

    }

    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryTestClass(IResidentRepository residentRepository)
        {
            _ResidentRepository = residentRepository;
        }

        [Import]
        IResidentRepository _ResidentRepository;

        public IEnumerable<Resident> GetResidents()
        {
            IEnumerable<Resident> residents = _ResidentRepository.Get();

            return residents;
        }

        //public UserInfo GetUserDetails()
        //{
        //    UserInfo userDetails = _ResidentRepository.GetUserDetails("U10000");
        //    return userDetails;
        //}
    }

    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        public IEnumerable<Resident> GetResidents()
        {
            IResidentRepository residentRepository =
                _DataRepositoryFactory.GetDataRepository<IResidentRepository>();

            return residentRepository.Get();
        }
    }
}
