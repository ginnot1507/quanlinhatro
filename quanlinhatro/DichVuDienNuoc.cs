using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlinhatro
{
    public partial class DichVuDienNuoc : Form
    {

        string strCon = @"Data Source=MSI\MAYCUATAI;Initial Catalog=QLNT;Persist Security Info=True;User ID=sa;Password=123456";
        SqlConnection sqlCon;
        public DichVuDienNuoc()
        {
            InitializeComponent();
        }

        private void DichVuDienNuoc_Load(object sender, EventArgs e)
        {
            hienthidanhsach();
            cbbChonSoPhong.Items.Add("1");
            cbbChonSoPhong.Items.Add("2");
            cbbChonSoPhong.Items.Add("3");
            cbbChonSoPhong.Items.Add("4");
            cbbChonSoPhong.Items.Add("5");
            cbbChonSoPhong.Items.Add("6");
            cbbChonSoPhong.Items.Add("7");
            cbbChonSoPhong.Items.Add("8");
            cbbThang.Items.Add("1");
            cbbThang.Items.Add("2");
            cbbThang.Items.Add("3");
            cbbThang.Items.Add("4");
            cbbThang.Items.Add("5");
            cbbThang.Items.Add("6");
            cbbThang.Items.Add("7");
            cbbThang.Items.Add("8");
            cbbThang.Items.Add("9");
            cbbThang.Items.Add("10");
            cbbThang.Items.Add("11");
            cbbThang.Items.Add("12");
            cbbThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbChonSoPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb1.Items.Add("1");
            cbb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb2.Items.Add("2");
            cbb2.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb3.Items.Add("3");
            cbb3.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb4.Items.Add("4");
            cbb4.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb5.Items.Add("5");
            cbb5.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSLWifi.Items.Add("0");
            cbbSLWifi.Items.Add("1");
            cbbSLWifi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSLRac.Items.Add("0");
            cbbSLRac.Items.Add("1");
            cbbSLRac.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSLAnNinh.Items.Add("0");
            cbbSLAnNinh.Items.Add("1");
            cbbSLAnNinh.DropDownStyle = ComboBoxStyle.DropDownList;
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
       /* private void hiendichvu()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT *FROM TIENTHANG";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgGiaDV.DataSource = dataTable;
            }
        }
*/
        private void hienthidanhsach()
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "SELECT *FROM DICHVU";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgDanhSachDichVu.DataSource = dataTable;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kiemtracn();
            string MaDV = txtMaDV.Text.Trim();
            string TenDV = txtTenDV.Text.Trim();
            string DonViTinh = txtDonVi.Text.Trim();
            string DonGia = txtDonGia.Text.Trim();
			if (string.IsNullOrEmpty(MaDV) || string.IsNullOrEmpty(TenDV) ||
		string.IsNullOrEmpty(DonViTinh) || string.IsNullOrEmpty(DonGia))
			{
				MessageBox.Show("Vui lòng nhập thông tin vào.");
				return;
			}
			SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "INSERT INTO DICVU (TENDANGNHAP, MATKHAU,QUYEN,TTTKKHACHTHUE) VALUES (" + MaDV + ", '" +TenDV + "','" + DonViTinh + "'," + DonGia + ")";
            insertCmd.Connection = sqlCon;
            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Them thanh cong");
                hienthidanhsach();
            }
            else
            {
                MessageBox.Show("khong dc");
            }
        }

        private void dtgDanhSachDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgDanhSachDichVu.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["MADV"].Value.ToString();
                txtTenDV.Text = row.Cells["TENDV"].Value.ToString();
                txtDonVi.Text = row.Cells["DONVI"].Value.ToString();
                txtDonGia.Text = row.Cells["DONGIA"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "UPDATE DICHVU SET TENDV = @TenDV, DONVI = @DonVi, DONGIA = @DonGia WHERE MADV = @MaDV";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDV", txtTenDV.Text);
                command.Parameters.AddWithValue("@DonVi", txtDonVi.Text);
                command.Parameters.AddWithValue("@DonGia", txtDonGia.Text);
                command.Parameters.AddWithValue("@MaDV", txtMaDV.Text);
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");

                    hienthidanhsach();
                }
                else
                {
                    MessageBox.Show("Khong cập nhật thành công!");


                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                SqlCommand deleteCmd = new SqlCommand();
                deleteCmd.CommandType = CommandType.Text;
                deleteCmd.CommandText = "DELETE FROM DICHVU WHERE MADV = @MaDV";

                // Gán giá trị cho tham số truy vấn
                deleteCmd.Parameters.AddWithValue("@MaDV", txtMaDV.Text);

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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          TinhTien tt = new TinhTien();
            tt.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            kiemtracn();
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "INSERT INTO HOADON (HOTENKH, SOPHONG, SOCCCD, THANG, MADV, DONGIA, SOLUONG,NAM, GIA, MATT, TONGTIEN)\r\nSELECT\r\n    KHACHTHUE.HOTENKH,\r\n    TIENTHANG.SOPHONG,\r\n    KHACHTHUE.SOCCCD,\r\n    TIENTHANG.THANG,\r\n    TIENTHANG.MADV,\r\n    TIENTHANG.DONGIA,\r\n    TIENTHANG.SOLUONG,\r\n\tTIENTHANG.NAM,\r\n    PHONGTHUE.GIA,\r\n    TIENTHANG.MATT,\r\n    (TIENTHANG.DONGIA * TIENTHANG.SOLUONG) AS TONGTIEN\r\nFROM\r\n    KHACHTHUE\r\n    JOIN TIENTHANG ON KHACHTHUE.SOCCCD = TIENTHANG.SOCCCD\r\n    JOIN PHONGTHUE ON TIENTHANG.SOPHONG = PHONGTHUE.SOPHONG;\r\n";
            insertCmd.Connection = sqlCon;
            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật thông tin vào hóa đơn thành công!");

            }
            else
            {
                MessageBox.Show("khong dc");
            }
        }

		private void btnThemDV_Click(object sender, EventArgs e)
		{
            kiemtracn();

            string SoPhong = cbbChonSoPhong.Text.Trim();
            string thang = cbbThang.Text.Trim();
            string MaDV1 = cbb1.Text.Trim();
            string MaDV2 = cbb2.Text.Trim();
            string MaDV3 = cbb3.Text.Trim();
            string MaDV4 = cbb4.Text.Trim();
            string MaDV5 = cbb5.Text.Trim();
            string SoLuong1 = txtSoLuong1.Text.Trim();
            string SoLuong2 = txtSoLuong2.Text.Trim();
            string SoLuong3 = cbbSLWifi.Text.Trim();
            string SoLuong4 = cbbSLRac.Text.Trim();
            string SoLuong5 = cbbSLAnNinh.Text.Trim();
            string nam = txtNam.Text.Trim();

            if (string.IsNullOrEmpty(SoPhong) || string.IsNullOrEmpty(thang) ||
                string.IsNullOrEmpty(MaDV1) || string.IsNullOrEmpty(MaDV2) ||
                string.IsNullOrEmpty(MaDV3) || string.IsNullOrEmpty(MaDV4) ||
                string.IsNullOrEmpty(MaDV5) || string.IsNullOrEmpty(SoLuong1) ||
                string.IsNullOrEmpty(SoLuong2) || string.IsNullOrEmpty(SoLuong3) ||
                string.IsNullOrEmpty(SoLuong4) || string.IsNullOrEmpty(SoLuong5) ||
                string.IsNullOrEmpty(nam))
            {
                MessageBox.Show("Vui lòng nhập thông tin vào.");
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                // Kiểm tra giá trị TRANGTHAI trong PHONGTHUE
                string checkQuery = "SELECT TRANGTHAI FROM PHONGTHUE WHERE SOPHONG = @SoPhong";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@SoPhong", SoPhong);
                string trangThai = checkCommand.ExecuteScalar()?.ToString();

                if (trangThai == null)
                {
                    MessageBox.Show("TRANGTHAI không được để trống!");
                    return;
                }
                else if (trangThai == "Đã có người")
                {
                    // Thực hiện thêm dịch vụ vào bảng hoặc các hành động khác
                    string insertQuery = "INSERT INTO TIENTHANG (SOPHONG, MADV, SOLUONG, THANG, NAM) VALUES " +
                        "(@SoPhong, @MaDV1, @SoLuong1, @Thang, @Nam)," +
                        "(@SoPhong, @MaDV2, @SoLuong2, @Thang, @Nam)," +
                        "(@SoPhong, @MaDV3, @SoLuong3, @Thang, @Nam)," +
                        "(@SoPhong, @MaDV4, @SoLuong4, @Thang, @Nam)," +
                        "(@SoPhong, @MaDV5, @SoLuong5, @Thang, @Nam)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@SoPhong", SoPhong);
                    insertCommand.Parameters.AddWithValue("@MaDV1", MaDV1);
                    insertCommand.Parameters.AddWithValue("@SoLuong1", SoLuong1);
                    insertCommand.Parameters.AddWithValue("@MaDV2", MaDV2);
                    insertCommand.Parameters.AddWithValue("@SoLuong2", SoLuong2);
                    insertCommand.Parameters.AddWithValue("@MaDV3", MaDV3);
                    insertCommand.Parameters.AddWithValue("@SoLuong3", SoLuong3);
                    insertCommand.Parameters.AddWithValue("@MaDV4", MaDV4);
                    insertCommand.Parameters.AddWithValue("@SoLuong4", SoLuong4);
                    insertCommand.Parameters.AddWithValue("@MaDV5", MaDV5);
                    insertCommand.Parameters.AddWithValue("@SoLuong5", SoLuong5);
                    insertCommand.Parameters.AddWithValue("@Thang", thang);
                    insertCommand.Parameters.AddWithValue("@Nam", nam);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu không thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Không thể thêm dịch vụ với TRANGTHAI hiện tại!");
                    return;
                }
            }
        }


        private void btnTong_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            kiemtracn();
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "UPDATE TIENTHANG\r\nSET TIENTHANG.DONGIA = DICHVU.DONGIA\r\nFROM TIENTHANG\r\nJOIN DICHVU ON TIENTHANG.MADV = DICHVU.MADV;";
            insertCmd.Connection = sqlCon;
            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Câp nhật đơn giá thành công");

            }
            else
            {
                MessageBox.Show("khong dc");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kiemtracn();
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "UPDATE TIENTHANG\r\nSET TONGTIEN = DONGIA*SOLUONG";
            insertCmd.Connection = sqlCon;
            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Tính tiền dịch vụ theo số lượng thành công");

            }
            else
            {
                MessageBox.Show("khong dc");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kiemtracn();
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "delete HOADON";
            insertCmd.Connection = sqlCon;
            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Reset thành công!");

            }
            else
            {
                MessageBox.Show("khong dc");
            }
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            kiemtracn();
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "UPDATE TIENTHANG\r\nSET TIENTHANG.SOCCCD = PHONGTHUE.SOCCCD\r\nFROM TIENTHANG\r\nJOIN PHONGTHUE ON TIENTHANG.SOPHONG = PHONGTHUE.SOPHONG;";
            insertCmd.Connection = sqlCon;
            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật thành công mời in hóa đơnn!");

            }
            else
            {
                MessageBox.Show("khong dc");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kiemtracn();
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "delete TIENTHANG";
            insertCmd.Connection = sqlCon;
            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Reset thành công!");

            }
            else
            {
                MessageBox.Show("khong dc");
            }
        }
    }
}
