using Core.Common.Contracts;
using Core.Common.Core;
using Core.Common.Exceptions;
using MyPlace.Business.Contracts;
using MyPlace.Business.Entities;
using MyPlace.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Business.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,IncludeExceptionDetailInFaults=true
        //,ReleaseServiceInstanceOnTransactionComplete = false
        )]

    public class SecurityManager :ManagerBase, ISecurityService
    {
         public SecurityManager()
        {
           
        }

        public SecurityManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public SecurityManager(IBusinessEngineFactory businessEngineFactory)
        {
            _BusinessEngineFactory = businessEngineFactory;
        }
        public SecurityManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;


        //public Resident GetResident(Guid residentId)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //       {
        //           IResidentRepository residentRepository =
        //                      _DataRepositoryFactory.GetDataRepository<IResidentRepository>();
        //           Resident resident = residentRepository.Get(residentId);
        //           if (resident == null)
        //           {
        //               NotFoundException ex = new NotFoundException(string.Format("Resident with Id of {0} is not in the database", residentId));
        //               throw new FaultException<NotFoundException>(ex, ex.Message);
        //           }
        //           return resident;
        //       });
        //}

        public Resident GetResident(string userId)
        {
             return ExecuteFaultHandledOperation(() =>
               {
                    IResidentRepository residentRepository =
                             _DataRepositoryFactory.GetDataRepository<IResidentRepository>();
                    Resident resident = residentRepository.GetByUserId(userId);

                    if (resident == null)
                    {
                        NotFoundException ex = new NotFoundException(string.Format("Resident with Id of {0} is not in the database", userId));
                        throw new FaultException<NotFoundException>(ex, ex.Message);
                    }
                    return resident;
               });
        }

        public Resident[] GetAllResidents()
        {
            return ExecuteFaultHandledOperation(() =>
               {
                    IResidentRepository residentRepository =
                               _DataRepositoryFactory.GetDataRepository<IResidentRepository>();
                    IEnumerable<Resident> residents = residentRepository.Get();
                    return residents.ToArray();
               });
        } 
    }
}
