namespace quanlinhatro
{
    partial class QuanLiHopDong
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtgQuanLiHopDong = new System.Windows.Forms.DataGridView();
			this.btnChapNhan = new System.Windows.Forms.Button();
			this.btnDinhChi = new System.Windows.Forms.Button();
			this.btnChamDut = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgQuanLiHopDong)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtgQuanLiHopDong);
			this.groupBox1.Location = new System.Drawing.Point(27, 18);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(660, 208);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Xử Lý Hợp Đồng";
			// 
			// dtgQuanLiHopDong
			// 
			this.dtgQuanLiHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgQuanLiHopDong.Location = new System.Drawing.Point(0, 20);
			this.dtgQuanLiHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dtgQuanLiHopDong.Name = "dtgQuanLiHopDong";
			this.dtgQuanLiHopDong.RowHeadersWidth = 62;
			this.dtgQuanLiHopDong.RowTemplate.Height = 28;
			this.dtgQuanLiHopDong.Size = new System.Drawing.Size(660, 183);
			this.dtgQuanLiHopDong.TabIndex = 0;
			this.dtgQuanLiHopDong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// btnChapNhan
			// 
			this.btnChapNhan.Location = new System.Drawing.Point(139, 249);
			this.btnChapNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnChapNhan.Name = "btnChapNhan";
			this.btnChapNhan.Size = new System.Drawing.Size(104, 63);
			this.btnChapNhan.TabIndex = 1;
			this.btnChapNhan.Text = "Chấp Nhận";
			this.btnChapNhan.UseVisualStyleBackColor = true;
			this.btnChapNhan.Click += new System.EventHandler(this.btnChapNhan_Click);
			// 
			// btnDinhChi
			// 
			this.btnDinhChi.Location = new System.Drawing.Point(289, 249);
			this.btnDinhChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnDinhChi.Name = "btnDinhChi";
			this.btnDinhChi.Size = new System.Drawing.Size(115, 63);
			this.btnDinhChi.TabIndex = 2;
			this.btnDinhChi.Text = "Đình Chỉ";
			this.btnDinhChi.UseVisualStyleBackColor = true;
			this.btnDinhChi.Click += new System.EventHandler(this.btnDinhChi_Click);
			// 
			// btnChamDut
			// 
			this.btnChamDut.Location = new System.Drawing.Point(435, 249);
			this.btnChamDut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnChamDut.Name = "btnChamDut";
			this.btnChamDut.Size = new System.Drawing.Size(115, 63);
			this.btnChamDut.TabIndex = 3;
			this.btnChamDut.Text = "Chấm Dứt";
			this.btnChamDut.UseVisualStyleBackColor = true;
			this.btnChamDut.Click += new System.EventHandler(this.btnChamDut_Click);
			// 
			// QuanLiHopDong
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(711, 360);
			this.Controls.Add(this.btnChamDut);
			this.Controls.Add(this.btnDinhChi);
			this.Controls.Add(this.btnChapNhan);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "QuanLiHopDong";
			this.Text = "Quản Lí Hợp Đồng";
			this.Load += new System.EventHandler(this.QuanLiHopDong_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgQuanLiHopDong)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgQuanLiHopDong;
        private System.Windows.Forms.Button btnChapNhan;
        private System.Windows.Forms.Button btnDinhChi;
        private System.Windows.Forms.Button btnChamDut;
    }
}