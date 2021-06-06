using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfContracts.DataContracts;

namespace WcfContracts
{
    [ServiceContract]
    public interface IUserService : IDisposable
    {
        [OperationContract]
        OperationDetails Create(UserContract userDto);
        [OperationContract]
        ClaimsIdentityContract Authenticate(UserContract userDto);
        [OperationContract]
        void SetInitialData(UserContract adminDto, List<string> roles);
    }
}
