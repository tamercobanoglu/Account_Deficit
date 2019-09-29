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

        public static ResultSet CusCRUD(Customers cus, EntityState state) {
            ResultSet r = new ResultSet();
            try {
                r = HelperCustomer.CRUD(cus, state);
                if (r.Message != null) MessageBox.Show(r.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return r;
            }
            catch (Exception e) {
                r.Message = e.Message;
            }
            return r;
        }

        public static ResultSet CateCRUD(Cate cate, EntityState state) {
            ResultSet r = new ResultSet();
            try {
                r = HelperCate.CRUD(cate, state);
                if (r.Message != null) MessageBox.Show(r.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return r;
            }
            catch (Exception e) {
                r.Message = e.Message;
            }
            return r;
        }

        public static ResultSet ProCRUD(Products pro, EntityState state) {
            ResultSet r = new ResultSet();
            try {
                r = HelperProduct.CRUD(pro, state);
                if (r.Message != null) MessageBox.Show(r.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return r;
            }
            catch (Exception e) {
                r.Message = e.Message;
            }
            return r;
        }

        public static ResultSet OrdCRUD(Orders ord, EntityState state) {
            ResultSet r = new ResultSet();
            try {
                r = HelperOrder.CRUD(ord, state);
                if (r.Message != null) MessageBox.Show(r.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return r;
            }
            catch (Exception e) {
                r.Message = e.Message;
            }
            return r;
        }

        public static ResultSet SignCRUD(Signin sign, EntityState state) {
            ResultSet r = new ResultSet();
            try {
                r = HelperSignin.CRUD(sign, state);
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
