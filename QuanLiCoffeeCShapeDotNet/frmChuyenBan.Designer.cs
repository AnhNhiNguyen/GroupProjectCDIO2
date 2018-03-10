namespace QuanLiCoffeeCShapeDotNet
{
	partial class frmChuyenBan
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
			this.tabEmptyTable = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabEmptyTable
			// 
			this.tabEmptyTable.Location = new System.Drawing.Point(12, 12);
			this.tabEmptyTable.Name = "tabEmptyTable";
			this.tabEmptyTable.SelectedIndex = 0;
			this.tabEmptyTable.Size = new System.Drawing.Size(760, 537);
			this.tabEmptyTable.TabIndex = 0;
			// 
			// frmChuyenBan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.tabEmptyTable);
			this.Name = "frmChuyenBan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh sách bàn trống";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChuyenBan_FormClosed);
			this.Load += new System.EventHandler(this.frmChuyenBan_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabEmptyTable;
	}
}