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
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.btnDongBillAndPrint = new System.Windows.Forms.Button();
			this.btnInBill = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtTienKhachDua = new System.Windows.Forms.NumericUpDown();
			this.txtTienThoiLai = new System.Windows.Forms.NumericUpDown();
			this.txtTongTienThanhToan = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTienKhachDua)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTienThoiLai)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTongTienThanhToan)).BeginInit();
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
			// button4
			// 
			this.button4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.button4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button4.Location = new System.Drawing.Point(298, 312);
			this.button4.Margin = new System.Windows.Forms.Padding(2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 50);
			this.button4.TabIndex = 15;
			this.button4.Text = "Hủy bỏ";
			this.button4.UseVisualStyleBackColor = false;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button3.Location = new System.Drawing.Point(298, 258);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 50);
			this.button3.TabIndex = 16;
			this.button3.Text = "   Đóng bill \r\n    không In";
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.UseVisualStyleBackColor = false;
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
			this.btnDongBillAndPrint.Click += new System.EventHandler(this.btnInBill_Click);
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
			// txtTienThoiLai
			// 
			this.txtTienThoiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTienThoiLai.Location = new System.Drawing.Point(250, 141);
			this.txtTienThoiLai.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.txtTienThoiLai.Name = "txtTienThoiLai";
			this.txtTienThoiLai.ReadOnly = true;
			this.txtTienThoiLai.Size = new System.Drawing.Size(168, 44);
			this.txtTienThoiLai.TabIndex = 20;
			this.txtTienThoiLai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTienThoiLai.ThousandsSeparator = true;
			// 
			// txtTongTienThanhToan
			// 
			this.txtTongTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTongTienThanhToan.Location = new System.Drawing.Point(250, 52);
			this.txtTongTienThanhToan.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.txtTongTienThanhToan.Name = "txtTongTienThanhToan";
			this.txtTongTienThanhToan.ReadOnly = true;
			this.txtTongTienThanhToan.Size = new System.Drawing.Size(168, 44);
			this.txtTongTienThanhToan.TabIndex = 20;
			this.txtTongTienThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTongTienThanhToan.ThousandsSeparator = true;
			// 
			// frmPayment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.ClientSize = new System.Drawing.Size(442, 380);
			this.Controls.Add(this.txtTongTienThanhToan);
			this.Controls.Add(this.txtTienThoiLai);
			this.Controls.Add(this.txtTienKhachDua);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
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
			this.Load += new System.EventHandler(this.frmPayment_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTienKhachDua)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTienThoiLai)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTongTienThanhToan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDongBillAndPrint;
        private System.Windows.Forms.Button btnInBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.NumericUpDown txtTienKhachDua;
		private System.Windows.Forms.NumericUpDown txtTienThoiLai;
		private System.Windows.Forms.NumericUpDown txtTongTienThanhToan;
	}
}