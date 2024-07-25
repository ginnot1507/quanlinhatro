using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace quanlinhatro
{
	public partial class AdminForm : Form
	{
		
		public AdminForm()
		{
			InitializeComponent();
		}

		private void AdminForm_Load(object sender, EventArgs e)
		{
            cbbTTTKChuTro.Items.Add("ConHD");
            cbbTTTKChuTro.Items.Add("HetHD");
            cbbQuyen.Items.Add("Chutro");
            cbbTTTKKhachHang.Items.Add("ConHD");
            cbbTTTKKhachHang.Items.Add("HetHD");
            cbbQuyenKH.Items.Add("Khachthue");
            hienthidanhsachkh();
            hienthidanhsach();
            cbbTTTKChuTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTTTKKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbQuyenKH.DropDownStyle = ComboBoxStyle.DropDownList;

        }
		private void kiemtracn()
		{
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}
			}
		}

		//ham khachhang
		private void hienthidanhsachkh()
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "SELECT TENDANGNHAP, MATKHAU,QUYEN,TTTKKHACHTHUE FROM QLTK WHERE QUYEN = 'Khachthue'";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgQuanLiKH.DataSource = dataTable;
            }
        }
		private void btnThem1_Click(object sender, EventArgs e)
		{
			kiemtracn();
			string TenDangNhap = txtTenDangNhapKhachHang.Text.Trim();
			string MatKhau = txtMatKhauKhachHang.Text.Trim();
			string QuyenKH = cbbQuyenKH.Text.Trim();
			string TTTKKhachThue = cbbTTTKKhachHang.SelectedItem?.ToString();

			// Kiểm tra các textbox không được bỏ trống
			if (string.IsNullOrEmpty(TenDangNhap) || string.IsNullOrEmpty(MatKhau) ||
				string.IsNullOrEmpty(QuyenKH) || string.IsNullOrEmpty(TTTKKhachThue))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
				return;
			}

			// Kiểm tra TENDANGNHAP không được trùng nhau
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
				connection.Open();

				// Kiểm tra tồn tại của TENDANGNHAP
				string checkQuery = "SELECT COUNT(*) FROM QLTK WHERE TENDANGNHAP = @TenDangNhap";
				SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
				checkCmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
				int existingCount = (int)checkCmd.ExecuteScalar();

				if (existingCount > 0)
				{
					MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác");
					return;
				}

				SqlCommand insertCmd = new SqlCommand();
				insertCmd.CommandType = CommandType.Text;
				insertCmd.CommandText = "INSERT INTO QLTK (TENDANGNHAP, MATKHAU, QUYEN, TTTKKHACHTHUE) VALUES (@TenDangNhap, @MatKhau, @QuyenKH, @TTTKKhachThue)";
				insertCmd.Connection = connection;
				insertCmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
				insertCmd.Parameters.AddWithValue("@MatKhau", MatKhau);
				insertCmd.Parameters.AddWithValue("@QuyenKH", QuyenKH);
				insertCmd.Parameters.AddWithValue("@TTTKKhachThue", TTTKKhachThue);

				int rowsAffected = insertCmd.ExecuteNonQuery();
				if (rowsAffected > 0)
				{
					MessageBox.Show("Thêm thành công");
					hienthidanhsachkh();
				}
				else
				{
					MessageBox.Show("Thêm không thành công");
				}
			}
		}


		private void btnSua1_Click(object sender, EventArgs e)//ham sua kh
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "UPDATE QLTK SET MATKHAU = @matkhau,QUYEN = @Quyen ,TTTKKHACHTHUE = @TTTKKhachThue WHERE TENDANGNHAP = @tendangnhap";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@matkhau", txtMatKhauKhachHang.Text);
                command.Parameters.AddWithValue("@Quyen", cbbQuyenKH.Text);
                command.Parameters.AddWithValue("@TTTKKhachThue", cbbTTTKKhachHang.Text);
                command.Parameters.AddWithValue("@tendangnhap", txtTenDangNhapKhachHang.Text);

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");

                    hienthidanhsachkh();
                }
                else
                {
                    MessageBox.Show("Khong cập nhật thành công!");


                }
            }
        }

        private void btnXoa1_Click(object sender, EventArgs e)//ham xoa kh
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                SqlCommand deleteCmd = new SqlCommand();
                deleteCmd.CommandType = CommandType.Text;
                deleteCmd.CommandText = "DELETE FROM QLTK WHERE TENDANGNHAP = @tendangnhap";

                // Gán giá trị cho tham số truy vấn
                deleteCmd.Parameters.AddWithValue("@tendangnhap", txtTenDangNhapKhachHang.Text);

                deleteCmd.Connection = connection;
                int kq = deleteCmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công!");

                    hienthidanhsachkh();
                }
                else
                {
                    MessageBox.Show("Không xóa thành công!");
                }
            }
        }

        private void dtgQuanLiKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgQuanLiKH.Rows[e.RowIndex];
                txtTenDangNhapKhachHang.Text = row.Cells["TENDANGNHAP"].Value.ToString();
                txtMatKhauKhachHang.Text = row.Cells["MATKHAU"].Value.ToString();
                cbbQuyenKH.Text = row.Cells["QUYEN"].Value.ToString();
                cbbTTTKKhachHang.Text = row.Cells["TTTKKHACHTHUE"].Value.ToString();
            }
        }

        private void hienthidanhsach()
		{
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "SELECT TENDANGNHAP, MATKHAU,QUYEN,HOTENCHUTRO,DIACHI,SDT,CCCDCHUTRO,TTTKCHUTRO FROM QLTK WHERE QUYEN = 'Chutro'";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgQuanLiChuTro.DataSource = dataTable;
            }
        }
		private void btnThem_Click(object sender, EventArgs e)
		{
			kiemtracn();
			string TenDangNhap = txtTenDangNhap.Text.Trim();
			string MatKhau = txtMatKhau.Text.Trim();
			string Quyen = cbbQuyen.SelectedItem?.ToString();
			string CCCDchuTro = txtCCCDChuTro.Text.Trim();
			string HoTenChuTro = txtHoTenChuTro.Text.Trim();
			string DiaChi = txtDiaChi.Text.Trim();
			string SDT = txtSDT.Text.Trim();
			string TTTKChuTro = cbbTTTKChuTro.SelectedItem?.ToString();

			// Kiểm tra tất cả các trường không được để trống
			if (string.IsNullOrEmpty(TenDangNhap) && string.IsNullOrEmpty(MatKhau) && string.IsNullOrEmpty(Quyen) &&
				string.IsNullOrEmpty(CCCDchuTro) && string.IsNullOrEmpty(HoTenChuTro) && string.IsNullOrEmpty(DiaChi) &&
				string.IsNullOrEmpty(SDT) && string.IsNullOrEmpty(TTTKChuTro))
			{
				MessageBox.Show("Vui lòng nhập thông tin vào");
				return;
			}

			// Kiểm tra từng trường riêng lẻ
			if (string.IsNullOrEmpty(TenDangNhap))
			{
				MessageBox.Show("Vui lòng nhập Tên đăng nhập");
				return;
			}

			if (string.IsNullOrEmpty(MatKhau))
			{
				MessageBox.Show("Vui lòng nhập Mật khẩu");
				return;
			}

			if (string.IsNullOrEmpty(Quyen))
			{
				MessageBox.Show("Vui lòng chọn Quyền");
				return;
			}

			if (string.IsNullOrEmpty(CCCDchuTro))
			{
				MessageBox.Show("Vui lòng nhập CCCD Chủ trọ");
				return;
			}

			if (string.IsNullOrEmpty(HoTenChuTro))
			{
				MessageBox.Show("Vui lòng nhập Họ tên Chủ trọ");
				return;
			}

			if (string.IsNullOrEmpty(DiaChi))
			{
				MessageBox.Show("Vui lòng nhập Địa chỉ");
				return;
			}

			if (string.IsNullOrEmpty(SDT))
			{
				MessageBox.Show("Vui lòng nhập Số điện thoại");
				return;
			}

			if (string.IsNullOrEmpty(TTTKChuTro))
			{
				MessageBox.Show("Vui lòng chọn Tình trạng tài khoản Chủ trọ");
				return;
			}

			
		}


		private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
				using (SqlConnection connection = DatabaseConnection.GetConnection())
				{
                    connection.Open();

                    SqlCommand deleteCmd = new SqlCommand();
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.CommandText = "DELETE FROM QLTK WHERE TENDANGNHAP = @tendangnhap";

                    // Gán giá trị cho tham số truy vấn
                    deleteCmd.Parameters.AddWithValue("@tendangnhap", txtTenDangNhap.Text);

                    deleteCmd.Connection = connection;
                    int kq = deleteCmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");

                        hienthidanhsach();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message);
            }
           
        }

		private void btnSua_Click(object sender, EventArgs e)
		{
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
				string TenDangNhap = txtTenDangNhap.Text.Trim();
				string MatKhau = txtMatKhau.Text.Trim();
				string Quyen = cbbQuyen.SelectedItem?.ToString();
				string CCCDchuTro = txtCCCDChuTro.Text.Trim();
				string HoTenChuTro = txtHoTenChuTro.Text.Trim();
				string DiaChi = txtDiaChi.Text.Trim();
				string SDT = txtSDT.Text.Trim();
				string TTTKChuTro = cbbTTTKChuTro.SelectedItem?.ToString();

				// Kiểm tra null cho các trường cần thiết
				if (string.IsNullOrEmpty(TenDangNhap) || string.IsNullOrEmpty(MatKhau) || string.IsNullOrEmpty(Quyen) ||
					string.IsNullOrEmpty(CCCDchuTro) || string.IsNullOrEmpty(HoTenChuTro) || string.IsNullOrEmpty(DiaChi) ||
					string.IsNullOrEmpty(SDT) || string.IsNullOrEmpty(TTTKChuTro))
				{
					MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
					return;
				}

				// Kiểm tra CCCD chủ trọ là số
				if (!long.TryParse(CCCDchuTro, out long cccdChuTro))
				{
					MessageBox.Show("CCCD Chủ trọ phải là một số");
					return;
				}

				// Kiểm tra giới hạn ký tự cho Họ tên chủ trọ và Địa chỉ
				if (HoTenChuTro.Length > 255)
				{
					MessageBox.Show("Họ tên chủ trọ không được vượt quá 255 ký tự");
					return;
				}

				if (DiaChi.Length > 255)
				{
					MessageBox.Show("Địa chỉ không được vượt quá 255 ký tự");
					return;
				}

				// Kiểm tra số điện thoại là số
				if (!int.TryParse(SDT, out int sdt))
				{
					MessageBox.Show("Số điện thoại phải là một số");
					return;
				}

				connection.Open();
/*
				// Kiểm tra tồn tại của TENDANGNHAP
				string checkQuery = "SELECT COUNT(*) FROM QLTK WHERE TENDANGNHAP = @TenDangNhap";
				SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
				checkCmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
				int existingCount = (int)checkCmd.ExecuteScalar();

				if (existingCount > 0)
				{
					MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác");
					return;
				}

				// Kiểm tra tồn tại của CCCDCHUTRO
				string checkCCCDQuery = "SELECT COUNT(*) FROM QLTK WHERE CCCDCHUTRO = @CCCDchuTro";
				SqlCommand checkCCCDCmd = new SqlCommand(checkCCCDQuery, connection);
				checkCCCDCmd.Parameters.AddWithValue("@CCCDchuTro", CCCDchuTro);
				int existingCCCDCount = (int)checkCCCDCmd.ExecuteScalar();

				if (existingCCCDCount > 0)
				{
					MessageBox.Show("CCCD đã tồn tại. Vui lòng chọn CCCD khác");
					return;
				}*/

				string query = "UPDATE QLTK SET MATKHAU = @matkhau, QUYEN = @quyen, CCCDCHUTRO = @cccd, HOTENCHUTRO = @hoten, DIACHI = @diachi, SDT = @sdt, TTTKCHUTRO = @TTTKChuTro WHERE TENDANGNHAP = @tendangnhap";

				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@matkhau", MatKhau);
				command.Parameters.AddWithValue("@quyen", Quyen);
				command.Parameters.AddWithValue("@cccd", CCCDchuTro);
				command.Parameters.AddWithValue("@hoten", HoTenChuTro);
				command.Parameters.AddWithValue("@diachi", DiaChi);
				command.Parameters.AddWithValue("@sdt", SDT);
				command.Parameters.AddWithValue("@TTTKChuTro", TTTKChuTro);
				command.Parameters.AddWithValue("@tendangnhap", TenDangNhap);

				int rowsAffected = command.ExecuteNonQuery();
				if (rowsAffected > 0)
				{
					MessageBox.Show("Cập nhật thành công!");
					hienthidanhsach();
				}
				else
				{
					MessageBox.Show("Không có thông tin để sửa!");
				}
			}
		}


		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgQuanLiChuTro.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["TENDANGNHAP"].Value.ToString();
                txtMatKhau.Text = row.Cells["MATKHAU"].Value.ToString();
                cbbQuyen.Text = row.Cells["Quyen"].Value.ToString();
                txtCCCDChuTro.Text = row.Cells["CCCDCHUTRO"].Value.ToString();
                txtHoTenChuTro.Text = row.Cells["HOTENCHUTRO"].Value.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                cbbTTTKChuTro.Text = row.Cells["TTTKCHUTRO"].Value.ToString() ;
            }
        }

        private void btnQuanLiThongTinNhaTro_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuanLiNhaTro_Click(object sender, EventArgs e)
        {
            QuanLiThongTinNhaTro ql = new QuanLiThongTinNhaTro();
            ql.Show();
        }

        private void cbbTTTKKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
