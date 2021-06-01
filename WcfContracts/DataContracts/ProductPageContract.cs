using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfContracts.DataContracts
{
    [DataContract]
    public class ProductPageContract
    {
        [DataMember]
        public IEnumerable<ProductContract> Products { get; set; }
        [DataMember]
        public PageInfo PageInfo { get; set; }
    }
}
