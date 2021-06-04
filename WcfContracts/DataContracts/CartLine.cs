using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfContracts.DataContracts
{
    [DataContract]
    public class CartLine
    {
        [DataMember]
        public ProductContract Product { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
