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
    class HelperSignin
    {
        static ResultSet r = new ResultSet();

        public static Signin GetUser(int signinID) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Signin.Where(x => x.signinID == signinID).FirstOrDefault();
            }
        }

        public static List<Signin> GetUserList() {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Signin.ToList();
            }
        }

        public static Signin Item(List<Signin> List, string username, string password) {
            Signin newItem = null;
            foreach (var item in List) {
                if (item.userName == username) {
                    if (item.userPassword == password) {
                        newItem = item;
                        break;
                    }
                }
            }
            return newItem;
        }

        public static ResultSet CRUD(Signin sign, EntityState state) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                s.Entry(sign).State = state;

                if (s.SaveChanges() > 0) {
                    r.isSuccess = true;
                    r.Message = "Şifre başarıyla değiştirildi!";
                    r.Signin = sign;
                    r.iconType = IconType.ok;
                }
                else {
                    r.isSuccess = false;
                    r.Message = "Hata!!";
                    r.Signin = sign;
                    r.iconType = IconType.warning;
                }
                return r;
            }
        }
    }
}
