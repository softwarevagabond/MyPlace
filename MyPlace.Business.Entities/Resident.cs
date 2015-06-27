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
    public class Resident : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Salutation { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int UserType { get; set; }

        [DataMember]
        public string ContactNumber { get; set; }

        [DataMember]
        public string AdditionalContactNumber { get; set; }

        [DataMember]
        public bool Disabled { get; set; }

        [DataMember]
        public bool? IsSuperUser { get; set; }

        [DataMember]
        public byte[] Signature { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime LastModifiedDate { get; set; }

        [DataMember]
        public string LastModifiedBy { get; set; }

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
