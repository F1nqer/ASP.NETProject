using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfContracts.DataContracts;

namespace WcfContracts
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IPurchaseService<T>
    {
        [OperationContract]
        List<T> GetAll();
        [OperationContract]
        T Get(int id);
        [OperationContract]
        void Create(T item);
        [OperationContract]
        void Update(T item);
        [OperationContract]
        void Delete(int id);
        [OperationContract]
        List<TerritoryContract> GetTerritory(); 
    }
}
