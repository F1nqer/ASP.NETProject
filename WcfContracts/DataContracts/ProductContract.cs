using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfContracts.DataContracts
{
    [DataContract]
    public class ProductContract
    {
        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ProductNumber { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public short SafetyStockLevel { get; set; }

        [DataMember]
        public decimal StandardCost { get; set; }

        [DataMember]
        public decimal ListPrice { get; set; }

        [DataMember]
        public string Size { get; set; }

        [DataMember]
        public decimal? Weight { get; set; }

        [DataMember]
        public int DaysToManufacture { get; set; }

        [DataMember]
        public string ProductLine { get; set; }

        [DataMember]
        public string Class { get; set; }

        [DataMember]
        public string Style { get; set; }

        [DataMember]
        public int? ProductModelID { get; set; }

        [DataMember]
        public DateTime ModifiedDate { get; set; }

        [DataMember]
        public byte[] ThumbNailPhoto { get; set; }

        [DataMember]
        public byte[] LargePhoto { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}