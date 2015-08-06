using MyPlace.Web.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace MyPlace.Web.Adapters
{
    [Export(typeof(ISecurityAdapter))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SecurityAdapter : ISecurityAdapter
    {
        public void Initialize()
        {
            if (!WebSecurity.Initialized)
                //   WebSecurity.InitializeDatabaseConnection("main", "Account", "AccountId", "LoginEmail", autoCreateTables: true);
                WebSecurity.InitializeDatabaseConnection("main", "Security.Resident", "Id", "UserId", autoCreateTables: true);
        }

        public void Register(string loginEmail, string password, object propertyValues)
        {
            WebSecurity.CreateUserAndAccount(loginEmail, password, propertyValues);
        }

        public bool Login(string login, string password, bool rememberMe)
        {
            return WebSecurity.Login(login, password, persistCookie: rememberMe);
        }

        public bool ChangePassword(string loginEmail, string oldPassword, string newPassword)
        {
            return WebSecurity.ChangePassword(loginEmail, oldPassword, newPassword);
        }

        public bool UserExists(string loginEmail)
        {
            return WebSecurity.UserExists(loginEmail);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }
    }
}