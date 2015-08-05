using Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyPlace.Business.Contracts.DataContracts
{
    [DataContract]
    public class UserDetails : DataContractBase
    {
        public UserDetails()
        {
          //  SocietyPermissions = new List<SocietyPermission>();
        }

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

        //[DataMember]
        //public UserType UserType { get; set; }

        //[DataMember]
        //public string ContactNumber { get; set; }

        //[DataMember]
        //public string AdditionalContactNumber { get; set; }

        //[DataMember]
        //public bool Disabled { get; set; }

        //[DataMember]
        //public bool IsSuperUser { get; set; }

        //[DataMember]
        //public DateTime LastModifiedDate { get; set; }

        //[DataMember]
        //public List<SocietyPermission> SocietyPermissions { get; set; }

        private static readonly DataContractSerializer Serializer = new DataContractSerializer(typeof(UserDetails));

        public static string Serialize(UserDetails permissionClaim)
        {
            var ms = new MemoryStream();
            Serializer.WriteObject(ms, permissionClaim);
            ms.Flush();
            ms.Position = 0;
            var sr = new StreamReader(ms);
            string content = sr.ReadToEnd();
            return content;
        }
        public static UserDetails DeSerialize(string objectAsString)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(objectAsString);
            sw.Flush();
            ms.Position = 0;
            var reader = XmlReader.Create(ms);
            return Serializer.ReadObject(reader, true) as UserDetails;
        }
    }

}
