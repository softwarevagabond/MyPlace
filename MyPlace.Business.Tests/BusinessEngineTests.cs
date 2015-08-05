using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Core;
using MyPlace.Business.Bootstrapper;
using MyPlace.Business.Common;
using System.ComponentModel.Composition;
using MyPlace.Business.Entities;

namespace MyPlace.Business.Tests
{
    [TestClass]
    public class BusinessEngineTests
    {
        [TestInitialize]
        public void Initialize()
        {
          //  ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    //public class BusinessEngineTestClass
    //{
    //    public BusinessEngineTestClass()
    //    {
    //        ObjectBase.Container.SatisfyImportsOnce(this);
    //    }

    //    public BusinessEngineTestClass(ISecurityEngine securityEngine)
    //    {
    //        _SecurityEngine = securityEngine;
    //    }

    //    [Import]
    //    ISecurityEngine _SecurityEngine;

    //    //public UserDetails GetUserDetails(string userId)
    //    //{
    //    //    var userDetails = _SecurityEngine.GetUserDetails(userId);
    //    //    return userDetails;
    //    //}

    //    public Resident GetResident(string userId)
    //    {
    //     var res =    _SecurityEngine.get
    //    }

    //}

}
