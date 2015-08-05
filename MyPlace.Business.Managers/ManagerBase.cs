using Core.Common.Contracts;
using Core.Common.Core;
using Core.Common.Exceptions;
using MyPlace.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace MyPlace.Business.Managers
{
    public class ManagerBase
    {
        public ManagerBase()
        {
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                try
                {
                    _LoginName = context.IncomingMessageHeaders.GetHeader<string>("String", "System");
                }
                catch(Exception ex)
                {
                    _LoginName = string.Empty;
                }
            }

            if (ObjectBase.Container != null)
                ObjectBase.Container.SatisfyImportsOnce(this);

            if (!String.IsNullOrEmpty(_LoginName))
            {
                _AuthorizationAccount = LoadAuthorizationValidAccount(_LoginName);
            }
        }
        protected string _LoginName;
        protected Resident _AuthorizationAccount = null;


        protected virtual Resident LoadAuthorizationValidAccount(string loginName)
        {
            return null;
        }

        protected void ValidateAuthorization(IResidentOwnedEntity entity)
        {
            //ToDO:Skip this valiadtion for Admin users and other special users as done in Car Rental
            if (_AuthorizationAccount != null)
            {

                if (_LoginName != string.Empty && entity.OwnerResidentId != _AuthorizationAccount.Id)
                {
                    AuthorizationValidationException ex = new AuthorizationValidationException("Attempt to access a secure record with improper user authorization validation. ");
                    throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
                }
            }
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codeToExecute)
        {
            try
            {
                codeToExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
