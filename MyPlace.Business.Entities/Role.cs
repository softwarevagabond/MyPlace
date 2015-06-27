using Core.Common.Contracts;
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
    public class Role : EntityBase, IIdentifiableEntity
    {
         [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string RoleName { get; set; }

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
