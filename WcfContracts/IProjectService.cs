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
    public interface IProjectService<TEntity>
    {
        [OperationContract] 
        List<TEntity> GetAll();
        [OperationContract]
        TEntity Get(int id);
        [OperationContract]
        void Create(TEntity item);

        [OperationContract]
        void Update(TEntity item);
        [OperationContract]
        void Delete(int id);
        [OperationContract]
        ProductPageContract GetPage(int page = 1);
    }
}
