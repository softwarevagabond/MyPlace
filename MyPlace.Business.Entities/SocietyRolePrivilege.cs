﻿using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Business.Entities
{
    [DataContract]
    public class SocietyRolePrivilege : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid SocietyId { get; set; }

        [DataMember]
        public Guid RoleId { get; set; }

       [DataMember]
        public string Privileges { get; set; }

       //IIdentifiableEntity Members
       public Guid EntityId
       {
           get
           {
               return Id;
           }
           set
           {
               Id = value;
           }
       }
    }
}
