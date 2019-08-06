using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Sqlite_Demo
{
    public partial class Form1 : Form
    {
        SQLiteConnection _con = new SQLiteConnection();
        public void createConection()
        {
            string _strConnect = "Data Source=MyDatabase.sqlite;Version=3;";
            _con.ConnectionString = _strConnect;
            _con.Open();
        }

        public void closeConnection()
        {
            _con.Close();
        }

        public void createTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS tbl_students ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, fullname nvarchar(50), birthday varchar(15), email varchar(30), address nvarchar(100), phone varchar(11))";
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //createTable();
            loadDataToGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtFullname.Clear();
            txtBirthday.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtFullname.Focus();
        }
        public  DataSet loadData()
        {
            DataSet ds = new DataSet();
            createConection();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, fullname as [Full Name], email as [Email], address as [Address], phone as [Phone], birthday as [Birthday] from tbl_students", _con);

            da.Fill(ds);
            closeConnection();
            return ds;
        }

        public void loadDataToGrid()
        {
            DataSet ds = loadData();
            gvDataStudent.DataSource = ds.Tables[0];
            txtID.DataBindings.Clear();
            txtFullname.DataBindings.Clear();
            txtBirthday.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtID.DataBindings.Add("text", ds.Tables[0], "id");
            txtFullname.DataBindings.Add("text", ds.Tables[0], "Full name");
            txtBirthday.DataBindings.Add("text", ds.Tables[0], "Birthday");
            txtEmail.DataBindings.Add("text", ds.Tables[0], "Email");
            txtAddress.DataBindings.Add("text", ds.Tables[0], "Address");
            txtPhone.DataBindings.Add("text", ds.Tables[0], "Phone");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text;
            string birthday = txtBirthday.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            string strInsert = string.Format("INSERT INTO tbl_students(fullname, birthday, email, address, phone) VALUES('{0}','{1}','{2}','{3}','{4}')", fullname, birthday, email, address, phone);

            createConection();
            SQLiteCommand cmd = new SQLiteCommand(strInsert, _con);
            cmd.ExecuteNonQuery();
            closeConnection();

            // load data
            loadDataToGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string fullname = txtFullname.Text;          
            string birthday = txtBirthday.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            string strInsert = string.Format("UPDATE tbl_students set fullname='{0}', birthday='{1}', email='{2}', address='{3}', phone='{4}' where id='{5}'", fullname, birthday, email, address, phone, id);

            createConection();
            SQLiteCommand cmd = new SQLiteCommand(strInsert, _con);
            cmd.ExecuteNonQuery();
            closeConnection();

            // load data
            loadDataToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;           

            string strInsert = string.Format("DELETE FROM tbl_students where id='{0}'", id);

            createConection();
            SQLiteCommand cmd = new SQLiteCommand(strInsert, _con);
            cmd.ExecuteNonQuery();
            closeConnection();

            // load data
            loadDataToGrid();
        }
    }
}
