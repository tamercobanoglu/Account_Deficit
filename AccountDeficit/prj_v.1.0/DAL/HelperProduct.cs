using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using prj_v._1._0.Model;
using prj_v._1._0.Entity;

namespace prj_v._1._0.DAL
{
    class HelperProduct
    {
        static ResultSet r = new ResultSet();

		public static Products GetProduct(int productID) {
			using (AccDeficitEntities s = new AccDeficitEntities()) {
				return s.Products.Where(x => x.productID == productID).FirstOrDefault();
			}
		}

		public static ProductModel GetProductModel(int productID) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var dbPro = s.Products.Where(x => x.productID == productID).FirstOrDefault();

                return ConvertToModel(dbPro);
            }
        }

		public static int GetProductID(string proName, string proCate, double prePrice, double salePrice, int stock, string explanation) {
			using (AccDeficitEntities s = new AccDeficitEntities()) {
				return s.Products.Where(x => x.proName == proName && x.Cate.cateName == proCate
				&& x.prePrice == prePrice && x.salePrice == salePrice
				&& x.quantity == stock && x.Cate.explanation == explanation).FirstOrDefault().productID;
			}
		}

        public static int GetProductID(string proName, double salePrice, string explanation) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Products.Where(x => x.proName == proName && x.salePrice == salePrice
                && x.Cate.explanation == explanation).FirstOrDefault().productID;
            }
        }

        public static List<ProductModel> GetProductModelList() {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var dbList = s.Products.ToList();

                return ConvertToModelList(dbList);
            }
        }

        public static ProductModel ConvertToModel(Products dbPro) {
            ProductModel pm = new ProductModel();
            pm.productID = dbPro.productID;
            pm.proName = dbPro.proName;
            pm.prePrice = dbPro.prePrice;
            pm.salePrice = dbPro.salePrice;
            pm.quantity = dbPro.quantity;
            pm.addDate = dbPro.addDate;

            pm.Cate.cateID = dbPro.Cate.cateID;
            pm.Cate.cateName = dbPro.Cate.cateName;
            pm.Cate.explanation = dbPro.Cate.explanation;

            return pm;
        }

        public static List<ProductModel> ConvertToModelList(List<Products> dbList) {
            List<ProductModel> pmList = new List<ProductModel>();

            foreach (var item in dbList) pmList.Add(ConvertToModel(item));
            return pmList;
        }

        public static ResultSet CRUD(Products pro, EntityState state) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                s.Entry(pro).State = state;

                if (s.SaveChanges() > 0) {
                    r.isSuccess = true;
                    if (state == EntityState.Added) r.Message = "Ürün sisteme başarıyla eklendi!";
                    else if (state == EntityState.Modified) r.Message = null;
                    else if (state == EntityState.Deleted) r.Message = null;
                    r.Product = pro;
                    r.iconType = IconType.ok;
                }
                else {
                    r.isSuccess = false;
                    r.Message = "Hata!!";
                    r.Product = pro;
                    r.iconType = IconType.warning;
                }
                return r;
            }
        }
    }
}
