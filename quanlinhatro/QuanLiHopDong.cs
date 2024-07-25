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
    public partial class QuanLiHopDong : Form
    {

       
        SqlConnection sqlCon;
        public QuanLiHopDong()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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


		private void QuanLiHopDong_Load(object sender, EventArgs e)
        {
            hienthi();
        }
        private void hienthi()
        {
			using (SqlConnection connection = DatabaseConnection.GetConnection())
			{
                connection.Open();

                string query = "SELECT *from HOPDONG";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgQuanLiHopDong.DataSource = dataTable;
            }
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
			kiemtracn();
			if (dtgQuanLiHopDong.SelectedCells.Count > 0)
			{
				int rowIndex = dtgQuanLiHopDong.SelectedCells[0].RowIndex;
				string maHD = dtgQuanLiHopDong.Rows[rowIndex].Cells["MAHD"].Value.ToString();

				using (SqlConnection connection = DatabaseConnection.GetConnection())
				{
					connection.Open();

					string updateQuery = "UPDATE HOPDONG SET TRANGTHAIHD = N'Chấp nhận' WHERE MAHD = @MaHD";

					SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
					updateCommand.Parameters.AddWithValue("@MaHD", maHD);

					int rowsAffected = updateCommand.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						// kiểm tra số cccd có bị trùng hay không
						string socccdQuery = "SELECT COUNT(*) FROM KHACHTHUE WHERE SOCCCD = (SELECT SOCCCD FROM HOPDONG WHERE MAHD = @MaHD)";
						SqlCommand socccdCommand = new SqlCommand(socccdQuery, connection);
						socccdCommand.Parameters.AddWithValue("@MaHD", maHD);
						int existingRows = Convert.ToInt32(socccdCommand.ExecuteScalar());

						if (existingRows > 0)
						{
							MessageBox.Show("SOCCCD bị trùng!");
						}
						else
						{
							string insertQuery = "INSERT INTO KHACHTHUE (SOPHONG,HOTENKH, NGAYSINH, SOCCCD, SDT, DIACHI, MAHD) " +
								"SELECT SOPHONG,HOTENKH, NGAYSINH, SOCCCD, SDT, DIACHI, MAHD FROM HOPDONG WHERE MAHD = @MaHD";

							SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
							insertCommand.Parameters.AddWithValue("@MaHD", maHD);
							int insertedRows = insertCommand.ExecuteNonQuery();

							if (insertedRows > 0)
							{
								MessageBox.Show("Cập nhật trạng thái và thêm dữ liệu thành công!");
								hienthi();
							}
							else
							{
								MessageBox.Show("Thêm dữ liệu không thành công!");
							}
						}
					}
					else
					{
						MessageBox.Show("Cập nhật trạng thái không thành công!");
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một hàng để cập nhật trạng thái!");
			}

		}

        private void btnDinhChi_Click(object sender, EventArgs e)
        {
            kiemtracn();
            if (dtgQuanLiHopDong.SelectedCells.Count > 0)
            {
                int rowIndex = dtgQuanLiHopDong.SelectedCells[0].RowIndex;
                string maHD = dtgQuanLiHopDong.Rows[rowIndex].Cells["MAHD"].Value.ToString();

				using (SqlConnection connection = DatabaseConnection.GetConnection())
				{
                    connection.Open();

                    string query = "UPDATE HOPDONG SET TRANGTHAIHD = N'Đình Chỉ' WHERE MAHD = @MaHD";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHD", maHD);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật trạng thái thành công!");
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái không thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để cập nhật trạng thái!");
            }
        }

        private void btnChamDut_Click(object sender, EventArgs e)
        {
            kiemtracn();
            if (dtgQuanLiHopDong.SelectedCells.Count > 0)
            {
                int rowIndex = dtgQuanLiHopDong.SelectedCells[0].RowIndex;
                string maHD = dtgQuanLiHopDong.Rows[rowIndex].Cells["MAHD"].Value.ToString();

				using (SqlConnection connection = DatabaseConnection.GetConnection())
				{
                    connection.Open();

                    string query = "UPDATE HOPDONG SET TRANGTHAIHD = N'Chấm Dứt' WHERE MAHD = @MaHD";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHD", maHD);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật trạng thái thành công!");
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái không thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để cập nhật trạng thái!");
            }
        }
    }
}
