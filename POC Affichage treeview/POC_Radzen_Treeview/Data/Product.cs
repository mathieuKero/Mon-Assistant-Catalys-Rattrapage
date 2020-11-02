using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Radzen_Treeview.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime PuchaseDate { get; set; }
    }


}
