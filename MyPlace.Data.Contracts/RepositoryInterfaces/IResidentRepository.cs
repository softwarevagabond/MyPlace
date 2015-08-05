using Core.Common.Contracts;
using MyPlace.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Data.Contracts
{
    public interface IResidentRepository : IDataRepository<Resident>
    {
        //TODo: Add other Resident specific contracts.
        Resident GetByEmail(string email);
        Resident GetByUserId(string userId);
       // UserInfo GetUserDetails(string userId);
    }
}
