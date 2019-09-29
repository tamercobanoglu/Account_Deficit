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
using prj_v._1._0.DAL;
using prj_v._1._0.UI;
using prj_v._1._0.BLL;
using prj_v._1._0.Entity;

namespace prj_v._1._0.UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
            //Environment.Exit();
        }

        private void BtLoginE_Click(object sender, EventArgs e)
        {
            var List = HelperSignin.GetUserList();
            Signin sign = HelperSignin.Item(List, tbUserE.Text, tbPwE.Text);
            if (sign != null) {
                FormMain f = new FormMain(sign.signinID);

                if (f.ShowDialog(this) == DialogResult.OK) f.Show();
                else

                f.Dispose();
            }
            else {
                tbUserE.Clear(); tbPwE.Clear();
                lblWrongE.Visible = true;
            }
        }

        private void LblWarningE_Click(object sender, EventArgs e)
        {
            lblHintE.Visible = true;
            lblHintE.Text = "İpucu: İlk evcil hayvanınızın adı";
        }
    }
}
