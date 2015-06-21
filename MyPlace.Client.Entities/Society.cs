using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Client.Entities
{
   public  class Society
    {
       Guid _Id;
       string _Code;
       string _Name;
       string _Description;
       string _Address;
       string _Locality;
       string _City;
       string _State;
       string _ZipCode;

       public Guid Id 
       {
           get
           {
               return _Id;
           }
           set
           {
               _Id = value;
           }
       }
       
       public string Code
       {
           get
           {
               return _Code;
           }
           set
           {
               _Code = value;
           }
       }

       public string Name
       {
           get
           {
               return _Name;
           }
           set
           {
               _Name = value;
           }
       }

       public string Description
       {
           get
           {
               return _Description;
           }
           set
           {
               _Description = value;
           }
       }

       public string Address
       {
           get
           {
               return _Address;
           }
           set
           {
               _Address = value;
           }
       }

       public string Locality
       {
           get
           {
               return _Locality;
           }
           set
           {
               _Locality = value;
           }
       }

       public string City
       {
           get
           {
               return _City;
           }
           set
           {
               _City = value;
           }
       }

       public string State
       {
           get
           {
               return _State;
           }
           set
           {
               _State = value;
           }
       }
       public string ZipCode
       {
           get
           {
               return _ZipCode;
           }
           set
           {
               _ZipCode = value;
           }
       }
    }

}
