using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
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
    public partial class TinhTien : Form
    {
        
        SqlConnection sqlCon;
        public TinhTien()
        {
            InitializeComponent();
        }

        private void TinhTien_Load(object sender, EventArgs e)
        {
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
            // Kết nối đến cơ sở dữ liệu
           

            this.reportViewer1.RefreshReport();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string phong = cbbChonSoPhong.Text.Trim();
                string thang = cbbThang.Text.Trim();
                string nam = txtSoNam.Text.Trim();
                // Thực thi câu lệnh SQL
                string query = "select *from HOADON\r\nwhere SOPHONG = "+phong+" and THANG = "+thang+" and NAM = "+nam+"";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Thiết lập dữ liệu cho báo cáo
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable); // Thay đổi 'DataSetName' thành tên DataSet của bạn
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Nếu cần, thiết lập các thông tin bổ sung cho báo cáo
                reportViewer1.LocalReport.ReportEmbeddedResource = "quanlinhatro.InHD.rdlc"; // Thay đổi 'YourNamespace' và 'ReportFileName' thành tên đúng của namespace và tên file báo cáo

                // Cập nhật báo cáo
                reportViewer1.RefreshReport();

                // Đóng kết nối
                connection.Close();
            }
               
        }
    }
}
