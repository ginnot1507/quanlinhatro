using Microsoft.Reporting.WinForms;
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
    public partial class HOADON : Form
    {
        
        public HOADON()
        {
            InitializeComponent();
            
        }

        private void HOADON_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT HOADON.MAHOADON, HOADON.HOTENKH, HOADON.SOPHONG, HOADON.HOTENCHUTRO, HOADON.THANG,\r\n       TIENTHANG.MADV, TIENTHANG.SOLUONG, DICHVU.DONGIA, PHONGTHUE.GIA\r\nFROM HOADON\r\nJOIN TIENTHANG ON HOADON.SOPHONG = TIENTHANG.SOPHONG AND HOADON.THANG = TIENTHANG.THANG\r\nJOIN PHONGTHUE ON HOADON.SOPHONG = PHONGTHUE.SOPHONG\r\nJOIN DICHVU ON TIENTHANG.MADV = DICHVU.MADV;";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
    }
}
