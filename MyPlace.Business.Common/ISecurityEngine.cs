using Core.Common.Contracts;
using MyPlace.Business.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Business.Common
{
    public interface ISecurityEngine : IBusinessEngine
    {
        UserDetails GetUserDetails(string userId);
    }
}
