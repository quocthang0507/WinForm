using System.Data;
using System.Data.SQLite;

namespace QuanLyBanHang
{
	public class SQLite
	{
		private SQLiteConnection connection = new SQLiteConnection();
		public static string SqlFile = "CSDL.sqlite";
		public static string table = "DonHang";
		public static string column_id = "id";
		//...

		public void CreateConnection()
		{
			string str = "Data Source=" + SqlFile + ";Version=3";
			connection.ConnectionString = str;
			connection.Open();
		}

		public void CloseConnection()
		{
			connection.Close();
		}

		public void CreateTable()
		{
			SQLiteConnection.CreateFile(SqlFile);
			CreateConnection();
			string sql = "CREATE TABLE IF NOT EXISTS " + table + "([" + column_id + "] INTERGER NOT NULL PRIMARY KEY AUTOINCREMENT, )";
			SQLiteCommand command = new SQLiteCommand(sql, connection);
			command.ExecuteNonQuery();
			CloseConnection();
		}

		public void InsertValue()
		{
			CreateConnection();
			string sql = "INSERT INTO " + table + " VALUES ";
			SQLiteCommand command = new SQLiteCommand(sql, connection);
			command.ExecuteNonQuery();
			CloseConnection();
		}

		public void UpdateValue()
		{
			CreateConnection();
			string sql = "UPDATE " + table + " SET ... WHERE " + column_id + " = '0'";
			SQLiteCommand command = new SQLiteCommand(sql, connection);
			command.ExecuteNonQuery();
			CloseConnection();
		}

		public void DeleteValue()
		{
			CreateConnection();
			string sql = "DELETE FROM " + table + " WHERE " + column_id + " = '0'";
			SQLiteCommand command = new SQLiteCommand(sql, connection);
			command.ExecuteNonQuery();
			CloseConnection();
		}

		public DataSet GetValues()
		{
			CreateConnection();
			DataSet dataSet = new DataSet();
			string sql = "SELECT * FROM " + table;
			SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql,connection);
			adapter.Fill(dataSet);
			CloseConnection();
			return dataSet;
		}
	}
}
