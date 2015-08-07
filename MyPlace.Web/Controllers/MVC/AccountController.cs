using MyPlace.Web.Core;
using MyPlace.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPlace.Web.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("account")]
    public class AccountController : ViewControllerBase
    {
        ISecurityAdapter _SecurityAdapter;

        [ImportingConstructor]
        public AccountController(ISecurityAdapter securityAdapter)
        {
            _SecurityAdapter = securityAdapter;
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login(string returnUrl)
        {
            _SecurityAdapter.Initialize();
            return View(new AccountLoginModel() { ReturnUrl = returnUrl });
        }

        [HttpGet]
        [Route("logout")]
        public ActionResult Logout()
        {
            _SecurityAdapter.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        //This route will be defdined in the ROuteConfig
        public ActionResult Register()
        {
            _SecurityAdapter.Initialize();
            return View();
        }
    }

}