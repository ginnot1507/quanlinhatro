using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace quanlinhatro
{
	public static class DatabaseConnection
	{
		private static string connectionString = @"Data Source=MSI\MSI;Initial Catalog=QLNT;Persist Security Info=True;User ID=taikhoan;Password=123456";

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}
	}
}

