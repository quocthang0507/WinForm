using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungTaoFormDonGian
{
	class AccessData
	{
		//Tạo kết nối
		public SqlConnection CreateConnection()
		{
			return new SqlConnection("Data source =(localdb)\\MSSQLLocalDB;Initial Catalog=SinhVien;Integrated Security=True");
		}

		//Trả về bảng
		public DataTable CreateTable(string sql)
		{
			SqlConnection connect = CreateConnection();
			SqlDataAdapter adp = new SqlDataAdapter(sql, connect);
			DataTable dt = new DataTable();
			adp.Fill(dt);
			return dt;
		}

		//Hàm thực hiện lệnh nonquery
		public void ExcuteNonQuery(string sql)
		{
			SqlConnection connect = CreateConnection();
			SqlCommand cmd = new SqlCommand(sql, connect);
			connect.Open();
			cmd.ExecuteNonQuery();
			connect.Close();
			cmd.Dispose();
		}
	}
}
