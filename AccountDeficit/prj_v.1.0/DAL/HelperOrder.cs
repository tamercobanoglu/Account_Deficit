using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prj_v._1._0.Entity;
using prj_v._1._0.Model;
using System.Data.Entity;

namespace prj_v._1._0.DAL
{
    class HelperOrder
    {
        static ResultSet r = new ResultSet();

        public static OrderModel GetOrderModel(int orderID) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var dbOrd = s.Orders.Where(x => x.orderID == orderID).FirstOrDefault();

                return ConvertToModel(dbOrd);
            }
        }

        public static List<OrderModel> GetOrderModelList() {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var dbList = s.Orders.ToList();

                return ConvertToModelList(dbList);
            }
        }

        public static List<OrderModel> GetOrderModelCusList(string query) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var dbList = s.Orders.Where(x => (x.Customers.cFirstName + " " + x.Customers.cLastName).Contains(query)).ToList();

                return ConvertToModelList(dbList);
            }
        }

        public static List<OrderModel> GetOrderModelProList(string query) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var dbList = s.Orders.Where(x => x.Products.proName.Contains(query)).ToList();

                return ConvertToModelList(dbList);
            }
        }

        public static List<OrderModel> GetOrderModelCateList(string query) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var cateList = s.Cate.Where(x => x.cateName.Contains(query)).ToList();
                List<Orders> dbOrdList = new List<Orders>();

                foreach (var item in cateList) {
                    var ordList = s.Orders.Where(x => x.Products.cateID == item.cateID).ToList();
                    dbOrdList.AddRange(ordList);
                }
                return ConvertToModelList(dbOrdList);
            }
        }

        public static List<OrderModel> GetOrderModelList(int cusID) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var dbList = s.Orders.Where(x => x.Customers.customerID == cusID).ToList();

                return ConvertToModelList(dbList);
            }
        }

        public static OrderModel ConvertToModel(Orders dbOrd)
        {
            OrderModel om = new OrderModel();
            om.orderID = dbOrd.orderID;
            om.piece = dbOrd.piece;
            om.orderDate = dbOrd.orderDate;

            om.Products.productID = dbOrd.Products.productID;
            om.Products.proName = dbOrd.Products.proName;
            om.Products.salePrice = dbOrd.Products.salePrice;
            om.Products.prePrice = dbOrd.Products.prePrice;
            om.Products.cateID = dbOrd.Products.cateID;

            om.Customers.customerID = dbOrd.Customers.customerID;
            om.Customers.cFirstName = dbOrd.Customers.cFirstName;
            om.Customers.cLastName = dbOrd.Customers.cLastName;

            return om;
        }

        public static List<OrderModel> ConvertToModelList(List<Orders> dbList) {
            List<OrderModel> omList = new List<OrderModel>();

            foreach (var item in dbList) omList.Add(ConvertToModel(item));
            return omList;
        }

        public static ResultSet CRUD(Orders ord, EntityState state) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                s.Entry(ord).State = state;

                if (s.SaveChanges() > 0) {
                    r.isSuccess = true;
                    r.Message = "Satış kaydı eklendi!";
                    r.Order = ord;
                    r.iconType = IconType.ok;
                }
                else {
                    r.isSuccess = false;
                    r.Message = "Hata!!";
                    r.Order = ord;
                    r.iconType = IconType.warning;
                }
                return r;
            }
        }
    }
}
