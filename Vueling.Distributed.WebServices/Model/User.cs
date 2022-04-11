using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CustomValidations;

namespace Vueling.Distributed.WebServices.Model
{
    [DataContract]
    public class User
    {
        [NotNullValidator(MessageTemplate = "Error Name is null")]
        [StringLengthValidator(1, 50)]
        [DataMember]
        public string Name { get; set; }

        [NotNullValidator(MessageTemplate = "Error Surname is null")]
        [StringLengthValidator(1, 50)]
        [DataMember]
        public string Surname { get; set; }

        public int Age { get; set; }

        [NotNullValidator(MessageTemplate = "Error Email is null")]
        [StringLengthValidator(1, 50)]
        [DataMember]
        public string Email { get; set; }
    }
}