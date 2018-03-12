namespace QuanLiCoffeeCShapeDotNet
{
	partial class frmGopBan
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
			this.tabGopBan = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabGopBan
			// 
			this.tabGopBan.Location = new System.Drawing.Point(12, 12);
			this.tabGopBan.Name = "tabGopBan";
			this.tabGopBan.SelectedIndex = 0;
			this.tabGopBan.Size = new System.Drawing.Size(760, 537);
			this.tabGopBan.TabIndex = 0;
			// 
			// frmGopBan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.tabGopBan);
			this.Name = "frmGopBan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmGopBan";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGopBan_FormClosed);
			this.Load += new System.EventHandler(this.frmGopBan_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabGopBan;
	}
}