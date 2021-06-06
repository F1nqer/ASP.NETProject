using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WcfContracts.DataContracts
{
    [DataContract]
    public class ClaimsIdentityContract : ClaimsIdentity
    {
        [DataMember]
        public ClaimsIdentity claims;
        public ClaimsIdentityContract(ClaimsIdentity claims)
        {
            this.claims = claims;
        }
    }
}
