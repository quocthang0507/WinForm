using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EntityFramework_Example
{
	public partial class Form1 : Form
	{
		Test01Entities database = new Test01Entities();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			btn_View.PerformClick();
			addDataBinding();
		}

		void addDataBinding()
		{
			tbx_ID.DataBindings.Add(new Binding("Text", dgvData.DataSource, "ID", true, DataSourceUpdateMode.Never));
			tbx_Name.DataBindings.Add(new Binding("Text", dgvData.DataSource, "Name", true, DataSourceUpdateMode.Never));
			tbx_Class.DataBindings.Add(new Binding("Text", dgvData.DataSource, "classID", true, DataSourceUpdateMode.Never));
		}

		private void btn_Add_Click(object sender, EventArgs e)
		{
			Student newStudent = new Student { ID = tbx_ID.Text, Name = tbx_Name.Text, classID = tbx_Class.Text };
			database.Student.Add(newStudent);
			database.SaveChanges();
			btn_View.PerformClick();
		}

		private void btn_Modify_Click(object sender, EventArgs e)
		{
			Student student = database.Student.Where(s => s.ID == tbx_ID.Text).SingleOrDefault();
			student.Name = tbx_Name.Text;
			student.classID = tbx_Class.Text;
			database.SaveChanges();
			btn_View.PerformClick();
		}

		private void btn_Delete_Click(object sender, EventArgs e)
		{
			Student deletedStudent = database.Student.Where(s => s.ID == tbx_ID.Text).SingleOrDefault();
			database.Student.Remove(deletedStudent);
			database.SaveChanges();
			btn_View.PerformClick();
		}

		private void btn_ViewByClass_Click(object sender, EventArgs e)
		{
			dgvData.DataSource = database.Student.Where(s => s.classID == tbx_Class.Text).ToList();
		}

		private void btn_View_Click(object sender, EventArgs e)
		{
			dgvData.DataSource = database.Student.ToList();
			dgvData.Columns[dgvData.ColumnCount - 1].Visible = false;
		}
	}
}
