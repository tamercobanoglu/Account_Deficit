using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using prj_v._1._0.DAL;
using prj_v._1._0.Entity;
using prj_v._1._0.Model;
using System.Windows.Forms;

namespace prj_v._1._0.BLL
{
    class Helper
    {
        public static bool I(string text) {
            return string.IsNullOrEmpty(text);
        }

        public static bool isNumber(string text) {
            foreach (char chr in text) {
                if (Char.IsLetter(chr)) return false;
            }
            return true;
        }

        public static ResultSet CRUD(Customers cus, Cate cate, Products pro, Orders ord, Signin sign, EntityState state, string table) {
            ResultSet r = new ResultSet();
            try {
                switch (table) {
                    case "customer": r = HelperCustomer.CRUD(cus, state); break;
                    case "category": r = HelperCate.CRUD(cate, state); break;
                    case "product": r = HelperProduct.CRUD(pro, state); break;
                    case "order": r = HelperOrder.CRUD(ord, state); break;
                    case "signin": r = HelperSignin.CRUD(sign, state); break;
                    default: break;
                }
                if (r.Message != null) MessageBox.Show(r.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return r;
            }
            catch (Exception e) {
                r.Message = e.Message;
            }
            return r;
        }
    }
}
