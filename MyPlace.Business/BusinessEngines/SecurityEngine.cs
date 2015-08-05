using Core.Common.Contracts;
using MyPlace.Business.Common;
using MyPlace.Business.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Business.BusinessEngines
{
    [Export(typeof(ISecurityEngine))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SecurityEngine : ISecurityEngine
    {
        [ImportingConstructor]
        public SecurityEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }
        IDataRepositoryFactory _DataRepositoryFactory;
        //ToDO: Similarly add details from ResidentSocietyRoleMapping and ResidentSocietyMapping to the UserDetails

        public UserDetails GetUserDetails(string userId)
        {
            //IResidentRepository residentRepository =
            //           _DataRepositoryFactory.GetDataRepository<IResidentRepository>();
            //UserInfo userInfo = residentRepository.GetUserDetails(userId);

            //var residentInfo = residentRepository.GetByUserId(userId);

            //if (userInfo != null)
            //{
            //    var userDetails = new UserDetails()
            //    {
            //        Id = userInfo.Resident.Id,
            //        UserId = userInfo.Resident.UserId,
            //        FirstName = userInfo.Resident.FirstName,
            //        LastName = userInfo.Resident.LastName,
            //        UserType = (UserType)userInfo.Resident.UserType,
            //        IsSuperUser = userInfo.Resident.IsSuperUser.GetValueOrDefault(false),
            //        LastModifiedDate = userInfo.Resident.LastModifiedDate ?? userInfo.Resident.CreateDate
            //    };

            //    var privilegeConvertor = TypeDescriptor.GetConverter(typeof(FormPrivilege));

            //    foreach (var e in userInfo.ResidentFormDetails)
            //    {
            //        var societyModel = e.Society;
            //        var societyFormModel = societyModel.SocietyForms.FirstOrDefault(x => x.FormType == e.FormType);

            //        var formTypes = GetFormTypesFromFormTypeName(e.FormType.TypeName);
            //        var userFormRoleModel = e.Role;
            //        var formRolePrivilegeModel = userFormRoleModel.FormTypeRolePrivileges.FirstOrDefault(x => x.FormType == e.FormType);

            //        if (formRolePrivilegeModel == null) continue;
            //        var society = userDetails.SocietyPermissions.FirstOrDefault(x => x.Id == e.Society.Id);

            //        if (society == null)
            //        {
            //            society = new SocietyPermission()
            //            {
            //                Id = societyModel.Id,
            //                Description = societyModel.Description,
            //                Name = societyModel.Name,

            //            };
            //            userDetails.SocietyPermissions.Add(society);
            //        }

            //        var formPermission = new FormPermission()
            //        {
            //            FormType = GetFormTypesFromFormTypeName(e.FormType.TypeName),
            //            Role = userFormRoleModel.RoleName,
            //            Privilege = (FormPrivilege)privilegeConvertor.ConvertFromString(formRolePrivilegeModel.Privileges),
            //            IsFormAdmin = e.IsFormAdmin.Value
            //        };

            //        society.FormPermissions[formTypes] = formPermission;
            //    }
            //    return userDetails;
            //}
            //else
            //    return null;

            throw new NotImplementedException();
        }
    }
}
