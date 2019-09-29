using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prj_v._1._0.Entity;

namespace prj_v._1._0.Model
{
    class ProductModel
    {
        public int productID { get; set; }
        public string proName { get; set; }
        public Nullable<double> prePrice { get; set; }
        public Nullable<double> salePrice { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> addDate { get; set; }
        public Nullable<int> cateID { get; set; }

        public Cate Cate = new Cate();
    }
}
