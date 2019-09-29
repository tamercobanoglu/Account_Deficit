using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prj_v._1._0.Entity;

namespace prj_v._1._0.Model
{
    class OrderModel
    {
        public int orderID { get; set; }
        public Nullable<int> piece { get; set; }
        public Nullable<System.DateTime> orderDate { get; set; }
        public Nullable<int> productID { get; set; }
        public Nullable<int> customerID { get; set; }

        public Customers Customers = new Customers();
        public Products Products = new Products();
    }
}
