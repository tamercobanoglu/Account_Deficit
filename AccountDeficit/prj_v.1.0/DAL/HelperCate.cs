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
    class HelperCate
    {
        static ResultSet r = new ResultSet();

        public static Cate GetCate(int cateID) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Cate.Where(x => x.cateID == cateID).FirstOrDefault();
            }
        }

        public static int GetCateIDbyName(string cName) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Cate.Where(x => x.cateName == cName).FirstOrDefault().cateID;
            }
        }

        public static int GetCateID(string cName, string exp) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Cate.Where(x => x.cateName == cName && x.explanation == exp).FirstOrDefault().cateID;
            }
        }

        public static List<Cate> GetCateList() {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Cate.ToList();
            }
        }

        public static ResultSet CRUD(Cate cate, EntityState state) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                s.Entry(cate).State = state;

                if (s.SaveChanges() > 0) {
                    r.isSuccess = true;
                    if (state == EntityState.Added) r.Message = "Kategori sisteme başarıyla eklendi!";
                    else if (state == EntityState.Modified) r.Message = null;
                    else if (state == EntityState.Deleted) r.Message = "Kategori silindi!";
                    r.Cate = cate;
                    r.iconType = IconType.ok;
                }
                else {
                    r.isSuccess = false;
                    r.Message = "Hata!!";
                    r.Cate = cate;
                    r.iconType = IconType.warning;
                }
                return r;
            }
        }
    }
}
