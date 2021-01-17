using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataGridView_ComboBox_CS
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private const string ConnectionString = @"Data Source=DESKTOP-QBRB40K\SQLEXPRESS;Initial Catalog=QuanLyDienNang;Integrated Security = true";
		private void Form1_Load(object sender, EventArgs e)
		{
			//Fetch the data from Database.
			dataGridView1.DataSource = this.GetData("select MaKhachHang, HoVaTen from KhachHang");
			dataGridView1.AllowUserToAddRows = false;

			//Add a ComboBox Column to the DataGridView.
			DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
			comboBoxColumn.HeaderText = "Ten bang gia";
			comboBoxColumn.Width = 100;
			comboBoxColumn.Name = "combobox";
			dataGridView1.Columns.Add(comboBoxColumn);

			//Loop through the DataGridView Rows.
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				//Reference the ComboBoxCell.
				DataGridViewComboBoxCell comboBoxCell = (row.Cells[2] as DataGridViewComboBoxCell);

				//Fetch the Countries from Database.
				DataTable dt = this.GetData("SELECT K.MaKhachHang, B.MaBangGia FROM KhachHang K, BangGia B WHERE K.MaBangGia = B.MaBangGia");

				//Loop through the DataTable Rows.
				foreach (DataRow drow in dt.Rows)
				{
					//Fetch the CustomerId (Primary Key) value.
					string customerId = drow[0].ToString();

					//Add the Country value to the ComboBoxCell.
					comboBoxCell.Items.Add(drow[1]);

					//Compare the value of CustomerId.
					if (row.Cells[0].Value.ToString() == customerId)
					{
						//Once CustomerId is matched, select the Country in ComboBoxCell
						comboBoxCell.Value = drow[1];
					}
				}
			}
		}

		private DataTable GetData(string sql)
		{
			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.CommandType = CommandType.Text;
					using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
					{
						using (DataTable dt = new DataTable())
						{
							sda.Fill(dt);
							return dt;
						}
					}
				}
			}
		}
	}
}
