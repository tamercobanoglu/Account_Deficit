namespace prj_v._1._0.UI
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.tpEmployee = new System.Windows.Forms.TabPage();
            this.pbLoginE = new System.Windows.Forms.PictureBox();
            this.btLoginE = new System.Windows.Forms.Button();
            this.lblWrongE = new System.Windows.Forms.Label();
            this.lblHintE = new System.Windows.Forms.Label();
            this.tbPwE = new System.Windows.Forms.TextBox();
            this.tbUserE = new System.Windows.Forms.TextBox();
            this.lblUserE = new System.Windows.Forms.Label();
            this.lblPwE = new System.Windows.Forms.Label();
            this.lblWarningE = new System.Windows.Forms.Label();
            this.tcUser = new System.Windows.Forms.TabControl();
            this.tpEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginE)).BeginInit();
            this.tcUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpEmployee
            // 
            this.tpEmployee.Controls.Add(this.pbLoginE);
            this.tpEmployee.Controls.Add(this.btLoginE);
            this.tpEmployee.Controls.Add(this.lblWrongE);
            this.tpEmployee.Controls.Add(this.lblHintE);
            this.tpEmployee.Controls.Add(this.tbPwE);
            this.tpEmployee.Controls.Add(this.tbUserE);
            this.tpEmployee.Controls.Add(this.lblUserE);
            this.tpEmployee.Controls.Add(this.lblPwE);
            this.tpEmployee.Controls.Add(this.lblWarningE);
            this.tpEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tpEmployee.Location = new System.Drawing.Point(4, 27);
            this.tpEmployee.Name = "tpEmployee";
            this.tpEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployee.Size = new System.Drawing.Size(378, 484);
            this.tpEmployee.TabIndex = 0;
            this.tpEmployee.Text = "Admin Giriş Bölümü";
            this.tpEmployee.UseVisualStyleBackColor = true;
            // 
            // pbLoginE
            // 
            this.pbLoginE.Image = ((System.Drawing.Image)(resources.GetObject("pbLoginE.Image")));
            this.pbLoginE.Location = new System.Drawing.Point(116, 18);
            this.pbLoginE.Name = "pbLoginE";
            this.pbLoginE.Size = new System.Drawing.Size(156, 149);
            this.pbLoginE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoginE.TabIndex = 0;
            this.pbLoginE.TabStop = false;
            // 
            // btLoginE
            // 
            this.btLoginE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btLoginE.Location = new System.Drawing.Point(116, 289);
            this.btLoginE.Name = "btLoginE";
            this.btLoginE.Size = new System.Drawing.Size(156, 47);
            this.btLoginE.TabIndex = 2;
            this.btLoginE.Text = "Giriş";
            this.btLoginE.UseVisualStyleBackColor = true;
            this.btLoginE.Click += new System.EventHandler(this.BtLoginE_Click);
            // 
            // lblWrongE
            // 
            this.lblWrongE.AutoSize = true;
            this.lblWrongE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWrongE.ForeColor = System.Drawing.Color.Red;
            this.lblWrongE.Location = new System.Drawing.Point(113, 383);
            this.lblWrongE.Name = "lblWrongE";
            this.lblWrongE.Size = new System.Drawing.Size(128, 18);
            this.lblWrongE.TabIndex = 1;
            this.lblWrongE.Text = "Giriş bilgileri hatalı!";
            this.lblWrongE.Visible = false;
            // 
            // lblHintE
            // 
            this.lblHintE.AutoSize = true;
            this.lblHintE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHintE.Location = new System.Drawing.Point(113, 354);
            this.lblHintE.Name = "lblHintE";
            this.lblHintE.Size = new System.Drawing.Size(51, 18);
            this.lblHintE.TabIndex = 1;
            this.lblHintE.Text = "İpucu: ";
            this.lblHintE.Visible = false;
            // 
            // tbPwE
            // 
            this.tbPwE.AcceptsReturn = true;
            this.tbPwE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbPwE.Location = new System.Drawing.Point(116, 242);
            this.tbPwE.Name = "tbPwE";
            this.tbPwE.PasswordChar = '*';
            this.tbPwE.Size = new System.Drawing.Size(186, 24);
            this.tbPwE.TabIndex = 1;
            // 
            // tbUserE
            // 
            this.tbUserE.AcceptsReturn = true;
            this.tbUserE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbUserE.Location = new System.Drawing.Point(116, 199);
            this.tbUserE.Name = "tbUserE";
            this.tbUserE.Size = new System.Drawing.Size(186, 24);
            this.tbUserE.TabIndex = 0;
            // 
            // lblUserE
            // 
            this.lblUserE.AutoSize = true;
            this.lblUserE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUserE.Location = new System.Drawing.Point(20, 205);
            this.lblUserE.Name = "lblUserE";
            this.lblUserE.Size = new System.Drawing.Size(90, 18);
            this.lblUserE.TabIndex = 1;
            this.lblUserE.Text = "Kullanıcı Adı:";
            // 
            // lblPwE
            // 
            this.lblPwE.AutoSize = true;
            this.lblPwE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPwE.Location = new System.Drawing.Point(68, 248);
            this.lblPwE.Name = "lblPwE";
            this.lblPwE.Size = new System.Drawing.Size(42, 18);
            this.lblPwE.TabIndex = 1;
            this.lblPwE.Text = "Şifre:";
            // 
            // lblWarningE
            // 
            this.lblWarningE.AutoSize = true;
            this.lblWarningE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWarningE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWarningE.ForeColor = System.Drawing.Color.Blue;
            this.lblWarningE.Location = new System.Drawing.Point(116, 450);
            this.lblWarningE.Name = "lblWarningE";
            this.lblWarningE.Size = new System.Drawing.Size(156, 18);
            this.lblWarningE.TabIndex = 1;
            this.lblWarningE.Text = "Şifrenizi mi unuttunuz?";
            this.lblWarningE.Click += new System.EventHandler(this.LblWarningE_Click);
            // 
            // tcUser
            // 
            this.tcUser.Controls.Add(this.tpEmployee);
            this.tcUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tcUser.Location = new System.Drawing.Point(6, 12);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(386, 515);
            this.tcUser.TabIndex = 4;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btLoginE;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 535);
            this.Controls.Add(this.tcUser);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Açık V.1.0 Special Edition   |   Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.tpEmployee.ResumeLayout(false);
            this.tpEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginE)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpEmployee;
        private System.Windows.Forms.PictureBox pbLoginE;
        private System.Windows.Forms.Button btLoginE;
        private System.Windows.Forms.Label lblWrongE;
        private System.Windows.Forms.Label lblHintE;
        private System.Windows.Forms.TextBox tbPwE;
        private System.Windows.Forms.TextBox tbUserE;
        private System.Windows.Forms.Label lblUserE;
        private System.Windows.Forms.Label lblPwE;
        private System.Windows.Forms.Label lblWarningE;
        private System.Windows.Forms.TabControl tcUser;
    }
}