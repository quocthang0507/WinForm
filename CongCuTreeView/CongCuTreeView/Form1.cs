using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CongCuTreeView
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			treeView.ImageList = ilslcons;
			////////////////////////
			TreeNode goc = treeView.Nodes.Add("Kí tự đặc biệt"); //Khởi tạo nút 'goc' đầu tiên trong cây thư mục
			//Lấy hình cho nút gốc trước và sau hi nhấn nút mở rộng hay thu gọn
			goc.ImageIndex = 2;
			goc.SelectedImageIndex = 2;
			//Add các node con vào node cha với các kí hiệu +, -, *, /
			TreeNode node1 = goc.Nodes.Add("+");
			TreeNode node2 = goc.Nodes.Add("-");
			TreeNode node3 = goc.Nodes.Add("*");
			TreeNode node4 = goc.Nodes.Add("/");
			//Hiển thị hình mặc định cho các nút con
			node1.ImageIndex = 1;
			node2.ImageIndex = 1;
			node3.ImageIndex = 1;
			node4.ImageIndex = 1;
			//Hiển thị hình khi nhấn nút mở rộng hoặc thu gọn cho các nút con
			node1.SelectedImageIndex = 0;
			node2.SelectedImageIndex = 0;
			node3.SelectedImageIndex = 0;
			node4.SelectedImageIndex = 0;
			////////////////////////
			TreeNode gockitu = treeView.Nodes.Add("Kí tự");
			gockitu.SelectedImageIndex = 2;
			gockitu.ImageIndex = 2;
			for (char i='a';i<='z';i++)
			{
				TreeNode kitu = gockitu.Nodes.Add("" + i);
				kitu.ImageIndex = 1;
				kitu.SelectedImageIndex = 0;
			////////////////////////
			}
			TreeNode so = treeView.Nodes.Add("Dãy số");
			so.ImageIndex = 2;
			so.SelectedImageIndex = 2;
			for (int i=0;i<10;i++)
			{
				TreeNode dayso = so.Nodes.Add(i.ToString());
				dayso.ImageIndex = 0;
				dayso.SelectedImageIndex = 1;
			}
			////////////////////////
			TreeNode hinhAnh = treeView.Nodes.Add("Hình ảnh");
			hinhAnh.ImageIndex = 2;
			hinhAnh.SelectedImageIndex = 2;
			TreeNode anhChup = hinhAnh.Nodes.Add("Ảnh chụp");
			TreeNode anhVe = hinhAnh.Nodes.Add("Ảnh vẽ");
			TreeNode anhDoHoa = hinhAnh.Nodes.Add("Ảnh đồ hoạ");
			anhChup.ImageIndex = anhChup.SelectedImageIndex = 2;
			anhVe.ImageIndex = anhVe.SelectedImageIndex = 2;
			anhDoHoa.ImageIndex = anhDoHoa.SelectedImageIndex = 2;
			for (int i=0;i<10;++i)
			{
				TreeNode node_anhChup = anhChup.Nodes.Add(i.ToString() + ".JPG");
				node_anhChup.ImageIndex = 0;
				node_anhChup.SelectedImageIndex = 1;
			}
			for (char i='A';i<='Z';++i)
			{
				TreeNode node_anhVe = anhVe.Nodes.Add(i + ".PNG");
				node_anhVe.ImageIndex = 0;
				node_anhVe.SelectedImageIndex = 1;
			}
			for (int i=3;i<=7;++i)
				for (char j='k';j<='o';++j)
				{
					TreeNode node_anhDoHoa = anhDoHoa.Nodes.Add(j + i.ToString() + ".JPG");
					node_anhDoHoa.ImageIndex = 0;
					node_anhDoHoa.SelectedImageIndex = 1;
				}
		}

		private void tsbt1_Click(object sender, EventArgs e)
		{
			treeView.ExpandAll();
		}

		private void tsbt2_Click(object sender, EventArgs e)
		{
			treeView.CollapseAll();
		}
	}
}
