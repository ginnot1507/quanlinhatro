using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlinhatro
{
	public partial class ChutroForm : Form
	{
        SqlConnection sqlCon;
        
        public ChutroForm()
		{
			InitializeComponent();
		}

		private void ChutroForm_Load(object sender, EventArgs e)
		{
            hienthidachsach();
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

		private void hienthidachsach()
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "select *from KHACHTHUE ";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgDanhSachKhachThue.DataSource = dataTable;
            }
        }
		private void btnDangxuat_Click(object sender, EventArgs e)
		{
			this.Close();
            loginForm lg = new loginForm();
            lg.ShowDialog();
		}

        private void txtHOTENKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string SoCCCD = txtSoCCCD.Text.Trim();
                string HoTenKH = txtHoTenKH.Text.Trim();
                string NgaySinh = txtNgaySinh.Text.Trim();
                DateTime ngaySinh;

                if (!DateTime.TryParseExact(NgaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng kiểm tra lại định dạng (dd/MM/yyyy)");
                    return;
                }

                string Diachi = txtDiaChi.Text.Trim();
                string SDT = txtSDT.Text.Trim();
                

                if (string.IsNullOrEmpty(SoCCCD) || string.IsNullOrEmpty(HoTenKH) || string.IsNullOrEmpty(NgaySinh) ||
                    string.IsNullOrEmpty(Diachi) || string.IsNullOrEmpty(SDT))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                // Kiểm tra tồn tại của SoCCCD
                string checkQuery = "SELECT COUNT(*) FROM KHACHTHUE WHERE SOCCCD = @SoCCCD";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@SoCCCD", SoCCCD);
                    int existingCount = (int)checkCmd.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        MessageBox.Show("Số CCCD đã tồn tại. Vui lòng chọn lại");
                        return;
                    }
                }

                // Kiểm tra tồn tại của SDT
                string checkSDTQuery = "SELECT COUNT(*) FROM KHACHTHUE WHERE SDT = @SDT";
                using (SqlCommand checkSDTCmd = new SqlCommand(checkSDTQuery, connection))
                {
                    checkSDTCmd.Parameters.AddWithValue("@SDT", SDT);
                    int existingSDTCount = (int)checkSDTCmd.ExecuteScalar();

                    if (existingSDTCount > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng chọn lại.");
                        return;
                    }
                }


                long SoCCCDKH;
                if (!long.TryParse(SoCCCD, out SoCCCDKH))
                {
                    MessageBox.Show("CCCD phải là một số, hoặc kiểm tra lại Số CCCD phải > 8");
                    return;
                }
                else if (SoCCCD.Length < 8)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại Số CCCD phải > 8");
                    return;
                }

                if (HoTenKH.Length > 255)
                {
                    MessageBox.Show("Họ tên khách hàng không được vượt quá 255 ký tự");
                    return;
                }

                if (Diachi.Length > 255)
                {
                    MessageBox.Show("Địa chỉ không được vượt quá 255 ký tự");
                    return;
                }

                int SDTKH;
                if (!int.TryParse(SDT, out SDTKH))
                {
                    MessageBox.Show("Số điện thoại phải là một số");
                    return;
                }

                string insertQuery = "INSERT INTO KHACHTHUE (SOCCCD, HoTenKH, NgaySinh, Diachi, SDT) VALUES (@SoCCCD, @HoTenKH, @NgaySinh, @Diachi, @SDT)";
                using (SqlCommand sqlCmd = new SqlCommand(insertQuery, connection))
                {
                    sqlCmd.Parameters.AddWithValue("@SoCCCD", SoCCCD);
                    sqlCmd.Parameters.AddWithValue("@HoTenKH", HoTenKH);
                    sqlCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    sqlCmd.Parameters.AddWithValue("@Diachi", Diachi);
                    sqlCmd.Parameters.AddWithValue("@SDT", SDT);
                    int kq = sqlCmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        hienthidachsach();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgDanhSachKhachThue.Rows[e.RowIndex];
                
                txtSoCCCD.Text = row.Cells["SOCCCD"].Value.ToString();
                txtHoTenKH.Text = row.Cells["HOTENKH"].Value.ToString();
                DateTime ngaySinh;
                if (DateTime.TryParse(row.Cells["NGAYSINH"].Value.ToString(), out ngaySinh))
                {
                    txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                }
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
               
            }
        }

        private void btnQuanLiThongTinNhaTro_Click(object sender, EventArgs e)
        {
            QuanLiPhongTro qln = new QuanLiPhongTro();
            qln.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtHoTenKH.Text) ||
		    string.IsNullOrWhiteSpace(txtNgaySinh.Text) ||
		    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
		    string.IsNullOrWhiteSpace(txtSDT.Text) ||
		    string.IsNullOrWhiteSpace(txtSoCCCD.Text))
			{
				MessageBox.Show("Vui lòng nhập thông tin vào!");
				return;
			}
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "(UPDATE KHACHTHUE SET HOTENKH = @HoTenKH , NGAYSINH = @NgaySinh, DIACHI = @DiaChi, SDT = @SDT WHERE SOCCCD = @SoCCCD)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HoTenKH", txtHoTenKH.Text);
                command.Parameters.AddWithValue("@NgaySinh",txtNgaySinh.Text);
                command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                command.Parameters.AddWithValue("@SDT", txtSDT.Text);
                command.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    hienthidachsach();
                }
                else
                {
                    MessageBox.Show("Khong cập nhật thành công!");


                }
            }
        }

        private void btnQuanLiHopDong_Click(object sender, EventArgs e)
        {
            QuanLiHopDong qlhd = new QuanLiHopDong();
            qlhd.ShowDialog();
        }

        private void btnQuanLiDichVu_Click(object sender, EventArgs e)
        {
            DichVuDienNuoc dv = new DichVuDienNuoc();
            dv.ShowDialog();
        }

		private void button1_Click(object sender, EventArgs e)
		{
		   ReportForm rp = new ReportForm();
            rp.ShowDialog();
		}


        private void btnXoa_Click(object sender, EventArgs e)
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                SqlCommand deleteCmd = new SqlCommand();
                deleteCmd.CommandType = CommandType.Text;
                deleteCmd.CommandText = "DELETE FROM KHACHTHUE WHERE SOCCCD = @SoCCCD";

                // Gán giá trị cho tham số truy vấn
                deleteCmd.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);

                deleteCmd.Connection = connection;
                int kq = deleteCmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    hienthidachsach();
                }
                else
                {
                    MessageBox.Show("Không xóa thành công!");
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

		private void btnDangXuat_Click_1(object sender, EventArgs e)
		{
			this.Close();
			loginForm lg = new loginForm();
			lg.ShowDialog(); 
		}
	}
}
