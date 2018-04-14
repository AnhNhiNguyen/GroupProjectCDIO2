namespace QuanLiCoffeeCShapeDotNet
{
    partial class Account
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.btnLogin = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupbox1 = new System.Windows.Forms.GroupBox();
			this.txtError = new System.Windows.Forms.TextBox();
			this.cBShowPasswork = new System.Windows.Forms.CheckBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupbox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(70, 214);
			this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(105, 43);
			this.btnLogin.TabIndex = 3;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 124);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(151, 52);
			this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(122, 28);
			this.txtUsername.TabIndex = 1;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(151, 119);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(122, 28);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 56);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "UserName";
			// 
			// groupbox1
			// 
			this.groupbox1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.groupbox1.Controls.Add(this.txtError);
			this.groupbox1.Controls.Add(this.cBShowPasswork);
			this.groupbox1.Controls.Add(this.pictureBox3);
			this.groupbox1.Controls.Add(this.pictureBox2);
			this.groupbox1.Controls.Add(this.btnLogin);
			this.groupbox1.Controls.Add(this.label2);
			this.groupbox1.Controls.Add(this.txtUsername);
			this.groupbox1.Controls.Add(this.txtPassword);
			this.groupbox1.Controls.Add(this.label1);
			this.groupbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupbox1.Location = new System.Drawing.Point(2, 11);
			this.groupbox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupbox1.Name = "groupbox1";
			this.groupbox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupbox1.Size = new System.Drawing.Size(278, 331);
			this.groupbox1.TabIndex = 6;
			this.groupbox1.TabStop = false;
			this.groupbox1.Text = "                Coffee House         ";
			// 
			// txtError
			// 
			this.txtError.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtError.Location = new System.Drawing.Point(8, 275);
			this.txtError.Margin = new System.Windows.Forms.Padding(2);
			this.txtError.Multiline = true;
			this.txtError.Name = "txtError";
			this.txtError.Size = new System.Drawing.Size(264, 45);
			this.txtError.TabIndex = 6;
			this.txtError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cBShowPasswork
			// 
			this.cBShowPasswork.AutoSize = true;
			this.cBShowPasswork.Location = new System.Drawing.Point(53, 176);
			this.cBShowPasswork.Margin = new System.Windows.Forms.Padding(2);
			this.cBShowPasswork.Name = "cBShowPasswork";
			this.cBShowPasswork.Size = new System.Drawing.Size(163, 28);
			this.cBShowPasswork.TabIndex = 5;
			this.cBShowPasswork.Text = "Show password";
			this.cBShowPasswork.UseVisualStyleBackColor = true;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
			this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox3.Location = new System.Drawing.Point(98, 115);
			this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(39, 37);
			this.pictureBox3.TabIndex = 4;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox2.Location = new System.Drawing.Point(110, 52);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(20, 28);
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(285, -2);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(469, 344);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// Account
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 340);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupbox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Account";
			this.Text = "Account";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Account_FormClosed);
			this.Load += new System.EventHandler(this.Account_Load);
			this.groupbox1.ResumeLayout(false);
			this.groupbox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.CheckBox cBShowPasswork;
        private System.Windows.Forms.TextBox txtError;
    }
}