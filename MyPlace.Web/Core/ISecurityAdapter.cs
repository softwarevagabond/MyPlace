using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Web.Core
{
    public interface ISecurityAdapter
    {
        void Initialize();
        void Register(string loginEmail, string password, object propertyValues);
        bool Login(string login, string password, bool rememberMe);
        bool ChangePassword(string loginEmail, string oldPassword, string newPassword);
        bool UserExists(string loginEmail);

        void Logout();


    }
}
