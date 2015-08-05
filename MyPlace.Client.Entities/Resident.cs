using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Client.Entities
{
    public class Resident : ObjectBase
    {
        Guid _Id;
        string _UserId;
        string _Salutation;
        string _FirstName;
        string _LastName;
        string _Email;
        int _UserType;
        string _ContactNumber;
        string _AdditionalContactNumber;
        bool _Disabled;
        bool? _IsSuperUser;
        byte[] _Signature;
        DateTime _CreateDate;
        DateTime _LastModifiedDate;
        string _LastModifiedBy;

        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged(() => Id);
                }
            }
        }

        public string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    _UserId = value;
                    OnPropertyChanged(() => UserId);
                }
            }
        }

        public string Salutation
        {
            get
            {
                return _Salutation;
            }
            set
            {
                if (_Salutation != value)
                {
                    _Salutation = value;
                    OnPropertyChanged(() => Salutation);
                }
            }
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }

        public int UserType
        {
            get
            {
                return _UserType;
            }
            set
            {
                if (_UserType != value)
                {
                    _UserType = value;
                    OnPropertyChanged(() => UserType);
                }
            }
        }

        public string ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
            set
            {
                if (_ContactNumber != value)
                {
                    _ContactNumber = value;
                    OnPropertyChanged(() => ContactNumber);
                }
            }
        }

        public string AdditionalContactNumber
        {
            get
            {
                return _AdditionalContactNumber;
            }
            set
            {
                if (_AdditionalContactNumber != value)
                {
                    _AdditionalContactNumber = value;
                    OnPropertyChanged(() => AdditionalContactNumber);
                }
            }
        }

        public bool Disabled
        {
            get
            {
                return _Disabled;
            }
            set
            {
                if (_Disabled != value)
                {
                    _Disabled = value;
                    OnPropertyChanged(() => Disabled);
                }
            }
        }

        public bool? IsSuperUser
        {
            get
            {
                return _IsSuperUser;
            }
            set
            {
                if (_IsSuperUser != value)
                {
                    _IsSuperUser = value;
                    OnPropertyChanged(() => IsSuperUser);
                }
            }
        }

        public byte[] Signature
        {
            get
            {
                return _Signature;
            }
            set
            {
                if (_Signature != value)
                {
                    _Signature = value;
                    OnPropertyChanged(() => Signature);
                }
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                if (_CreateDate != value)
                {
                    _CreateDate = value;
                    OnPropertyChanged(() => CreateDate);
                }
            }
        }

        public DateTime LastModifiedDate
        {
            get
            {
                return _LastModifiedDate;
            }
            set
            {
                if (_LastModifiedDate != value)
                {
                    _LastModifiedDate = value;
                    OnPropertyChanged(() => LastModifiedDate);
                }
            }
        }

        public string LastModifiedBy
        {
            get
            {
                return _LastModifiedBy;
            }
            set
            {
                if (_LastModifiedBy != value)
                {
                    _LastModifiedBy = value;
                    OnPropertyChanged(() => LastModifiedBy);
                }
            }
        }
    }
}
