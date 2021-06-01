using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfContracts.DataContracts
{
   
    public class PageInfo
    {
    
        public int TotalItems { get; set; }
   
        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
       
    }
}