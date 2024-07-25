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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string currentPassword = txtPassWord.Text.Trim();
            string newPassword = txtNewPassWord.Text.Trim();
            string confirmNewPassword = txtConfirmPassWord.Text.Trim();

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "UPDATE QLTK SET MATKHAU = @NewPassword WHERE TENDANGNHAP = @Username AND MATKHAU = @CurrentPassword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@CurrentPassword", currentPassword);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
