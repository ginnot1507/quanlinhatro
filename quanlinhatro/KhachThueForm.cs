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
	public partial class KhachThueForm : Form
	{
		public KhachThueForm()
		{
			InitializeComponent();
		}

		private void KhachThueForm_Load(object sender, EventArgs e)
		{
			hienthi();
			hienthi1();
			cbbGia.Items.Add("1500000");
		}

		private void hienthi()
		{
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
				connection.Open();

				string query = "SELECT * FROM PHONGTHUE";

				SqlCommand command = new SqlCommand(query, connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);

				dtgThongTinPhong.DataSource = dataTable;
			}
		}
		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}
		private void kiemtracn()
		{
			// Không cần phương thức này trong lớp KhachThueForm
		}

		private void btnDangKy_Click(object sender, EventArgs e)
		{
			string soCCCD = txtSoCccd.Text.Trim();
			string ngayBatDau = txtNgayBatDau.Text.Trim();
			string ngayKetThuc = txtNgayKetThuc.Text.Trim();
			string gia = cbbGia.SelectedItem?.ToString();

			if (string.IsNullOrEmpty(soCCCD) || string.IsNullOrEmpty(ngayBatDau) ||
				string.IsNullOrEmpty(ngayKetThuc) || string.IsNullOrEmpty(gia))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
				return;
			}
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    // Kiểm tra giá trị TINHTRANG của phòng
                    string checkQuery = "SELECT TRANGTHAI FROM PHONGTHUE WHERE SOPHONG = @SOPHONG;";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@SOPHONG", txtSoPhong.Text);
                        connection.Open();
                        object tinhTrangValue = checkCommand.ExecuteScalar();

                        if (tinhTrangValue == null || tinhTrangValue == DBNull.Value)
                        {
                            // Cho phép đăng ký vì giá trị TINHTRANG là NULL hoặc rỗng
                            string insertQuery = "INSERT INTO HOPDONG (SOPHONG, HOTENKH, NGAYSINH, SOCCCD, SDT, DIACHI, NGAYBATDAU, NGAYKETTHUC, GIA) " +
                                "VALUES (@SOPHONG, @HOTENKH, CONVERT(DATE, @NGAYSINH, 102), @SOCCCD, @SDT, @DIACHI, CONVERT(DATE, @NGAYBATDAU, 102), CONVERT(DATE, @NGAYKETTHUC, 102), @GIA);";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@SOPHONG", txtSoPhong.Text);
                                insertCommand.Parameters.AddWithValue("@HOTENKH", txtHoTenKH.Text);
                                insertCommand.Parameters.AddWithValue("@NGAYSINH", txtNgaySinh.Text);
                                insertCommand.Parameters.AddWithValue("@SOCCCD", txtSoCccd.Text);
                                insertCommand.Parameters.AddWithValue("@SDT", txtSDT.Text);
                                insertCommand.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                                insertCommand.Parameters.AddWithValue("@NGAYBATDAU", txtNgayBatDau.Text);
                                insertCommand.Parameters.AddWithValue("@NGAYKETTHUC", txtNgayKetThuc.Text);
                                insertCommand.Parameters.AddWithValue("@GIA", cbbGia.SelectedItem.ToString());

                                insertCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Đã lưu thông tin chờ chủ trọ xét duyệt!");
                        }
                        else if (tinhTrangValue.ToString() == "Đã có người")
                        {
                            // Không cho phép đăng ký vì giá trị TINHTRANG là "Đã có người"
                            MessageBox.Show("Phòng đã có người thuê. Không thể đăng ký.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }

        }

        private void hienthi1()
		{
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
				connection.Open();

				string query = "SELECT * FROM THONGTINNHATRO";

				SqlCommand command = new SqlCommand(query, connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);

				dtgThongTinNhaTro.DataSource = dataTable;
			}
		}
	}
}
