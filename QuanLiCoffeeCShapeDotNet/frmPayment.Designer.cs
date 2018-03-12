namespace QuanLiCoffeeCShapeDotNet
{
    partial class frmPayment
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
			this.label5 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnDongBill = new System.Windows.Forms.Button();
			this.btnDongBillAndPrint = new System.Windows.Forms.Button();
			this.btnInBill = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtTienKhachDua = new System.Windows.Forms.NumericUpDown();
			this.txtTongTienThanhToan = new System.Windows.Forms.TextBox();
			this.txtTienThoiLai = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTienKhachDua)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(16, 209);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(250, 150);
			this.label5.TabIndex = 18;
			this.label5.Text = resources.GetString("label5.Text");
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
			this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.Location = new System.Drawing.Point(298, 312);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(120, 50);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Hủy bỏ";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnDongBill
			// 
			this.btnDongBill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnDongBill.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDongBill.Image = ((System.Drawing.Image)(resources.GetObject("btnDongBill.Image")));
			this.btnDongBill.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDongBill.Location = new System.Drawing.Point(298, 258);
			this.btnDongBill.Margin = new System.Windows.Forms.Padding(2);
			this.btnDongBill.Name = "btnDongBill";
			this.btnDongBill.Size = new System.Drawing.Size(120, 50);
			this.btnDongBill.TabIndex = 16;
			this.btnDongBill.Text = "   Đóng bill \r\n    không In";
			this.btnDongBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDongBill.UseVisualStyleBackColor = false;
			this.btnDongBill.Click += new System.EventHandler(this.btnDongBill_Click);
			// 
			// btnDongBillAndPrint
			// 
			this.btnDongBillAndPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnDongBillAndPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnDongBillAndPrint.Image")));
			this.btnDongBillAndPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDongBillAndPrint.Location = new System.Drawing.Point(298, 204);
			this.btnDongBillAndPrint.Margin = new System.Windows.Forms.Padding(2);
			this.btnDongBillAndPrint.Name = "btnDongBillAndPrint";
			this.btnDongBillAndPrint.Size = new System.Drawing.Size(120, 50);
			this.btnDongBillAndPrint.TabIndex = 17;
			this.btnDongBillAndPrint.Text = "Đóng bill và In";
			this.btnDongBillAndPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDongBillAndPrint.UseVisualStyleBackColor = false;
			this.btnDongBillAndPrint.Click += new System.EventHandler(this.btnDongBillAndPrint_Click);
			// 
			// btnInBill
			// 
			this.btnInBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInBill.Location = new System.Drawing.Point(298, 9);
			this.btnInBill.Margin = new System.Windows.Forms.Padding(2);
			this.btnInBill.Name = "btnInBill";
			this.btnInBill.Size = new System.Drawing.Size(120, 28);
			this.btnInBill.TabIndex = 11;
			this.btnInBill.Text = "In thử bill";
			this.btnInBill.UseVisualStyleBackColor = true;
			this.btnInBill.Click += new System.EventHandler(this.btnInBill_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(139, 10);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 24);
			this.label2.TabIndex = 7;
			this.label2.Text = "Bàn: ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(137, 154);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 24);
			this.label4.TabIndex = 8;
			this.label4.Text = "Trả lại";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(137, 111);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 24);
			this.label3.TabIndex = 9;
			this.label3.Text = "Khách đưa";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(139, 65);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 24);
			this.label1.TabIndex = 10;
			this.label1.Text = "Tổng tiền";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(-1, 11);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(134, 167);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// txtTienKhachDua
			// 
			this.txtTienKhachDua.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTienKhachDua.Location = new System.Drawing.Point(250, 95);
			this.txtTienKhachDua.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.txtTienKhachDua.Name = "txtTienKhachDua";
			this.txtTienKhachDua.Size = new System.Drawing.Size(168, 44);
			this.txtTienKhachDua.TabIndex = 20;
			this.txtTienKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTienKhachDua.ThousandsSeparator = true;
			this.txtTienKhachDua.ValueChanged += new System.EventHandler(this.txtTienKhachDua_ValueChanged);
			// 
			// txtTongTienThanhToan
			// 
			this.txtTongTienThanhToan.Enabled = false;
			this.txtTongTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTongTienThanhToan.Location = new System.Drawing.Point(250, 51);
			this.txtTongTienThanhToan.Name = "txtTongTienThanhToan";
			this.txtTongTienThanhToan.Size = new System.Drawing.Size(168, 44);
			this.txtTongTienThanhToan.TabIndex = 21;
			// 
			// txtTienThoiLai
			// 
			this.txtTienThoiLai.Enabled = false;
			this.txtTienThoiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTienThoiLai.Location = new System.Drawing.Point(250, 140);
			this.txtTienThoiLai.Name = "txtTienThoiLai";
			this.txtTienThoiLai.Size = new System.Drawing.Size(168, 44);
			this.txtTienThoiLai.TabIndex = 21;
			// 
			// frmPayment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.ClientSize = new System.Drawing.Size(442, 380);
			this.Controls.Add(this.txtTienThoiLai);
			this.Controls.Add(this.txtTongTienThanhToan);
			this.Controls.Add(this.txtTienKhachDua);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnDongBill);
			this.Controls.Add(this.btnDongBillAndPrint);
			this.Controls.Add(this.btnInBill);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frmPayment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Payment";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayment_FormClosed);
			this.Load += new System.EventHandler(this.frmPayment_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTienKhachDua)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDongBill;
        private System.Windows.Forms.Button btnDongBillAndPrint;
        private System.Windows.Forms.Button btnInBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.NumericUpDown txtTienKhachDua;
		private System.Windows.Forms.TextBox txtTongTienThanhToan;
		private System.Windows.Forms.TextBox txtTienThoiLai;
	}
}