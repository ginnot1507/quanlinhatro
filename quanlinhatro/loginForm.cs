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
	public partial class loginForm : Form
	{
		
		public loginForm()
		{
			InitializeComponent();
            // them du lieu vao combobox
            comboBoxRole.Items.Add("Admin");
            comboBoxRole.Items.Add("Khachthue");
            comboBoxRole.Items.Add("Chutro");
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
        }
		private void btnLogin_Click(object sender, EventArgs e)
		{

		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.ShowDialog();
		}

		private void btnLogin_Click_1(object sender, EventArgs e)
		{

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string selectedRole = comboBoxRole.SelectedItem?.ToString();

            // Kiểm tra xem đã chọn vai trò hay chưa
            if (!string.IsNullOrEmpty(selectedRole))
            {
                // Kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Truy vấn kiểm tra đăng nhập và lấy quyền và trạng thái tài khoản của người dùng
                    string query = "";
                    string roleColumn = "";
                    string statusColumn = "";

                    if (selectedRole == "Admin")
                    {
                        query = "SELECT QUYEN FROM QLTK WHERE TENDANGNHAP = @Username AND MATKHAU = @Password";
                        roleColumn = "QUYEN";
                    }
                    else if (selectedRole == "Khachthue")
                    {
                        query = "SELECT QUYEN, TTTKKHACHTHUE FROM QLTK WHERE TENDANGNHAP = @Username AND MATKHAU = @Password";
                        roleColumn = "QUYEN";
                        statusColumn = "TTTKKHACHTHUE";
                    }
                    else if (selectedRole == "Chutro")
                    {
                        query = "SELECT QUYEN, TTTKCHUTRO FROM QLTK WHERE TENDANGNHAP = @Username AND MATKHAU = @Password";
                        roleColumn = "QUYEN";
                        statusColumn = "TTTKCHUTRO";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Thực thi truy vấn và kiểm tra quyền và trạng thái tài khoản của người dùng
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Kiểm tra xem cột quyền có giá trị không null
                                if (!reader.IsDBNull(reader.GetOrdinal(roleColumn)))
                                {
                                    string userRole = reader.GetString(reader.GetOrdinal(roleColumn));
                                    string accountStatus = "";
                                    if (!string.IsNullOrEmpty(statusColumn) && !reader.IsDBNull(reader.GetOrdinal(statusColumn)))
                                    {
                                        accountStatus = reader.GetString(reader.GetOrdinal(statusColumn));
                                    }

                                    // Kiểm tra trạng thái tài khoản của người dùng
                                    if (accountStatus == "HetHD")
                                    {
                                        MessageBox.Show("Tài khoản đã bị đình chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return; // Thoát khỏi phương thức hoặc hàm xử lý đăng nhập
                                    }

                                    // Kiểm tra vai trò của người dùng và xử lý tương ứng
                                    if (userRole == selectedRole)
                                    {
                                        MessageBox.Show("Đăng nhập thành công");

                                        // Chuyển form tương ứng dựa trên quyền của người dùng
                                        if (userRole == "Admin")
                                        {
                                            AdminForm adminForm = new AdminForm();
                                            this.Hide();
                                            adminForm.ShowDialog();
                                            this.Close();
                                        }
                                        else if (userRole == "Khachthue")
                                        {
                                            KhachThueForm khachThueForm = new KhachThueForm();
                                            this.Hide();
                                            khachThueForm.ShowDialog();
                                            this.Close();
                                        }
                                        else if (userRole == "Chutro")
                                        {
                                            ChutroForm chutroForm = new ChutroForm();
                                            this.Hide();
                                            chutroForm.ShowDialog();
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vui lòng chọn đúng vai trò", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quyền người dùng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
