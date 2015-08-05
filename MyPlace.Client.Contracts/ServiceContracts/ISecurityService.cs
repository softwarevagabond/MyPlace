using Core.Common.Contracts;
using Core.Common.Exceptions;
using MyPlace.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Client.Contracts
{
    [ServiceContract]
    public interface ISecurityService : IServiceContract
    {
        //TOOD: Add other security related methods
        //[OperationContract]
        //[FaultContract(typeof(NotFoundException))]
        //Resident GetResident(Guid residentId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Resident GetResident(string userId);

        [OperationContract]
        Resident[] GetAllResidents();



        //[OperationContract]
        //UserInfo GetUserDetails(string userId);

        //[OperationContract]
        //UserDetails GetUserDetails(string userId);

        //[OperationContract]
        //Resident GetResidentByUserId(string userId);


        //[OperationContract]
        //[FaultContract(typeof(NotFoundException))]
        //[FaultContract(typeof(AuthorizationValidationException))]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //Resident UpdateResident(Resident resident);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //void DeleteResident(Guid residentId);

    }
}
