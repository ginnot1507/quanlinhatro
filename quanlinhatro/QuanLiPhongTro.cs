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

namespace quanlinhatro
{
	public partial class QuanLiPhongTro : Form
	{
		string strCon = @"Data Source=MSI\MAYCUATAI;Initial Catalog=QLNT;Persist Security Info=True;User ID=sa;Password=123456";
		SqlConnection sqlCon;
		public QuanLiPhongTro()
		{
			InitializeComponent();

			// Thêm các giá trị vào ComboBox Diện tích
			cboDienTich.Items.Add("20 m2");
			// Thêm các giá trị khác tương ứng

			// Thêm các giá trị vào ComboBox Trạng thái
			cboTrangThai.Items.Add("Đang trống");
			cboTrangThai.Items.Add("Đã thuê");
			// Thêm các giá trị khác tương ứng

			// Thêm các giá trị vào ComboBox Giá
			cboGia.Items.Add("1.500.000 đồng");
			cboGia.Items.Add("2.000.000 đồng");
			// Thêm các giá trị khác tương ứng

			// Thêm các giá trị vào ComboBox Số tầng
			cboSoTang.Items.Add("1");
			cboSoTang.Items.Add("2");
			cboDienTich.DropDownStyle = ComboBoxStyle.DropDownList;
			cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
			cboGia.DropDownStyle = ComboBoxStyle.DropDownList;

			// Kiểm tra giá trị mặc định của ComboBox Số tầng để đặt giá trị mặc định của ComboBox Giá
			if (cboSoTang.SelectedItem != null)
			{
				string selectedSoTang = cboSoTang.SelectedItem.ToString();
				if (selectedSoTang == "1")
				{
					cboGia.SelectedIndex = cboGia.Items.IndexOf("1.500.000 đồng");
				}
				else if (selectedSoTang == "2")
				{
					cboGia.SelectedIndex = cboGia.Items.IndexOf("2.000.000 đồng");
				}
			}
		}

		private void QuanLiPhongTro_Load(object sender, EventArgs e)
		{
			hienthidanhsach();
		}
		private void hienthidanhsach()
		{
			using (SqlConnection connection = new SqlConnection(strCon))
			{
				connection.Open();

				string query = "select *from PHONGTHUE";
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);

				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);

				dataGridView1.DataSource = dataTable;
			}
		}
		private void kiemtracn()
		{
			if (sqlCon == null)
			{
				sqlCon = new SqlConnection(strCon);
			}
			if (sqlCon.State == System.Data.ConnectionState.Closed)
			{
				sqlCon.Open();
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{

			string soPhong = txtSoPhong.Text.Trim();
			string dienTich = cboDienTich.SelectedItem?.ToString();
			string trangThai = cboTrangThai.SelectedItem?.ToString();
			string gia = cboGia.SelectedItem?.ToString();
			string soTang = cboSoTang.SelectedItem?.ToString();
			string SoCCCD = txtSoCCCD.Text.Trim();
			if (string.IsNullOrWhiteSpace(soPhong) || string.IsNullOrWhiteSpace(dienTich) ||
		string.IsNullOrWhiteSpace(trangThai) || string.IsNullOrWhiteSpace(gia) ||
		string.IsNullOrWhiteSpace(soTang) || string.IsNullOrWhiteSpace(SoCCCD))
			{
				MessageBox.Show("Vui lòng nhập thông tin.");
				return; 
			}
			if (sqlCon == null)
			{
				sqlCon = new SqlConnection(strCon);
			}
			if (sqlCon.State == System.Data.ConnectionState.Closed)
			{
				sqlCon.Open();
			}
			// Kiểm tra TENDANGNHAP không được trùng nhau
			using (SqlConnection connection = new SqlConnection(strCon))
			{
				connection.Open();
				// Kiểm tra tồn tại của SOPHONG trong PHONGTHUE
				string checkRentQuery = "SELECT COUNT(*) FROM PHONGTHUE WHERE SOPHONG = @SoPhong";
				SqlCommand checkRentCmd = new SqlCommand(checkRentQuery, connection);
				checkRentCmd.Parameters.AddWithValue("@SoPhong", soPhong);
				int existingRentCount = (int)checkRentCmd.ExecuteScalar();

				if (existingRentCount > 0)
				{
					MessageBox.Show("Phòng đã có người thuê. Vui lòng chọn phòng khác.");
					return;
				}
				// Kiểm tra tồn tại của SOPHONG
				string checkQuery = "SELECT COUNT(*) FROM PHONGTHUE WHERE SOPHONG = @SoPhong";
				SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
				checkCmd.Parameters.AddWithValue("@SoPhong", soPhong);
				int existingCount = (int)checkCmd.ExecuteScalar();

				if (existingCount > 0)
				{
					MessageBox.Show("Không thể trùng số phòng. Vui lòng chọn lại");
					return;
				}

				// Kiểm tra tồn tại của SOCCCD
				string checkCCCDQuery = "SELECT COUNT(*) FROM PHONGTHUE WHERE SOCCCD = @SoCCCD";
				SqlCommand checkCCCDCmd = new SqlCommand(checkCCCDQuery, connection);
				checkCCCDCmd.Parameters.AddWithValue("@SoCCCD", SoCCCD);
				int existingCCCDCount = (int)checkCCCDCmd.ExecuteScalar();

				if (existingCCCDCount > 0)
				{
					MessageBox.Show("Số CCCD bị trùng. Vui lòng nhập lại.");
					return;
				}

				// Kiểm tra tồn tại của SOCCCD trong KHACHTHUE

				string checkRegisteredCCCDQuery = "SELECT COUNT(*) FROM KHACHTHUE WHERE SOCCCD = @SoCCCD";
				SqlCommand checkRegisteredCCCDCmd = new SqlCommand(checkRegisteredCCCDQuery, connection);
				checkRegisteredCCCDCmd.Parameters.AddWithValue("@SoCCCD", SoCCCD);
				int registeredCCCDCount = (int)checkRegisteredCCCDCmd.ExecuteScalar();

				if (registeredCCCDCount == 0)
				{
					MessageBox.Show("Số CCCD chưa được đăng ký. Vui lòng đăng ký trước khi thêm phòng thuê.");
					return;
				}

				// Tiếp tục thêm dữ liệu vào bảng PHONGTHUE
				SqlCommand sqlCmd = new SqlCommand();
				sqlCmd.CommandType = CommandType.Text;
				sqlCmd.CommandText = "INSERT INTO PHONGTHUE VALUES(@SoPhong, @DienTich, @TrangThai, @Gia, @SoTang, @SoCCCD)";
				sqlCmd.Connection = sqlCon;
				sqlCmd.Parameters.AddWithValue("@SoPhong", soPhong);
				sqlCmd.Parameters.AddWithValue("@DienTich", dienTich);
				sqlCmd.Parameters.AddWithValue("@TrangThai", trangThai);
				sqlCmd.Parameters.AddWithValue("@Gia", gia);
				sqlCmd.Parameters.AddWithValue("@SoTang", soTang);
				sqlCmd.Parameters.AddWithValue("@SoCCCD", SoCCCD);

				int kq = sqlCmd.ExecuteNonQuery();
				if (kq > 0)
				{
					MessageBox.Show("Thêm thành công");
					hienthidanhsach();
				}
				else
				{
					MessageBox.Show("Thêm không thành công");
				}
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
				txtSoPhong.Text = row.Cells["SOPHONG"].Value.ToString();
				cboDienTich.SelectedItem = row.Cells["DIENTICH"].Value.ToString();
				cboTrangThai.SelectedItem = row.Cells["TRANGTHAI"].Value.ToString();
				cboGia.SelectedItem = row.Cells["GIA"].Value.ToString();
				cboSoTang.SelectedItem = row.Cells["SOTANG"].Value.ToString();
				txtSoCCCD.Text = row.Cells["SOCCCD"].Value.ToString();
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			//kiểm tra tồn tại.
			if (string.IsNullOrWhiteSpace(cboDienTich.SelectedItem?.ToString()) ||
			 string.IsNullOrWhiteSpace(cboTrangThai.SelectedItem?.ToString()) ||
			 string.IsNullOrWhiteSpace(cboGia.SelectedItem?.ToString()) ||
			string.IsNullOrWhiteSpace(cboSoTang.SelectedItem?.ToString()) ||
			 string.IsNullOrWhiteSpace(txtSoCCCD.Text) ||
			 string.IsNullOrWhiteSpace(txtSoPhong.Text))
			{
				MessageBox.Show("Vui lòng nhập thông tin vào!");
				return;
			}
			using (SqlConnection connection = new SqlConnection(strCon))
			{
				connection.Open();

				string query = "UPDATE PHONGTHUE SET DIENTICH = @DIENTICH, TRANGTHAI = @TRANGTHAI,GIA =@GIA,SOTANG = @SOTANG, SOCCCD = @SOCCCD WHERE SOPHONG = @SOPHONG";

				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@DIENTICH", cboDienTich.SelectedItem.ToString());
				command.Parameters.AddWithValue("@TRANGTHAI", cboTrangThai.SelectedItem.ToString());
				command.Parameters.AddWithValue("@GIA", cboGia.SelectedItem.ToString());
				command.Parameters.AddWithValue("@SOTANG", cboSoTang.SelectedItem.ToString());
				command.Parameters.AddWithValue("@SOCCCD", txtSoCCCD.Text);
				command.Parameters.AddWithValue("@SOPHONG ", txtSoPhong.Text);

				int kq = command.ExecuteNonQuery();
				if (kq > 0)
				{
					MessageBox.Show("Cập nhật thành công!");

					hienthidanhsach();
				}
				else
				{
					MessageBox.Show("Không cập nhật thành công!");
				}
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			using (SqlConnection connection = new SqlConnection(strCon))
			{
				connection.Open();

				SqlCommand deleteCmd = new SqlCommand();
				deleteCmd.CommandType = CommandType.Text;
				deleteCmd.CommandText = "DELETE FROM PHONGTHUE WHERE SOPHONG = @SOPHONG";

				// Gán giá trị cho tham số truy vấn
				deleteCmd.Parameters.AddWithValue("@SOPHONG", txtSoPhong.Text);

				deleteCmd.Connection = connection;
				int kq = deleteCmd.ExecuteNonQuery();
				if (kq > 0)
				{
					MessageBox.Show("Xóa thành công!");

					hienthidanhsach();
				}
				else
				{
					MessageBox.Show("Không xóa thành công!");
				}
			}
		}

		private void cboSoTang_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedSoTang = cboSoTang.SelectedItem.ToString();
			string selectedGia = cboGia.SelectedItem.ToString();

			if (selectedSoTang == "1" && selectedGia == "1.500.000 đồng")
			{
				MessageBox.Show("Giá mặc định các phòng của tầng 1 là 2.000.000 đồng. Vui lòng chọn lại giá.");
			}

			else if (selectedSoTang == "2" && selectedGia == "2.000.000 đồng")
			{
				MessageBox.Show("Giá mặc định của tầng 2 là 1.500.000 đồng. Vui lòng chọn lại giá.");
			}
		}

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand updateCmd = new SqlCommand();
                updateCmd.CommandType = CommandType.Text;
                updateCmd.CommandText = "UPDATE PHONGTHUE\r\nSET TRANGTHAI = NULL, SOCCCD = NULL\r\nWHERE NOT EXISTS (\r\n  SELECT 1\r\n  FROM KHACHTHUE\r\n  WHERE PHONGTHUE.SOPHONG = KHACHTHUE.SOPHONG\r\n    AND PHONGTHUE.SOCCCD = KHACHTHUE.SOCCCD\r\n);";

                updateCmd.Connection = connection;
                int rowsAffected = updateCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thành công");

                    hienthidanhsach();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand updateCmd = new SqlCommand();
                updateCmd.CommandType = CommandType.Text;
				updateCmd.CommandText = "UPDATE PHONGTHUE\r\nSET PHONGTHUE.SOCCCD = KHACHTHUE.SOCCCD,\r\n    PHONGTHUE.TRANGTHAI = N'Đã có người'\r\nFROM PHONGTHUE\r\nJOIN KHACHTHUE ON PHONGTHUE.SOPHONG = KHACHTHUE.SOPHONG;";
                updateCmd.Connection = connection;
                int rowsAffected = updateCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thành công");

                    hienthidanhsach();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật");
                }
            }
        }
    }
}

