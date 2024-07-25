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
    public partial class QuanLiThongTinNhaTro : Form
    {
        string strCon = @"Data Source=MSI\MAYCUATAI;Initial Catalog=QLNT;Persist Security Info=True;User ID=sa;Password=123456";
        SqlConnection sqlCon;
        public QuanLiThongTinNhaTro()
        {
            InitializeComponent();
        }

        private void QuanLiThongTinNhaTro_Load(object sender, EventArgs e)
        {
            hienthidanhsach();
        }
        private void hienthidanhsach()
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "select *from THONGTINNHATRO";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgThongTinNhaTro.DataSource = dataTable;
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
            kiemtracn();
            string MaNhaTro = txtMaNhaTro.Text.Trim();
            string DiaChi = txtDiaChi.Text.Trim();
            string SoGiayPhepKinhDoanh = txtSoGiayPhepKinhDoanh.Text.Trim();
            string DienTich = txtDienTich.Text.Trim();
            string SoLuongPhong = txtSoLuongPhong.Text.Trim();
            string CCCDChuTro = txtCCCDChuTro.Text.Trim();
            if (string.IsNullOrEmpty(MaNhaTro) || string.IsNullOrEmpty(DiaChi) || string.IsNullOrEmpty(SoGiayPhepKinhDoanh) ||
               string.IsNullOrEmpty(DienTich) || string.IsNullOrEmpty(SoLuongPhong) || string.IsNullOrEmpty(CCCDChuTro))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                // Kiểm tra tồn tại của TENDANGNHAP
                string checkQuery = "SELECT COUNT(*) FROM THONGTINNHATRO WHERE MANHATRO = @MANHATRO";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@MANHATRO",MaNhaTro);
                int existingCount = (int)checkCmd.ExecuteScalar();

                if (existingCount > 0)
                {
                    MessageBox.Show("Mã phòng tồn tại. Vui lòng điền mã  khác");
                    return; 
                }
            }
            long dienTich;
            if (!long.TryParse(DienTich, out dienTich))
            {
                MessageBox.Show("Diện tích phải là một số");
                return;
            }

            long CCCDchutro;
            if (!long.TryParse(CCCDChuTro, out CCCDchutro))
            {
                MessageBox.Show("CCCD phải là một số");
                return;
            }

            if (DiaChi.Length > 255)
            {
                MessageBox.Show("Địa chỉ không được vượt quá 255 ký tự");
                return;
            }
            int slp ;
            if (!int.TryParse(SoLuongPhong, out slp))
            {
                MessageBox.Show("Số phòng phải là một số");
                return;
            }
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandType = CommandType.Text;
            insertCmd.CommandText = "INSERT INTO THONGTINNHATRO VALUES (" + MaNhaTro + ", '" + DiaChi + "', '" +SoGiayPhepKinhDoanh + "', " + DienTich + ", " + SoLuongPhong + "," + CCCDChuTro + ")";


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgThongTinNhaTro.Rows[e.RowIndex];
                txtMaNhaTro.Text = row.Cells["MANHATRO"].Value.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                txtSoGiayPhepKinhDoanh.Text = row.Cells["SOGIAYPHEPKINHDOANH"].Value.ToString();
                txtDienTich.Text = row.Cells["TONGDIENTICH"].Value.ToString();
                txtSoLuongPhong.Text = row.Cells["SOLUONGPHONG"].Value.ToString();
                txtCCCDChuTro.Text = row.Cells["CCCDCHUTRO"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "UPDATE THONGTINNHATRO SET DIACHI = @DIACHI, SOGIAYPHEPKINHDOANH = @SOGIAYPHEPKINHDOANH,TONGDIENTICH =@TONGDIENTICH,SOLUONGPHONG = @SOLUONGPHONG, CCCDCHUTRO = @CCCDCHUTRO WHERE MANHATRO = @MANHATRO ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                command.Parameters.AddWithValue("@SOGIAYPHEPKINHDOANH", txtSoGiayPhepKinhDoanh.Text);
                command.Parameters.AddWithValue("@TONGDIENTICH", txtDienTich.Text);
                command.Parameters.AddWithValue("@SOLUONGPHONG", txtSoLuongPhong.Text);
                command.Parameters.AddWithValue("@CCCDCHUTRO", txtCCCDChuTro.Text);
                command.Parameters.AddWithValue("@MANHATRO ", txtMaNhaTro.Text);

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
                deleteCmd.CommandText = "DELETE FROM THONGTINNHATRO   WHERE MANHATRO = @MANHATRO";

                // Gán giá trị cho tham số truy vấn
                deleteCmd.Parameters.AddWithValue("@MANHATRO", txtMaNhaTro.Text);

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

        private void btnCCCDchutro_Click(object sender, EventArgs e)
        {
            kiemtracn();
                SqlCommand insertCmd = new SqlCommand();
                insertCmd.CommandType = CommandType.Text;
                insertCmd.CommandText = "UPDATE THONGTINNHATRO\r\nSET THONGTINNHATRO.CCCDCHUTRO = CHUTRO.CCCDCHUTRO\r\nFROM THONGTINNHATRO\r\nJOIN CHUTRO ON THONGTINNHATRO.CCCDCHUTRO = CHUTRO.CCCDCHUTRO";
                insertCmd.Connection = sqlCon;
                int rowsAffected = insertCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cap nhat thanh cong");
                    hienthidanhsach();
                }
                else
                {
                    MessageBox.Show("khong dc");
                }
            
        }
    }
}
