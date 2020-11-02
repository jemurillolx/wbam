using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace wbam.mypages.Models
{
    [DataContract]
    public class ErrorMessage
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}