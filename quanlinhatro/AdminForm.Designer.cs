namespace quanlinhatro
{
	partial class AdminForm
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
            this.grbQuanLiChuTro = new System.Windows.Forms.GroupBox();
            this.dtgQuanLiChuTro = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtCCCDChuTro = new System.Windows.Forms.TextBox();
            this.txtHoTenChuTro = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnQuanLiNhaTro = new System.Windows.Forms.Button();
            this.grbCapNhatChuTro = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbQuyen = new System.Windows.Forms.ComboBox();
            this.cbbTTTKChuTro = new System.Windows.Forms.ComboBox();
            this.grbCapNhatKhachHang = new System.Windows.Forms.GroupBox();
            this.cbbQuyenKH = new System.Windows.Forms.ComboBox();
            this.cbbTTTKKhachHang = new System.Windows.Forms.ComboBox();
            this.txtMatKhauKhachHang = new System.Windows.Forms.TextBox();
            this.txtTenDangNhapKhachHang = new System.Windows.Forms.TextBox();
            this.btnXoa1 = new System.Windows.Forms.Button();
            this.btnThem1 = new System.Windows.Forms.Button();
            this.btnSua1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgQuanLiKH = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.grbQuanLiChuTro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuanLiChuTro)).BeginInit();
            this.grbCapNhatChuTro.SuspendLayout();
            this.grbCapNhatKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuanLiKH)).BeginInit();
            this.SuspendLayout();
            // 
            // grbQuanLiChuTro
            // 
            this.grbQuanLiChuTro.Controls.Add(this.dtgQuanLiChuTro);
            this.grbQuanLiChuTro.Location = new System.Drawing.Point(12, 12);
            this.grbQuanLiChuTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbQuanLiChuTro.Name = "grbQuanLiChuTro";
            this.grbQuanLiChuTro.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbQuanLiChuTro.Size = new System.Drawing.Size(1018, 215);
            this.grbQuanLiChuTro.TabIndex = 0;
            this.grbQuanLiChuTro.TabStop = false;
            this.grbQuanLiChuTro.Text = "Quản Lý Thông Tin  Chủ Trọ";
            // 
            // dtgQuanLiChuTro
            // 
            this.dtgQuanLiChuTro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgQuanLiChuTro.Location = new System.Drawing.Point(7, 26);
            this.dtgQuanLiChuTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgQuanLiChuTro.Name = "dtgQuanLiChuTro";
            this.dtgQuanLiChuTro.RowHeadersWidth = 62;
            this.dtgQuanLiChuTro.RowTemplate.Height = 28;
            this.dtgQuanLiChuTro.Size = new System.Drawing.Size(1088, 186);
            this.dtgQuanLiChuTro.TabIndex = 0;
            this.dtgQuanLiChuTro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(931, 26);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 44);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(931, 92);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(128, 44);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(931, 150);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(123, 44);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtCCCDChuTro
            // 
            this.txtCCCDChuTro.Location = new System.Drawing.Point(281, 72);
            this.txtCCCDChuTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCCCDChuTro.Name = "txtCCCDChuTro";
            this.txtCCCDChuTro.Size = new System.Drawing.Size(238, 26);
            this.txtCCCDChuTro.TabIndex = 4;
            // 
            // txtHoTenChuTro
            // 
            this.txtHoTenChuTro.Location = new System.Drawing.Point(285, 150);
            this.txtHoTenChuTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoTenChuTro.Name = "txtHoTenChuTro";
            this.txtHoTenChuTro.Size = new System.Drawing.Size(238, 26);
            this.txtHoTenChuTro.TabIndex = 5;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(285, 224);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(234, 26);
            this.txtDiaChi.TabIndex = 7;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(-1, 72);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(234, 26);
            this.txtTenDangNhap.TabIndex = 8;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(0, 150);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(234, 26);
            this.txtMatKhau.TabIndex = 9;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(606, 72);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(234, 26);
            this.txtSDT.TabIndex = 10;
            // 
            // btnQuanLiNhaTro
            // 
            this.btnQuanLiNhaTro.Location = new System.Drawing.Point(606, 218);
            this.btnQuanLiNhaTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLiNhaTro.Name = "btnQuanLiNhaTro";
            this.btnQuanLiNhaTro.Size = new System.Drawing.Size(234, 38);
            this.btnQuanLiNhaTro.TabIndex = 12;
            this.btnQuanLiNhaTro.Text = "Quản Lý Thông Tin Nhà Trọ";
            this.btnQuanLiNhaTro.UseVisualStyleBackColor = true;
            this.btnQuanLiNhaTro.Click += new System.EventHandler(this.btnQuanLiNhaTro_Click);
            // 
            // grbCapNhatChuTro
            // 
            this.grbCapNhatChuTro.Controls.Add(this.button1);
            this.grbCapNhatChuTro.Controls.Add(this.label8);
            this.grbCapNhatChuTro.Controls.Add(this.label7);
            this.grbCapNhatChuTro.Controls.Add(this.label6);
            this.grbCapNhatChuTro.Controls.Add(this.label5);
            this.grbCapNhatChuTro.Controls.Add(this.label4);
            this.grbCapNhatChuTro.Controls.Add(this.label3);
            this.grbCapNhatChuTro.Controls.Add(this.label2);
            this.grbCapNhatChuTro.Controls.Add(this.label1);
            this.grbCapNhatChuTro.Controls.Add(this.cbbQuyen);
            this.grbCapNhatChuTro.Controls.Add(this.btnQuanLiNhaTro);
            this.grbCapNhatChuTro.Controls.Add(this.btnXoa);
            this.grbCapNhatChuTro.Controls.Add(this.txtTenDangNhap);
            this.grbCapNhatChuTro.Controls.Add(this.btnSua);
            this.grbCapNhatChuTro.Controls.Add(this.cbbTTTKChuTro);
            this.grbCapNhatChuTro.Controls.Add(this.txtMatKhau);
            this.grbCapNhatChuTro.Controls.Add(this.btnThem);
            this.grbCapNhatChuTro.Controls.Add(this.txtCCCDChuTro);
            this.grbCapNhatChuTro.Controls.Add(this.txtHoTenChuTro);
            this.grbCapNhatChuTro.Controls.Add(this.txtDiaChi);
            this.grbCapNhatChuTro.Controls.Add(this.txtSDT);
            this.grbCapNhatChuTro.Location = new System.Drawing.Point(19, 232);
            this.grbCapNhatChuTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCapNhatChuTro.Name = "grbCapNhatChuTro";
            this.grbCapNhatChuTro.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCapNhatChuTro.Size = new System.Drawing.Size(1088, 274);
            this.grbCapNhatChuTro.TabIndex = 0;
            this.grbCapNhatChuTro.TabStop = false;
            this.grbCapNhatChuTro.Text = "Cập Nhật Thông Tin Của Chủ Trọ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(602, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Thông Tin Tài Khoản Chủ Trọ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(602, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Số Điện Thoại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Địa Chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Họ Tên Chủ Trọ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Số CCCD Chủ Trọ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Quyền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Mật Khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tên Đăng Nhập:";
            // 
            // cbbQuyen
            // 
            this.cbbQuyen.FormattingEnabled = true;
            this.cbbQuyen.Location = new System.Drawing.Point(3, 222);
            this.cbbQuyen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbQuyen.Name = "cbbQuyen";
            this.cbbQuyen.Size = new System.Drawing.Size(234, 28);
            this.cbbQuyen.TabIndex = 20;
            // 
            // cbbTTTKChuTro
            // 
            this.cbbTTTKChuTro.FormattingEnabled = true;
            this.cbbTTTKChuTro.Location = new System.Drawing.Point(606, 152);
            this.cbbTTTKChuTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbTTTKChuTro.Name = "cbbTTTKChuTro";
            this.cbbTTTKChuTro.Size = new System.Drawing.Size(234, 28);
            this.cbbTTTKChuTro.TabIndex = 19;
            // 
            // grbCapNhatKhachHang
            // 
            this.grbCapNhatKhachHang.Controls.Add(this.cbbQuyenKH);
            this.grbCapNhatKhachHang.Controls.Add(this.cbbTTTKKhachHang);
            this.grbCapNhatKhachHang.Controls.Add(this.txtMatKhauKhachHang);
            this.grbCapNhatKhachHang.Controls.Add(this.txtTenDangNhapKhachHang);
            this.grbCapNhatKhachHang.Controls.Add(this.btnXoa1);
            this.grbCapNhatKhachHang.Controls.Add(this.btnThem1);
            this.grbCapNhatKhachHang.Controls.Add(this.btnSua1);
            this.grbCapNhatKhachHang.Location = new System.Drawing.Point(663, 510);
            this.grbCapNhatKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCapNhatKhachHang.Name = "grbCapNhatKhachHang";
            this.grbCapNhatKhachHang.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbCapNhatKhachHang.Size = new System.Drawing.Size(394, 229);
            this.grbCapNhatKhachHang.TabIndex = 22;
            this.grbCapNhatKhachHang.TabStop = false;
            this.grbCapNhatKhachHang.Text = "Cập Nhật Tài Khoản Của Khách Hàng";
            // 
            // cbbQuyenKH
            // 
            this.cbbQuyenKH.FormattingEnabled = true;
            this.cbbQuyenKH.Location = new System.Drawing.Point(24, 134);
            this.cbbQuyenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbQuyenKH.Name = "cbbQuyenKH";
            this.cbbQuyenKH.Size = new System.Drawing.Size(177, 28);
            this.cbbQuyenKH.TabIndex = 22;
            // 
            // cbbTTTKKhachHang
            // 
            this.cbbTTTKKhachHang.FormattingEnabled = true;
            this.cbbTTTKKhachHang.Location = new System.Drawing.Point(24, 189);
            this.cbbTTTKKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbTTTKKhachHang.Name = "cbbTTTKKhachHang";
            this.cbbTTTKKhachHang.Size = new System.Drawing.Size(177, 28);
            this.cbbTTTKKhachHang.TabIndex = 20;
            // 
            // txtMatKhauKhachHang
            // 
            this.txtMatKhauKhachHang.Location = new System.Drawing.Point(24, 78);
            this.txtMatKhauKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhauKhachHang.Name = "txtMatKhauKhachHang";
            this.txtMatKhauKhachHang.Size = new System.Drawing.Size(177, 26);
            this.txtMatKhauKhachHang.TabIndex = 19;
            // 
            // txtTenDangNhapKhachHang
            // 
            this.txtTenDangNhapKhachHang.Location = new System.Drawing.Point(24, 35);
            this.txtTenDangNhapKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDangNhapKhachHang.Name = "txtTenDangNhapKhachHang";
            this.txtTenDangNhapKhachHang.Size = new System.Drawing.Size(177, 26);
            this.txtTenDangNhapKhachHang.TabIndex = 18;
            // 
            // btnXoa1
            // 
            this.btnXoa1.Location = new System.Drawing.Point(236, 179);
            this.btnXoa1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa1.Name = "btnXoa1";
            this.btnXoa1.Size = new System.Drawing.Size(123, 48);
            this.btnXoa1.TabIndex = 17;
            this.btnXoa1.Text = "Xóa";
            this.btnXoa1.UseVisualStyleBackColor = true;
            this.btnXoa1.Click += new System.EventHandler(this.btnXoa1_Click);
            // 
            // btnThem1
            // 
            this.btnThem1.Location = new System.Drawing.Point(236, 25);
            this.btnThem1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem1.Name = "btnThem1";
            this.btnThem1.Size = new System.Drawing.Size(122, 48);
            this.btnThem1.TabIndex = 15;
            this.btnThem1.Text = "Thêm ";
            this.btnThem1.UseVisualStyleBackColor = true;
            this.btnThem1.Click += new System.EventHandler(this.btnThem1_Click);
            // 
            // btnSua1
            // 
            this.btnSua1.Location = new System.Drawing.Point(236, 100);
            this.btnSua1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua1.Name = "btnSua1";
            this.btnSua1.Size = new System.Drawing.Size(122, 48);
            this.btnSua1.TabIndex = 16;
            this.btnSua1.Text = "Sửa";
            this.btnSua1.UseVisualStyleBackColor = true;
            this.btnSua1.Click += new System.EventHandler(this.btnSua1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 510);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(627, 217);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản Lý Tài Khoản Của Khách Hàng";
            // 
            // dtgQuanLiKH
            // 
            this.dtgQuanLiKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgQuanLiKH.Location = new System.Drawing.Point(19, 510);
            this.dtgQuanLiKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgQuanLiKH.Name = "dtgQuanLiKH";
            this.dtgQuanLiKH.RowHeadersWidth = 62;
            this.dtgQuanLiKH.RowTemplate.Height = 28;
            this.dtgQuanLiKH.Size = new System.Drawing.Size(614, 209);
            this.dtgQuanLiKH.TabIndex = 0;
            this.dtgQuanLiKH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgQuanLiKH_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(924, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 51);
            this.button1.TabIndex = 29;
            this.button1.Text = "ThongTinChuTro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 743);
            this.Controls.Add(this.dtgQuanLiKH);
            this.Controls.Add(this.grbCapNhatKhachHang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbCapNhatChuTro);
            this.Controls.Add(this.grbQuanLiChuTro);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.grbQuanLiChuTro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuanLiChuTro)).EndInit();
            this.grbCapNhatChuTro.ResumeLayout(false);
            this.grbCapNhatChuTro.PerformLayout();
            this.grbCapNhatKhachHang.ResumeLayout(false);
            this.grbCapNhatKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuanLiKH)).EndInit();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.GroupBox grbQuanLiChuTro;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtCCCDChuTro;
        private System.Windows.Forms.TextBox txtHoTenChuTro;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.DataGridView dtgQuanLiChuTro;
        private System.Windows.Forms.TextBox txtSDT;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnQuanLiNhaTro;
        private System.Windows.Forms.GroupBox grbCapNhatChuTro;
        private System.Windows.Forms.ComboBox cbbTTTKChuTro;
        private System.Windows.Forms.ComboBox cbbQuyen;
        private System.Windows.Forms.GroupBox grbCapNhatKhachHang;
        private System.Windows.Forms.ComboBox cbbTTTKKhachHang;
        private System.Windows.Forms.TextBox txtMatKhauKhachHang;
        private System.Windows.Forms.TextBox txtTenDangNhapKhachHang;
        private System.Windows.Forms.Button btnXoa1;
        private System.Windows.Forms.Button btnThem1;
        private System.Windows.Forms.Button btnSua1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgQuanLiKH;
        private System.Windows.Forms.ComboBox cbbQuyenKH;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}