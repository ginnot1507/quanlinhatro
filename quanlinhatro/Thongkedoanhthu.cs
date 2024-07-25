using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;




namespace quanlinhatro
{
	public partial class ReportForm : Form
	{

        SqlConnection sqlCon;
        public ReportForm()
		{
			InitializeComponent();
		}

		private void ReportForm_Load(object sender, EventArgs e)
		{
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

            this.reportViewer1.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string thang = cbbThang.Text.Trim();
                string nam = txtNam.Text.Trim();

                // Thực thi câu lệnh SQL
                string query = "SELECT SOPHONG, THANG,NAM, GIA + SUM(TONGTIEN) AS DOANHTHU \r\nFROM HOADON \r\nWHERE THANG = "+thang+" AND NAM = "+nam+"\r\nGROUP BY SOPHONG, THANG,NAM, GIA;";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Thiết lập dữ liệu cho báo cáo
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable); // Thay đổi 'DataSetName' thành tên DataSet của bạn
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Nếu cần, thiết lập các thông tin bổ sung cho báo cáo
                reportViewer1.LocalReport.ReportEmbeddedResource = "quanlinhatro.DoanhThu.rdlc"; // Thay đổi 'YourNamespace' và 'ReportFileName' thành tên đúng của namespace và tên file báo cáo

                // Cập nhật báo cáo
                reportViewer1.RefreshReport();

                // Đóng kết nối
                connection.Close();
            }
        }
    }
}
