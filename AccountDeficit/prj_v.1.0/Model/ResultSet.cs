using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prj_v._1._0.Entity;

namespace prj_v._1._0.Model
{
    class ResultSet
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public MessageType messageType { get; set; }
        //public string icon { get; set; }
        public IconType iconType { get; set; }
        public Customers Customer = new Customers();
        public Cate Cate = new Cate();
        public Products Product = new Products();
        public Orders Order = new Orders();
        public Signin Signin = new Signin();
    }

    enum MessageType {
        info, Catch
    }

    enum IconType {
        ok, warning, delete, update
    }
}
