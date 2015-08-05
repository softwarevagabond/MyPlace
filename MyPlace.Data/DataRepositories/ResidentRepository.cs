using MyPlace.Business.Entities;
using MyPlace.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Similarly Add other Repositories
namespace MyPlace.Data.DataRepositories
{
    [Export(typeof(IResidentRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    public class ResidentRepository : DataRepositoryBase<Resident>, IResidentRepository
    {
        protected override Resident AddEntity(SocietyMasterContext entityContext, Resident entity)
        {
            return entityContext.ResidentSet.Add(entity);
        }

        protected override IEnumerable<Resident> GetEntities(SocietyMasterContext entityContext)
        {
            return entityContext.ResidentSet;
        }

        protected override Resident GetEntity(SocietyMasterContext entityContext, Guid id)
        {

            return entityContext.ResidentSet.Where(r => r.Id == id).FirstOrDefault();
        }

        protected override Resident UpdateEntity(SocietyMasterContext entityContext, Resident entity)
        {
            return entityContext.ResidentSet.Where(r => r.Id == entity.Id).FirstOrDefault();
        }

        public Resident GetByEmail(string email)
        {
            using (SocietyMasterContext entityContext = new SocietyMasterContext())
            {
                return entityContext.ResidentSet.Where(r => r.Email == email).FirstOrDefault();
            }
        }

        public Resident GetByUserId(string userId)
        {
            using (SocietyMasterContext entityContext = new SocietyMasterContext())
            {
                var resident = entityContext.ResidentSet.Where(r => r.UserId == userId).FirstOrDefault();
                return resident;
            }
        }

        //ToDO:May be refactor the UserInfo to have only relevant values.
        //public UserInfo GetUserDetails(string userId)
        //{
        //    using (SocietyMasterContext entityContext = new SocietyMasterContext())
        //    {
        //        entityContext.Configuration.LazyLoadingEnabled = true;
        //        var resident = entityContext.ResidentSet.Where(r => r.UserId == userId).FirstOrDefault();

        //        var userInfo = new UserInfo()
        //        {
        //            Resident = resident,
        //            ResidentFormDetails = resident.ResidentFormRoles != null && resident.ResidentFormRoles.Count() > 0 ?
        //                                resident.ResidentFormRoles.ToList() : new List<ResidentFormTypeMapping>(),
        //            ResidentSocietyRole = resident.ResidentSocietyRoles.FirstOrDefault(),
        //            ResidentSocietyDetails = resident.ResidentSocietyDetails.FirstOrDefault()

        //        };
        //        //ToDO: Refactor Later...
        //        //Had to do this since the context is available only in this method and the navigational properties are not available in the calling program.
        //        foreach (var residentFormDetail in userInfo.ResidentFormDetails)
        //        {
        //            residentFormDetail.Society.SocietyForms = resident.ResidentFormRoles.FirstOrDefault(rfp => rfp.SocietyId
        //                   == residentFormDetail.Society.Id).Society.SocietyForms;

        //            residentFormDetail.FormType = residentFormDetail.FormType;
        //            residentFormDetail.Role = residentFormDetail.Role;
        //            residentFormDetail.Role.FormTypeRolePrivileges = residentFormDetail.Role.FormTypeRolePrivileges;
        //        }
        //        return userInfo;
        //    }
        //}
    }
}
