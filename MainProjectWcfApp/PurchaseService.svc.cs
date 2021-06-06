using BusinessLogics;
using DbModels.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfContracts;
using WcfContracts.DataContracts;

namespace MainProjectWcfApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "PurchaseService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы PurchaseService.svc или PurchaseService.svc.cs в обозревателе решений и начните отладку.
    public class PurchaseService : IPurchaseService<PurchaseOrderContract>
    {
        ProductionUnitOfWork uow = new ProductionUnitOfWork();
        public List<PurchaseOrderContract> GetAll()
        {
            return Transletors.ModelListToPurchaseOrderContractList(uow.OrderHeader.GetAll());
        }
        public PurchaseOrderContract Get(int id)
        {
            return new PurchaseOrderContract(uow.OrderHeader.Get(id));
        }

        public void Create(PurchaseOrderContract item)
        {
            uow.OrderHeader.Create(Transletors.PurchaseOrderContractToModel(item));
            foreach (var pq in item.OrderProducts)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();
                pod.PurchaseOrderID = uow.OrderHeader.GetAll().OrderByDescending(x => x.PurchaseOrderID).First().PurchaseOrderID;
                pod.DueDate = DateTime.Now; 
                pod.OrderQty = (short)pq.Quantity;
                pod.ProductID = pq.Product.ProductID;
                pod.UnitPrice = pq.Product.StandardCost;
                pod.LineTotal = pq.Quantity * pod.UnitPrice;
                pod.ReceivedQty = 999;
                pod.RejectedQty = 0;
                pod.StockedQty = pod.ReceivedQty - pod.RejectedQty;
                pod.ModifiedDate = DateTime.Now;
                uow.OrderDetail.Create(pod);
            }
        }
        public void Update(PurchaseOrderContract item)
        {
            uow.OrderHeader.Update(Transletors.PurchaseOrderContractToModel(item));
        }
        public void Delete(int id)
        {
            uow.OrderHeader.Delete(id);
        }
        public List<TerritoryContract> GetTerritory()
        {
            return Transletors.TerritoriesToContracts(uow.SalesTerritory.GetAll().ToList());
        }
    }
}
