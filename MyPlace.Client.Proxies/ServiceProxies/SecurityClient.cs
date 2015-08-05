using Core.Common.ServiceModel;
using MyPlace.Client.Contracts;
using MyPlace.Client.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Client.Proxies.ServiceProxies
{
    [Export(typeof(ISecurityService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SecurityClient : UserClientBase<ISecurityService>, ISecurityService
    {
        public Resident GetResident(string userId)
        {
            return Channel.GetResident(userId);
        }

        public Resident[] GetAllResidents()
        {
            return Channel.GetAllResidents();
        }
    }
}
