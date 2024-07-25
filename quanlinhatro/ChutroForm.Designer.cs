namespace quanlinhatro
{
	partial class ChutroForm
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
            this.dtgDanhSachKhachThue = new System.Windows.Forms.DataGridView();
            this.txtSoCCCD = new System.Windows.Forms.TextBox();
            this.txtHoTenKH = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSoCCCDKH = new System.Windows.Forms.Label();
            this.lblHoTenKH = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnQuanLiPhongTro = new System.Windows.Forms.Button();
            this.btnQuanLiHopDong = new System.Windows.Forms.Button();
            this.btnQuanLiDichVu = new System.Windows.Forms.Button();
            this.btnXemHoaDon = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDanhSachKhachThue)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgDanhSachKhachThue);
            this.groupBox1.Location = new System.Drawing.Point(34, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1005, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách khách thuê ";
            // 
            // dtgDanhSachKhachThue
            // 
            this.dtgDanhSachKhachThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDanhSachKhachThue.Location = new System.Drawing.Point(0, 26);
            this.dtgDanhSachKhachThue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgDanhSachKhachThue.Name = "dtgDanhSachKhachThue";
            this.dtgDanhSachKhachThue.RowHeadersWidth = 62;
            this.dtgDanhSachKhachThue.RowTemplate.Height = 28;
            this.dtgDanhSachKhachThue.Size = new System.Drawing.Size(999, 291);
            this.dtgDanhSachKhachThue.TabIndex = 0;
            this.dtgDanhSachKhachThue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtSoCCCD
            // 
            this.txtSoCCCD.Location = new System.Drawing.Point(104, 31);
            this.txtSoCCCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoCCCD.Name = "txtSoCCCD";
            this.txtSoCCCD.Size = new System.Drawing.Size(216, 26);
            this.txtSoCCCD.TabIndex = 2;
            // 
            // txtHoTenKH
            // 
            this.txtHoTenKH.Location = new System.Drawing.Point(104, 108);
            this.txtHoTenKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoTenKH.Name = "txtHoTenKH";
            this.txtHoTenKH.Size = new System.Drawing.Size(216, 26);
            this.txtHoTenKH.TabIndex = 3;
            this.txtHoTenKH.TextChanged += new System.EventHandler(this.txtHOTENKH_TextChanged);
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(104, 182);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(216, 26);
            this.txtNgaySinh.TabIndex = 4;
            this.txtNgaySinh.TextChanged += new System.EventHandler(this.txtNgaySinh_TextChanged);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(538, 31);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(212, 26);
            this.txtDiaChi.TabIndex = 5;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(538, 108);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(212, 26);
            this.txtSDT.TabIndex = 6;
            // 
            // lblSoCCCDKH
            // 
            this.lblSoCCCDKH.AutoSize = true;
            this.lblSoCCCDKH.Location = new System.Drawing.Point(6, 31);
            this.lblSoCCCDKH.Name = "lblSoCCCDKH";
            this.lblSoCCCDKH.Size = new System.Drawing.Size(82, 20);
            this.lblSoCCCDKH.TabIndex = 8;
            this.lblSoCCCDKH.Text = "Số CCCD:";
            // 
            // lblHoTenKH
            // 
            this.lblHoTenKH.AutoSize = true;
            this.lblHoTenKH.Location = new System.Drawing.Point(6, 108);
            this.lblHoTenKH.Name = "lblHoTenKH";
            this.lblHoTenKH.Size = new System.Drawing.Size(87, 20);
            this.lblHoTenKH.TabIndex = 9;
            this.lblHoTenKH.Text = "Họ tên KH:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(6, 188);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(85, 20);
            this.lblNgaySinh.TabIndex = 10;
            this.lblNgaySinh.Text = "Ngày Sinh:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(422, 31);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(61, 20);
            this.lblDiaChi.TabIndex = 11;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "SDT";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(40, 46);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(109, 42);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(40, 105);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(109, 42);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa ";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(40, 162);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 48);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnQuanLiPhongTro
            // 
            this.btnQuanLiPhongTro.Location = new System.Drawing.Point(68, 386);
            this.btnQuanLiPhongTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLiPhongTro.Name = "btnQuanLiPhongTro";
            this.btnQuanLiPhongTro.Size = new System.Drawing.Size(194, 42);
            this.btnQuanLiPhongTro.TabIndex = 17;
            this.btnQuanLiPhongTro.Text = "Quản Lý Phòng Trọ";
            this.btnQuanLiPhongTro.UseVisualStyleBackColor = true;
            this.btnQuanLiPhongTro.Click += new System.EventHandler(this.btnQuanLiThongTinNhaTro_Click);
            // 
            // btnQuanLiHopDong
            // 
            this.btnQuanLiHopDong.Location = new System.Drawing.Point(284, 386);
            this.btnQuanLiHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLiHopDong.Name = "btnQuanLiHopDong";
            this.btnQuanLiHopDong.Size = new System.Drawing.Size(195, 42);
            this.btnQuanLiHopDong.TabIndex = 18;
            this.btnQuanLiHopDong.Text = "Quản Lý Hợp Đồng";
            this.btnQuanLiHopDong.UseVisualStyleBackColor = true;
            this.btnQuanLiHopDong.Click += new System.EventHandler(this.btnQuanLiHopDong_Click);
            // 
            // btnQuanLiDichVu
            // 
            this.btnQuanLiDichVu.Location = new System.Drawing.Point(507, 386);
            this.btnQuanLiDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLiDichVu.Name = "btnQuanLiDichVu";
            this.btnQuanLiDichVu.Size = new System.Drawing.Size(212, 42);
            this.btnQuanLiDichVu.TabIndex = 19;
            this.btnQuanLiDichVu.Text = "Quản Lý Dịch Vụ";
            this.btnQuanLiDichVu.UseVisualStyleBackColor = true;
            this.btnQuanLiDichVu.Click += new System.EventHandler(this.btnQuanLiDichVu_Click);
            // 
            // btnXemHoaDon
            // 
            this.btnXemHoaDon.Location = new System.Drawing.Point(739, 386);
            this.btnXemHoaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXemHoaDon.Name = "btnXemHoaDon";
            this.btnXemHoaDon.Size = new System.Drawing.Size(187, 42);
            this.btnXemHoaDon.TabIndex = 20;
            this.btnXemHoaDon.Text = "Xem Doanh Thu";
            this.btnXemHoaDon.UseVisualStyleBackColor = true;
            this.btnXemHoaDon.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblSoCCCDKH);
            this.groupBox2.Controls.Add(this.txtSoCCCD);
            this.groupBox2.Controls.Add(this.txtHoTenKH);
            this.groupBox2.Controls.Add(this.txtNgaySinh);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.txtSDT);
            this.groupBox2.Controls.Add(this.lblHoTenKH);
            this.groupBox2.Controls.Add(this.lblNgaySinh);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblDiaChi);
            this.groupBox2.Location = new System.Drawing.Point(43, 448);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(800, 268);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cập nhật thông tin khách thuê";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(538, 188);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 26);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sophong:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDangXuat);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Location = new System.Drawing.Point(876, 448);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(190, 285);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phím chức năng";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(40, 232);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(109, 46);
            this.btnDangXuat.TabIndex = 17;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click_1);
            // 
            // ChutroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 761);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnXemHoaDon);
            this.Controls.Add(this.btnQuanLiDichVu);
            this.Controls.Add(this.btnQuanLiHopDong);
            this.Controls.Add(this.btnQuanLiPhongTro);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChutroForm";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.ChutroForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDanhSachKhachThue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtSoCCCD;
		private System.Windows.Forms.TextBox txtHoTenKH;
		private System.Windows.Forms.TextBox txtNgaySinh;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.TextBox txtSDT;
		private System.Windows.Forms.Label lblSoCCCDKH;
		private System.Windows.Forms.Label lblHoTenKH;
		private System.Windows.Forms.Label lblNgaySinh;
		private System.Windows.Forms.Label lblDiaChi;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dtgDanhSachKhachThue;
        private System.Windows.Forms.Button btnQuanLiPhongTro;
        private System.Windows.Forms.Button btnQuanLiHopDong;
        private System.Windows.Forms.Button btnQuanLiDichVu;
		private System.Windows.Forms.Button btnXemHoaDon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}