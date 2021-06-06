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
        OperationDetails Create(UserData userDto);
        [OperationContract]
        ClaimsIdentityContract Authenticate(UserData userDto);
        [OperationContract]
        void SetInitialData(UserData adminDto, List<string> roles);
    }
}
