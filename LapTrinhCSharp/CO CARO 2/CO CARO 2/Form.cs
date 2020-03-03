using System;
using System.Drawing;
using System.Windows.Forms;

namespace CARO
{
	public partial class fmCoCaro : Form
	{
		public static int ChieuRongBanCo;
		public static int ChieuCaoBanCo;
		private Graphics grp;
		private Controller DieuKhien;
		private fmLuatChoi LuatChoi;

		public fmCoCaro()
		{
			InitializeComponent();
			//vẽ nên pnlBanCo
			grp = pnlBanCo.CreateGraphics();

			//lấy chiều rộng và chiều cao pnBanCo để vẽ bàn cờ
			ChieuCaoBanCo = pnlBanCo.Height;
			ChieuRongBanCo = pnlBanCo.Width;

			//khởi tạo đối tượng điều khiển trò chơi
			DieuKhien = new Controller();

			LuatChoi = new fmLuatChoi();
		}

		private void pnlBanCo_Paint(object sender, PaintEventArgs e)
		{
			if (DieuKhien.IsReady)
			{
				//vẽ bàn cờ
				DieuKhien.DrawBoard(grp);
				//vẽ lại các quân cờ trong stack
				DieuKhien.UpdateBoard(grp);
			}
		}

		private void chơiVớiNgườiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DieuKhien.PlayWithHuman(grp);

			grp.Clear(pnlBanCo.BackColor);
			Image image = new Bitmap(Properties.Resources.b);
			pnlBanCo.BackgroundImage = image;
			//xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
		}

		private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
		{
			if (DieuKhien.IsReady)
			{
				//chơi với người
				if (DieuKhien.Mode == 1)
				{
					//đánh cờ với tọa độ chuột khi lick vào panel bàn cờ
					DieuKhien.DrawChess(grp, e.Location.X, e.Location.Y);
					//sau khi đánh cờ thì kiểm tra chiến thắng luôn
					DieuKhien.kiemTraChienThang(grp);
				}
				//chơi với máy
				else
				{
					//người chơi đánh
					DieuKhien.DrawChess(grp, e.Location.X, e.Location.Y);
					//kiểm tra người chơi chưa chiến thắng thì cho máy đánh
					if (!DieuKhien.kiemTraChienThang(grp))
					{
						//máy đánh
						DieuKhien.ActedByComputer(grp);
						DieuKhien.kiemTraChienThang(grp);
					}
				}
			}
		}

		private void chơiVớiMáyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DieuKhien.PlayWithComputer(grp);

			grp.Clear(pnlBanCo.BackColor);
			Image image = new Bitmap(Properties.Resources.b);
			pnlBanCo.BackgroundImage = image;
			//xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel

		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void luậtChơiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LuatChoi.ShowDialog();
		}

		private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(" Game Cờ caro \n Phiên bản 1.0 \n Tác giả: Hoàng Phong \n Liên hệ: hoangphongdhhp@gmail.com", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}
