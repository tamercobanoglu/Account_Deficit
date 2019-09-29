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
    class HelperCustomer
    {
        static ResultSet r = new ResultSet();

        public static Customers GetCustomer(int customerID) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Customers.Where(x => x.customerID == customerID).FirstOrDefault();
            }
        }

        public static int GetCustomerID(string name, string sname, string phone, string addressLine) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Customers.Where(x => x.cFirstName == name && x.cLastName == sname
                && x.phone == phone && x.addressLine == addressLine).FirstOrDefault().customerID;
            }
        }

        public static int GetCustomerID(string fullName) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Customers.Where(x => x.cFirstName + " " + x.cLastName == fullName).FirstOrDefault().customerID;
            }
        }

        public static string GetCustomerFullName(int customerID) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                var cus = s.Customers.Where(x => x.customerID == customerID).FirstOrDefault();

                return cus.cFirstName + " " + cus.cLastName;
            }
        }

        public static List<string> GetPhoneNumbers() {
            List<string> numbers = new List<string>();
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                foreach (var item in GetCustomerList()) numbers.Add(item.phone);
                return numbers;
            }
        }

        public static List<Customers> GetCustomerList() {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                return s.Customers.ToList();
            }
        }

        public static ResultSet CRUD(Customers cus, EntityState state) {
            using (AccDeficitEntities s = new AccDeficitEntities()) {
                s.Entry(cus).State = state;

                if (s.SaveChanges() > 0) {
                    r.isSuccess = true;
                    if (state == EntityState.Added) r.Message = "Müşteri sisteme başarıyla eklendi!";
                    else if (state == EntityState.Modified) r.Message = null;
                    else if (state == EntityState.Deleted) r.Message = null;
                    r.Customer = cus;
                    r.iconType = IconType.ok;
                }
                else {
                    r.isSuccess = false;
                    r.Message = "Hata!!";
                    r.Customer = cus;
                    r.iconType = IconType.warning;
                }
                return r;
            }
        }
    }
}
