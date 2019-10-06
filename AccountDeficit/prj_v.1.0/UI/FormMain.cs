using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using prj_v._1._0.Entity;
using prj_v._1._0.BLL;
using prj_v._1._0.DAL;
using prj_v._1._0.Model;

namespace prj_v._1._0.UI
{
    public partial class FormMain : Form
    {
        static int signinID, cusID, cateID, proID, sellProID;
        static double profit;
        static string userName, section;
        static DateTime firsDate = DateTime.Now.Date, lastDate = DateTime.Now.Date;

        static ResultSet r = new ResultSet();
        static ResultSet rr = new ResultSet();

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(int signinID)
        {
            FormMain.signinID = signinID;
			userName = HelperSignin.GetUser(signinID).userName;
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Hoşgeldiniz Sn. {userName}";

            DisplayCustomers();
            DisplayCategories();
            DisplayProducts();
            DisplayOrders();

            cbCustomers.DataSource = HelperCustomer.GetCustomerList();
            ComboBoxCateSources();

            rbCustomers.Checked = true;

            // The date the first orders added to database..
            dtpFirstDate.Value = new System.DateTime(2019, 09, 28);
            dtpFirstDate.MaxDate = DateTime.Now.Date;
            dtpLastDate.MaxDate = DateTime.Now.Date;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            //Application.ExitThread();
            //Environment.Exit();
        }

        void DisplayCustomers() {
            dgvCustomers.Rows.Clear();
            foreach (var item in HelperCustomer.GetCustomerList()) {
                dgvCustomers.Rows.Add(item.cFirstName, item.cLastName, item.phone, item.addressLine);
            }
        }

        void DisplayCategories() {
            dgvCategories.Rows.Clear();
            foreach (var item in HelperCate.GetCateList()) {
                dgvCategories.Rows.Add(item.cateName, item.explanation);
            }
        }

        void ComboBoxCateSources() {
            cbCategoryList.DataSource = HelperCate.GetCateList();
            cbCategory.DataSource = HelperCate.GetCateList();
            cbCategory1.DataSource = HelperCate.GetCateList();
        }

        void DisplayProducts() {
            dgvProducts.Rows.Clear();
            foreach (var item in HelperProduct.GetProductModelList()) {
                dgvProducts.Rows.Add(item.proName, item.Cate.cateName, item.prePrice, item.salePrice, item.quantity, item.Cate.explanation);
            }
        }

        void DisplayOrders(string section, string query, DateTime firstDate, DateTime lastDate) {
            profit = 0; dgvOrders.Rows.Clear();
            List<OrderModel> list = new List<OrderModel>();
            List<OrderModel> list2 = new List<OrderModel>();

            if (section == "customer") list = HelperOrder.GetOrderModelCusList(query);
            else if (section == "product") list = HelperOrder.GetOrderModelProList(query);
            else if (section == "category") list = HelperOrder.GetOrderModelCateList(query);
            else list = HelperOrder.GetOrderModelList();

            foreach (var item in list) {
                if (Convert.ToDateTime(item.orderDate).Ticks >= firstDate.Ticks
                    && Convert.ToDateTime(item.orderDate).Ticks <= lastDate.Ticks) list2.Add(item);
            }

            SubDisplayOrders(list2);
        }

        void DisplayOrders(DateTime firstDate, DateTime lastDate) {
            profit = 0; dgvOrders.Rows.Clear();
            List<OrderModel> list = new List<OrderModel>();
            List<OrderModel> list2 = new List<OrderModel>();

            list = HelperOrder.GetOrderModelList();
            foreach (var item in list) {
                if (Convert.ToDateTime(item.orderDate).Ticks >= firstDate.Ticks
                    && Convert.ToDateTime(item.orderDate).Ticks <= lastDate.Ticks) list2.Add(item);
            }

            SubDisplayOrders(list2);
        }

        void DisplayOrders() {
            profit = 0; dgvOrders.Rows.Clear();
            SubDisplayOrders(HelperOrder.GetOrderModelList());
        }

        void SubDisplayOrders(List<OrderModel> list) {
            foreach (var item in list) {
                string ctName = HelperCate.GetCate(Convert.ToInt32(HelperProduct.GetProduct(Convert.ToInt32(item.Products.productID)).cateID)).cateName;

                dgvOrders.Rows.Add(item.Customers.cFirstName + " " + item.Customers.cLastName, 
                    ctName, item.Products.proName, item.piece, item.Products.salePrice, 
                    Convert.ToDateTime(item.orderDate).ToShortDateString());

                profit += (Convert.ToDouble(item.Products.salePrice) - Convert.ToDouble(item.Products.prePrice));
            }
            lblProfit.Text = profit.ToString();
        }

        private void BtChangePw_Click(object sender, EventArgs e)
        {
            bool result = Helper.I(tbOldPassWord.Text) || Helper.I(tbPassWord.Text) || Helper.I(tbPassWord1.Text);
            if (result) MessageBox.Show("Tüm alanları doldurunuz!");

            else {
                var user = HelperSignin.GetUser(signinID);
                if (user != null) {
                    if (user.userPassword == tbOldPassWord.Text) {
                        if (tbPassWord.Text == tbPassWord1.Text) {
                            user.userPassword = tbPassWord.Text;
                            r = Helper.CRUD(null, null, null, null, user, EntityState.Modified, "signin");

                            tbOldPassWord.Clear();
                            tbPassWord.Clear(); tbPassWord1.Clear();
                        }
                        else MessageBox.Show("Girilen şifreler birbirinden farklı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show("Eski şifrenizi yanlış girdiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Kayıt başarısız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtAddCus_Click(object sender, EventArgs e)
        {
            bool result = Helper.I(tbName.Text) || Helper.I(tbSname.Text) || Helper.I(mtbPhone.Text) || Helper.I(tbAddress.Text);
            if (result) MessageBox.Show("Tüm alanları doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else {
                var list = HelperCustomer.GetPhoneNumbers();
                if (list.Contains(mtbPhone.Text)) MessageBox.Show("Bu telefon numarası sistemde kayıtlıdır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else {
                    if (mtbPhone.Text.Length == 14) {
                        Customers cus = new Customers {
                            cFirstName = tbName.Text,
                            cLastName = tbSname.Text,
                            phone = mtbPhone.Text,
                            addressLine = tbAddress.Text,
                            addDate = DateTime.Now.Date
                        };

                        r = Helper.CRUD(cus, null, null, null, null, EntityState.Added, "customer");
                        if (r.isSuccess) {
                            tbName.Clear(); tbSname.Clear();
                            mtbPhone.Clear(); tbAddress.Clear();

                            DisplayCustomers();
                            cbCustomers.DataSource = HelperCustomer.GetCustomerList();
                        }

                        else {
                            lblWarningCus.Visible = true;
                            lblWarningCus.Text = r.Message;
                        }
                    }

                    else {
                        mtbPhone1.Clear();
                        MessageBox.Show("Girdiğiniz telefon numarası geçersizdir!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

		private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            lblWarningCus.Visible = false;
            string name = null, sname = null, phone = null, addressLine = null;
            if (dgvCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
                dgvCustomers.CurrentRow.Selected = true;
                name = dgvCustomers.Rows[e.RowIndex].Cells["cFirstName"].FormattedValue.ToString();
                sname = dgvCustomers.Rows[e.RowIndex].Cells["cLastName"].FormattedValue.ToString();
                phone = dgvCustomers.Rows[e.RowIndex].Cells["phone"].FormattedValue.ToString();
                addressLine = dgvCustomers.Rows[e.RowIndex].Cells["addressLine"].FormattedValue.ToString();
            }

            cusID = HelperCustomer.GetCustomerID(name, sname, phone, addressLine);
        }

		private void BtRowEditCus_Click(object sender, EventArgs e)
		{
            var cus = HelperCustomer.GetCustomer(cusID);
            if (cus != null) {
                gbEditCus.Enabled = true;
                tbName1.Clear(); tbSname1.Clear();
                mtbPhone1.Clear(); tbAddress1.Clear();
            }
        }

        private void BtEditCus_Click(object sender, EventArgs e)
        {
            var cus = HelperCustomer.GetCustomer(cusID);
            if (cus != null) {
                int c = 0;
                if (!Helper.I(tbName1.Text)) { cus.cFirstName = tbName1.Text; c++; }
                if (!Helper.I(tbSname1.Text)) { cus.cLastName = tbSname1.Text; c++; }
                if (mtbPhone1.Text.Length == 14) { cus.phone = mtbPhone1.Text; c++; }
                if (!Helper.I(tbAddress1.Text)) { cus.addressLine = tbAddress1.Text; c++; }

                r = Helper.CRUD(cus, null, null, null, null, EntityState.Modified, "customer");
                if (r.isSuccess) {
                    tbName1.Clear(); tbSname1.Clear();
                    mtbPhone1.Clear(); tbAddress1.Clear();

                    DisplayCustomers();
                    cbCustomers.DataSource = HelperCustomer.GetCustomerList();

                    if (c != 0) {
                        lblWarningCus.Visible = true;
                        lblWarningCus.Text = "Müşteri bilgileri düzenlendi!";
                    }
                }

                else {
                    lblWarningCus.Visible = true;
                    lblWarningCus.Text = r.Message;
                }
            }

            gbEditCus.Enabled = false;
        }

        private void BtRowDelCus_Click(object sender, EventArgs e)
        {
            var cus = HelperCustomer.GetCustomer(cusID);
            if (cus != null) {
                var result = MessageBox.Show("Bu işlem geri alınamaz. Yine de silinsin mi?", "SİL?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes) {
                    r = Helper.CRUD(cus, null, null, null, null, EntityState.Deleted, "customer");
                    if (r.isSuccess) {
                        DisplayCustomers();
                        cbCustomers.DataSource = HelperCustomer.GetCustomerList();

                        lblWarningCus.Visible = true;
                        lblWarningCus.Text = "Müşteri silindi!";
                    }
                    else {
                        lblWarningCus.Visible = true;
                        lblWarningCus.Text = r.Message;
                    }
                }
            }
        }

        private void BtAddCate_Click(object sender, EventArgs e)
        {
            bool result = Helper.I(tbCateName.Text) || Helper.I(tbExp.Text);
            if (result) MessageBox.Show("Tüm alanları doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else {
                List<string> list = new List<string>();
                foreach (var item in HelperCate.GetCateList()) list.Add(item.cateName);

                if (list.Contains(tbCateName.Text)) MessageBox.Show("Bu kategori sistemde kayıtlıdır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else {
                    Cate ct = new Cate {
                        cateName = tbCateName.Text,
                        explanation = tbExp.Text,
                        addDate = DateTime.Now.Date
                    };

                    r = Helper.CRUD(null, ct, null, null, null, EntityState.Added, "category");
                    if (r.isSuccess) {
                        tbCateName.Clear(); tbExp.Clear();

                        DisplayCategories();
                        ComboBoxCateSources();
                    }
                }
            }
        }

        private void DgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			string categoryName = null, explanation = null;
			if (dgvCategories.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
				dgvCategories.CurrentRow.Selected = true;
				categoryName = dgvCategories.Rows[e.RowIndex].Cells["categoryName"].FormattedValue.ToString();
				explanation = dgvCategories.Rows[e.RowIndex].Cells["explanation1"].FormattedValue.ToString();
			}

			cateID = HelperCate.GetCateID(categoryName, explanation);
		}

        private void BtRowEditCate_Click(object sender, EventArgs e)
        {
            var ct = HelperCate.GetCate(cateID);
            if (ct != null) {
                gbEditCate.Enabled = true;
                tbCateName1.Clear(); tbExp1.Clear();
            }
        }

        private void BtEditCate_Click(object sender, EventArgs e)
        {
            var ct = HelperCate.GetCate(cateID);
            if (ct != null) {
                int c = 0;
                if (!Helper.I(tbCateName1.Text)) { ct.cateName = tbCateName1.Text; c++; }
                if (!Helper.I(tbExp1.Text)) { ct.explanation = tbExp1.Text; c++; }

                r = Helper.CRUD(null, ct, null, null, null, EntityState.Modified, "category");
                if (r.isSuccess) {
                    tbCateName1.Clear(); tbExp1.Clear();

                    DisplayCategories();
                    DisplayProducts();
                    DisplayOrders();
                    ComboBoxCateSources();

                    if (c != 0) {
                        MessageBox.Show("Kategori güncellendi!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }

            gbEditCate.Enabled = false;
        }

        private void BtRowDelCate_Click(object sender, EventArgs e)
        {
            var ct = HelperCate.GetCate(cateID);
            if (ct != null) {
                var result = MessageBox.Show("Bu işlem geri alınamaz. Yine de silinsin mi?", "SİL?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    r = Helper.CRUD(null, ct, null, null, null, EntityState.Deleted, "category");
                    if (r.isSuccess) {
                        DisplayCategories();
                        DisplayProducts();
                        DisplayOrders();
                        ComboBoxCateSources();
                    }
                }
            }
        }

        private void BtAddPro_Click(object sender, EventArgs e)
        {
            bool result = Helper.I(tbProName.Text) || Helper.I(tbPrePrice.Text) || Helper.I(tbSalePrice.Text) || Helper.I(tbStock.Text);
            if (result) MessageBox.Show("Tüm alanları doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else {
                List<string> list = new List<string>();
                foreach (var item in HelperProduct.GetProductModelList()) list.Add(item.proName);

                if (list.Contains(tbProName.Text)) MessageBox.Show("Bu ürün sistemde kayıtlıdır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else {
					Products pro = new Products {
						proName = tbProName.Text,
						prePrice = Convert.ToDouble(tbPrePrice.Text),
						salePrice = Convert.ToDouble(tbSalePrice.Text),
						quantity = Convert.ToInt32(tbStock.Text),
						addDate = DateTime.Now.Date,
						cateID = Convert.ToInt32(cbCategory.SelectedValue)
					};

                    r = Helper.CRUD(null, null, pro, null, null, EntityState.Added, "product");
                    if (r.isSuccess) {
						tbProName.Clear(); cbCategory.SelectedIndex = 0;
						tbPrePrice.Clear(); tbSalePrice.Clear(); tbStock.Clear();
						DisplayProducts();
					}
				}
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			lblWarningPro.Visible = false;
			string proName = null, proCate = null, prePrice = null, salePrice = null, stock = null, explanation = null;
			if (dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
				dgvProducts.CurrentRow.Selected = true;
				proName = dgvProducts.Rows[e.RowIndex].Cells["proName"].FormattedValue.ToString();
				proCate = dgvProducts.Rows[e.RowIndex].Cells["proCate"].FormattedValue.ToString();
				prePrice = dgvProducts.Rows[e.RowIndex].Cells["prePrice"].FormattedValue.ToString();
				salePrice = dgvProducts.Rows[e.RowIndex].Cells["salePrice"].FormattedValue.ToString();
				stock = dgvProducts.Rows[e.RowIndex].Cells["stock"].FormattedValue.ToString();
				explanation = dgvProducts.Rows[e.RowIndex].Cells["explanation"].FormattedValue.ToString();
			}
			
			proID = HelperProduct.GetProductID(proName, proCate, Convert.ToDouble(prePrice), Convert.ToDouble(salePrice), Convert.ToInt32(stock), explanation);
		}

        private void BtRowEditPro_Click(object sender, EventArgs e)
        {
			var pro = HelperProduct.GetProductModel(proID);
			if (pro != null) {
				gbEditPro.Enabled = true;
				tbProName1.Clear(); cbCategory.SelectedIndex = 0;
				tbPrePrice1.Clear(); tbSalePrice1.Clear(); tbStock1.Clear();
			}
		}

        private void BtEditPro_Click(object sender, EventArgs e)
        {
			var pro = HelperProduct.GetProduct(proID);
            int previousCateID = Convert.ToInt32(pro.cateID);

			if (pro != null) {
				int c = 0;
				if (!Helper.I(tbProName1.Text)) { pro.proName = tbProName1.Text; c++; }
				if (!Helper.I(tbPrePrice1.Text)) { pro.prePrice = Convert.ToDouble(tbPrePrice1.Text); c++; }
				if (!Helper.I(tbSalePrice1.Text)) { pro.salePrice = Convert.ToDouble(tbSalePrice1.Text); c++; }
				if (!Helper.I(tbStock1.Text)) { pro.quantity = Convert.ToInt32(tbStock1.Text); c++; }
                pro.cateID = Convert.ToInt32(cbCategory1.SelectedValue);
                if (previousCateID != pro.cateID) c++;

                r = Helper.CRUD(null, null, pro, null, null, EntityState.Modified, "product");
                if (r.isSuccess) {
					tbProName1.Clear(); cbCategory1.SelectedIndex = 0;
					tbPrePrice1.Clear(); tbSalePrice1.Clear(); tbStock1.Clear();
					DisplayProducts();
                    DisplayOrders();

					if (c != 0) {
						lblWarningPro.Visible = true;
						lblWarningPro.Text = "Ürün bilgileri düzenlendi!";
					}
				}

                else {
                    lblWarningPro.Visible = true;
                    lblWarningPro.Text = r.Message;
                }
            }

			gbEditPro.Enabled = false;
		}

        private void BtRowDelPro_Click(object sender, EventArgs e)
        {
			var pro = HelperProduct.GetProduct(proID);
			if (pro != null) {
				var result = MessageBox.Show("Bu işlem geri alınamaz. Yine de silinsin mi?", "SİL?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes) {
                    r = Helper.CRUD(null, null, pro, null, null, EntityState.Deleted, "product");

                    if (r.isSuccess) {
						DisplayProducts();
                        DisplayOrders();
                        lblWarningPro.Visible = true;
						lblWarningPro.Text = "Ürün silindi!";
					}
					else {
						lblWarningPro.Visible = true;
						lblWarningPro.Text = r.Message;
					}
				}
			}
		}

		private void CbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            tbExplanation.Text = HelperCate.GetCate(Convert.ToInt32(cbCategory.SelectedValue)).explanation;
        }

        private void CbCategory1_SelectedValueChanged(object sender, EventArgs e)
        {
			tbExplanation1.Text = HelperCate.GetCate(Convert.ToInt32(cbCategory1.SelectedValue)).explanation;
		}

		private void TbPrePrice_KeyPress(object sender, KeyPressEventArgs e)
		{
			DigitOnly(sender, e, false);
		}

		private void TbSalePrice_KeyPress(object sender, KeyPressEventArgs e)
		{
			DigitOnly(sender, e, false);
		}

		private void TbStock_KeyPress(object sender, KeyPressEventArgs e)
		{
			DigitOnly(sender, e, true);
		}

		private void TbPrePrice1_KeyPress(object sender, KeyPressEventArgs e)
		{
			DigitOnly(sender, e, false);
		}

		private void TbSalePrice1_KeyPress(object sender, KeyPressEventArgs e)
		{
			DigitOnly(sender, e, false);
		}

        private void TbStock1_KeyPress(object sender, KeyPressEventArgs e)
		{
			DigitOnly(sender, e, true);
		}

        void DigitOnly(object sender, KeyPressEventArgs e, bool stock) {
			if (stock) {
				if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))) e.Handled = true;
			}
			
			else {
				if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))) e.Handled = true;

				// only allow one decimal point
				if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1)) e.Handled = true;
			}
		}

        private void BtListCategories_Click(object sender, EventArgs e)
		{
			dgvSellPro.Visible = true;
			lblSelectPro.Visible = true;

			dgvSellPro.Rows.Clear();
			foreach (var item in HelperProduct.GetProductModelList()) {
				if(item.Cate.cateName == cbCategoryList.GetItemText(cbCategoryList.SelectedItem))
                    dgvSellPro.Rows.Add(item.proName, item.salePrice, item.Cate.explanation);
			}
		}

        private void CbCustomers_Format(object sender, ListControlConvertEventArgs e)
        {
            string firstname = ((Customers)e.ListItem).cFirstName;
            string lastname = ((Customers)e.ListItem).cLastName;
            e.Value = firstname + " " + lastname;
        }

        private void DgvSellPro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gbSellPro.Visible = true;
            string sellProName = null, sellProPrice = null, sellProExp = null;
            if (dgvSellPro.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
                dgvSellPro.CurrentRow.Selected = true;
                sellProName = dgvSellPro.Rows[e.RowIndex].Cells["sellProName"].FormattedValue.ToString();
                sellProPrice = dgvSellPro.Rows[e.RowIndex].Cells["sellProPrice"].FormattedValue.ToString();
                sellProExp = dgvSellPro.Rows[e.RowIndex].Cells["sellProExp"].FormattedValue.ToString();
            }

            sellProID = HelperProduct.GetProductID(sellProName, Convert.ToDouble(sellProPrice), sellProExp);
            tbSelectedPro.Text = HelperProduct.GetProduct(sellProID).proName;
        }

        private void TbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitOnly(sender, e, true);
        }

        private void BtCompleteOrder_Click(object sender, EventArgs e)
        {
            bool result = Helper.I(tbQuantity.Text);
            if (result) MessageBox.Show("Adet bilgisini giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {
                int custID = HelperCustomer.GetCustomerID(cbCustomers.GetItemText(cbCustomers.SelectedItem));
                var pro = HelperProduct.GetProduct(sellProID);

                if (pro != null) {
                    if (pro.quantity < Convert.ToInt32(tbQuantity.Text)) {
                        if (pro.quantity == 0) MessageBox.Show("Bu ürün tükenmiştir!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else MessageBox.Show($"Bu üründen stokta {pro.quantity} adet kaldı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else {
                        Orders ord = new Orders {
                            piece = Convert.ToInt32(tbQuantity.Text),
                            orderDate = DateTime.Now.Date,
                            productID = sellProID,
                            customerID = custID
                        };

                        r = Helper.CRUD(null, null, null, ord, null, EntityState.Added, "order");
                        if (r.isSuccess) {
                            pro.quantity -= Convert.ToInt32(tbQuantity.Text);
                            rr = Helper.CRUD(null, null, pro, null, null, EntityState.Modified, "product");
                        }

                        tbQuantity.Clear();
                        DisplayProducts();
                        DisplayOrders();
                    }
                }
            }
        }

        private void RbCustomers_CheckedChanged(object sender, EventArgs e)
        {
            section = "customer";
            DispOrd("rb");
        }

        private void RbProName_CheckedChanged(object sender, EventArgs e)
        {
            section = "product";
            DispOrd("rb");
        }

        private void RbCategory_CheckedChanged(object sender, EventArgs e)
        {
            section = "category";
            DispOrd("rb");
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            DispOrd("rb");
        }

        private void DtpFirstDate_ValueChanged(object sender, EventArgs e)
        {
            dtpLastDate.MinDate = dtpFirstDate.Value;
            firsDate = Convert.ToDateTime(dtpFirstDate.Value);

            DispOrd("dtp");
        }

        private void DtpLastDate_ValueChanged(object sender, EventArgs e)
        {
            lastDate = Convert.ToDateTime(dtpLastDate.Value);

            DispOrd("dtp");
        }

        void DispOrd(string type) {
            if (type == "rb") {
                if (tbSearch.Text == null) DisplayOrders();
                else DisplayOrders(section, tbSearch.Text, firsDate, lastDate);
            }

            else if (type == "dtp") {
                if (tbSearch.Text == null) DisplayOrders(firsDate, lastDate);
                else DisplayOrders(section, tbSearch.Text, firsDate, lastDate);
            }
        }
    }
}
