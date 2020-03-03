using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CARO
{
	public class Controller
	{
		public static Pen DefaultPen;
		public static SolidBrush Black;
		public static SolidBrush White;
		public bool IsReady { get; set; }
		public int Mode { get; set; }

		private Random random = new Random(); // random ô cờ máy sẽ đánh đầu tiên, và random lượt đi đầu tiên
		private Board board;
		private Cell[,] array;
		private int current; // 1 black, 2 white
		private Stack<Cell> history;

		public Controller()
		{
			//khởi tạo bàn cờ với số dòng 20, số cột 30
			board = new Board(fmCoCaro.ChieuCaoBanCo / Cell.Height, fmCoCaro.ChieuRongBanCo / Cell.Width);
			//khởi tạo 3 loại bút vẽ
			DefaultPen = new Pen(Color.DarkKhaki, 1);
			Black = new SolidBrush(Color.Black);
			White = new SolidBrush(Color.White);
			IsReady = false;
			//khai báo mảng các ô cờ 
			array = new Cell[board.NumRow, board.NumCol];
		}

		//vẽ bàn cờ
		public void DrawBoard(Graphics g)
		{
			board.DrawBoard(g);
		}

		//khởi tạo mảng ô cờ
		public void InitArray()
		{
			for (int i = 0; i < board.NumRow; i++)
				for (int j = 0; j < board.NumCol; j++)
				{
					array[i, j] = new Cell(i, j, 0);
				}
		}

		// đánh cờ
		public void DrawChess(Graphics graphic, int xPos, int yPos)
		{
			int row = yPos / Cell.Height;
			int column = xPos / Cell.Width;
			Cell cell;

			//loại bỏ trường hợp người chơi kích vào giữa đường kẻ vạch
			if (yPos % Cell.Height != 0 && xPos % Cell.Width != 0)
			{
				//chỉ đánh vào những ô trống
				if (array[row, column].Possess == 0)
				{
					//quân đen đánh
					if (current == 1)
					{
						board.DrawChess(graphic, column * Cell.Height, row * Cell.Width, current);
						array[row, column].Possess = 1;
						cell = new Cell(array[row, column].Row, array[row, column].Column, array[row, column].Possess);
						history.Push(cell);
						current = 2;
					}
					//quân trắng đánh
					else
					{
						board.DrawChess(graphic, column * Cell.Height, row * Cell.Width, current);
						array[row, column].Possess = 2;
						cell = new Cell(array[row, column].Row, array[row, column].Column, array[row, column].Possess);
						history.Push(cell);
						current = 1;
					}
				}
			}
		}

		//vẽ lại quân cờ
		public void UpdateBoard(Graphics graphic)
		{
			if (history.Count != 0)
			{
				foreach (Cell cell in history)
				{
					board.DrawChess(graphic, cell.Column * Cell.Width, cell.Row * Cell.Height, cell.Possess);
				}
			}
		}

		public void PlayWithHuman(Graphics graphic)
		{
			Mode = 1;
			current = random.Next(0, 2);
			if (current == 1)
				MessageBox.Show("Quân đỏ đi trước");
			else MessageBox.Show("Quân xanh đi trước");
			IsReady = true;
			InitArray();
			history = new Stack<Cell>();
			DrawBoard(graphic);
		}

		public void PlayWithComputer(Graphics graphic)
		{
			Mode = 2;
			current = random.Next(0, 2);
			if (current == 1)
				MessageBox.Show("Máy đi trước");
			else MessageBox.Show("Người chơi đi trước");
			IsReady = true;
			InitArray();
			history = new Stack<Cell>();
			DrawBoard(graphic);
			ActedByComputer(graphic);
		}

		//máy đánh
		public void ActedByComputer(Graphics g)
		{
			int point = 0;
			int defendingPoint;
			int attackingPoint;
			Cell cell = new Cell();
			if (current == 1)
			{
				if (history.Count == 0)
				{
					DrawChess(g, random.Next((board.NumCol / 2 - 3) * Cell.Width + 1, (board.NumCol / 2 + 3) * Cell.Width + 1), 
						random.Next((board.NumRow / 2 - 3) * Cell.Height, (board.NumRow / 2 + 3) * Cell.Height));
				}
				else
				{
					// Minimax Algorithm
					for (int i = 0; i < board.NumRow; i++)
					{
						for (int j = 0; j < board.NumCol; j++)
						{
							//nếu nước cờ chưa có ai đánh và không bị cắt tỉa thì mới xét giá trị MinMax
							if (array[i, j].Possess == 0 && !catTia(array[i, j]))
							{
								int tempPoint;

								attackingPoint = duyetTC_Ngang(i, j) + duyetTC_Doc(i, j) + duyetTC_CheoXuoi(i, j) + duyetTC_CheoNguoc(i, j);
								defendingPoint = duyetPN_Ngang(i, j) + duyetPN_Doc(i, j) + duyetPN_CheoXuoi(i, j) + duyetPN_CheoNguoc(i, j);

								if (defendingPoint > attackingPoint)
								{
									tempPoint = defendingPoint;
								}
								else
								{
									tempPoint = attackingPoint;
								}
								if (point < tempPoint)
								{
									point = tempPoint;
									cell = new Cell(array[i, j].Row, array[i, j].Column, array[i, j].Possess);
								}
							}
						}
					}
					DrawChess(g, cell.Column * Cell.Width + 1, cell.Row * Cell.Height + 1);
				}
			}
		}


		#region Cắt tỉa Alpha beta
		bool catTia(Cell oCo)
		{
			//nếu cả 4 hướng đều không có nước cờ thì cắt tỉa
			if (catTiaNgang(oCo) && catTiaDoc(oCo) && catTiaCheoPhai(oCo) && catTiaCheoTrai(oCo))
				return true;

			//chạy đến đây thì 1 trong 4 hướng vẫn có nước cờ thì không được cắt tỉa
			return false;
		}

		bool catTiaNgang(Cell oCo)
		{
			//duyệt bên phải
			if (oCo.Column <= board.NumCol - 5)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row, oCo.Column + i].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//duyệt bên trái
			if (oCo.Column >= 4)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row, oCo.Column - i].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
			return true;
		}
		bool catTiaDoc(Cell oCo)
		{
			//duyệt phía giưới
			if (oCo.Row <= board.NumRow - 5)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row + i, oCo.Column].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//duyệt phía trên
			if (oCo.Row >= 4)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row - i, oCo.Column].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
			return true;
		}
		bool catTiaCheoPhai(Cell oCo)
		{
			//duyệt từ trên xuống
			if (oCo.Row <= board.NumRow - 5 && oCo.Column >= 4)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row + i, oCo.Column - i].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//duyệt từ giưới lên
			if (oCo.Column <= board.NumCol - 5 && oCo.Row >= 4)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row - i, oCo.Column + i].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
			return true;
		}
		bool catTiaCheoTrai(Cell oCo)
		{
			//duyệt từ trên xuống
			if (oCo.Row <= board.NumRow - 5 && oCo.Column <= board.NumCol - 5)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row + i, oCo.Column + i].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//duyệt từ giưới lên
			if (oCo.Column >= 4 && oCo.Row >= 4)
				for (int i = 1; i <= 4; i++)
					if (array[oCo.Row - i, oCo.Column - i].Possess != 0)//nếu có nước cờ thì không cắt tỉa
						return false;

			//nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
			return true;
		}

		#endregion

		#region AI

		private int[] MangDiemTanCong = new int[7] { 0, 4, 25, 246, 7300, 6561, 59049 };
		private int[] MangDiemPhongNgu = new int[7] { 0, 3, 24, 243, 2197, 19773, 177957 };
		//private int[] MangDiemPhongNgu = new int[7] { 0, 1, 9, 81, 729, 6561, 59049 };
		#region Tấn công
		//duyệt ngang
		public int duyetTC_Ngang(int dongHT, int cotHT)
		{
			int DiemTanCong = 0;
			int SoQuanTa = 0;
			int SoQuanDichPhai = 0;
			int SoQuanDichTrai = 0;
			int KhoangChong = 0;

			//bên phải
			for (int dem = 1; dem <= 4 && cotHT < board.NumCol - 5; dem++)
			{

				if (array[dongHT, cotHT + dem].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;
				}
				else
					if (array[dongHT, cotHT + dem].Possess == 2)
				{
					SoQuanDichPhai++;
					break;
				}
				else KhoangChong++;
			}
			//bên trái
			for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
			{
				if (array[dongHT, cotHT - dem].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;

				}
				else
					if (array[dongHT, cotHT - dem].Possess == 2)
				{
					SoQuanDichTrai++;
					break;
				}
				else KhoangChong++;
			}
			//bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
			if (SoQuanDichPhai > 0 && SoQuanDichTrai > 0 && KhoangChong < 4)
				return 0;

			DiemTanCong -= MangDiemPhongNgu[SoQuanDichPhai + SoQuanDichTrai];
			DiemTanCong += MangDiemTanCong[SoQuanTa];
			return DiemTanCong;
		}

		//duyệt dọc
		public int duyetTC_Doc(int dongHT, int cotHT)
		{
			int DiemTanCong = 0;
			int SoQuanTa = 0;
			int SoQuanDichTren = 0;
			int SoQuanDichDuoi = 0;
			int KhoangChong = 0;

			//bên trên
			for (int dem = 1; dem <= 4 && dongHT > 4; dem++)
			{
				if (array[dongHT - dem, cotHT].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;

				}
				else
					if (array[dongHT - dem, cotHT].Possess == 2)
				{
					SoQuanDichTren++;
					break;
				}
				else KhoangChong++;
			}
			//bên dưới
			for (int dem = 1; dem <= 4 && dongHT < board.NumRow - 5; dem++)
			{
				if (array[dongHT + dem, cotHT].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;

				}
				else
					if (array[dongHT + dem, cotHT].Possess == 2)
				{
					SoQuanDichDuoi++;
					break;
				}
				else KhoangChong++;
			}
			//bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
			if (SoQuanDichTren > 0 && SoQuanDichDuoi > 0 && KhoangChong < 4)
				return 0;

			DiemTanCong -= MangDiemPhongNgu[SoQuanDichTren + SoQuanDichDuoi];
			DiemTanCong += MangDiemTanCong[SoQuanTa];
			return DiemTanCong;
		}

		//chéo xuôi
		public int duyetTC_CheoXuoi(int dongHT, int cotHT)
		{
			int DiemTanCong = 1;
			int SoQuanTa = 0;
			int SoQuanDichCheoTren = 0;
			int SoQuanDichCheoDuoi = 0;
			int KhoangChong = 0;

			//bên chéo xuôi xuống
			for (int dem = 1; dem <= 4 && cotHT < board.NumCol - 5 && dongHT < board.NumRow - 5; dem++)
			{
				if (array[dongHT + dem, cotHT + dem].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;

				}
				else
					if (array[dongHT + dem, cotHT + dem].Possess == 2)
				{
					SoQuanDichCheoTren++;
					break;
				}
				else KhoangChong++;
			}
			//chéo xuôi lên
			for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
			{
				if (array[dongHT - dem, cotHT - dem].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;

				}
				else
					if (array[dongHT - dem, cotHT - dem].Possess == 2)
				{
					SoQuanDichCheoDuoi++;
					break;
				}
				else KhoangChong++;
			}
			//bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
			if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
				return 0;

			DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
			DiemTanCong += MangDiemTanCong[SoQuanTa];
			return DiemTanCong;
		}

		//chéo ngược
		public int duyetTC_CheoNguoc(int dongHT, int cotHT)
		{
			int DiemTanCong = 0;
			int SoQuanTa = 0;
			int SoQuanDichCheoTren = 0;
			int SoQuanDichCheoDuoi = 0;
			int KhoangChong = 0;

			//chéo ngược lên
			for (int dem = 1; dem <= 4 && cotHT < board.NumCol - 5 && dongHT > 4; dem++)
			{
				if (array[dongHT - dem, cotHT + dem].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;

				}
				else
					if (array[dongHT - dem, cotHT + dem].Possess == 2)
				{
					SoQuanDichCheoTren++;
					break;
				}
				else KhoangChong++;
			}
			//chéo ngược xuống
			for (int dem = 1; dem <= 4 && cotHT > 4 && dongHT < board.NumRow - 5; dem++)
			{
				if (array[dongHT + dem, cotHT - dem].Possess == 1)
				{
					if (dem == 1)
						DiemTanCong += 37;

					SoQuanTa++;
					KhoangChong++;

				}
				else
					if (array[dongHT + dem, cotHT - dem].Possess == 2)
				{
					SoQuanDichCheoDuoi++;
					break;
				}
				else KhoangChong++;
			}
			//bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
			if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
				return 0;

			DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
			DiemTanCong += MangDiemTanCong[SoQuanTa];
			return DiemTanCong;
		}
		#endregion

		#region phòng ngự

		//duyệt ngang
		public int duyetPN_Ngang(int dongHT, int cotHT)
		{
			int DiemPhongNgu = 0;
			int SoQuanTaTrai = 0;
			int SoQuanTaPhai = 0;
			int SoQuanDich = 0;
			int KhoangChongPhai = 0;
			int KhoangChongTrai = 0;
			bool ok = false;


			for (int dem = 1; dem <= 4 && cotHT < board.NumCol - 5; dem++)
			{
				if (array[dongHT, cotHT + dem].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;
				}
				else
					if (array[dongHT, cotHT + dem].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaTrai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongPhai++;
				}
			}

			if (SoQuanDich == 3 && KhoangChongPhai == 1 && ok)
				DiemPhongNgu -= 200;

			ok = false;

			for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
			{
				if (array[dongHT, cotHT - dem].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;
				}
				else
					if (array[dongHT, cotHT - dem].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaPhai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongTrai++;
				}
			}

			if (SoQuanDich == 3 && KhoangChongTrai == 1 && ok)
				DiemPhongNgu -= 200;

			if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTrai + KhoangChongPhai + SoQuanDich) < 4)
				return 0;

			DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaPhai];
			DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

			return DiemPhongNgu;
		}

		//duyệt dọc
		public int duyetPN_Doc(int dongHT, int cotHT)
		{
			int DiemPhongNgu = 0;
			int SoQuanTaTrai = 0;
			int SoQuanTaPhai = 0;
			int SoQuanDich = 0;
			int KhoangChongTren = 0;
			int KhoangChongDuoi = 0;
			bool ok = false;

			//lên
			for (int dem = 1; dem <= 4 && dongHT > 4; dem++)
			{
				if (array[dongHT - dem, cotHT].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;

				}
				else
					if (array[dongHT - dem, cotHT].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaPhai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongTren++;
				}
			}

			if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
				DiemPhongNgu -= 200;

			ok = false;
			//xuống
			for (int dem = 1; dem <= 4 && dongHT < board.NumRow - 5; dem++)
			{
				//gặp quân địch
				if (array[dongHT + dem, cotHT].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;
				}
				else
					if (array[dongHT + dem, cotHT].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaTrai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongDuoi++;
				}
			}

			if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
				DiemPhongNgu -= 200;

			if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
				return 0;

			DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
			DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];
			return DiemPhongNgu;
		}

		//chéo xuôi
		public int duyetPN_CheoXuoi(int dongHT, int cotHT)
		{
			int DiemPhongNgu = 0;
			int SoQuanTaTrai = 0;
			int SoQuanTaPhai = 0;
			int SoQuanDich = 0;
			int KhoangChongTren = 0;
			int KhoangChongDuoi = 0;
			bool ok = false;

			//lên
			for (int dem = 1; dem <= 4 && dongHT < board.NumRow - 5 && cotHT < board.NumCol - 5; dem++)
			{
				if (array[dongHT + dem, cotHT + dem].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;
				}
				else
					if (array[dongHT + dem, cotHT + dem].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaPhai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongTren++;
				}
			}

			if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
				DiemPhongNgu -= 200;

			ok = false;
			//xuống
			for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
			{
				if (array[dongHT - dem, cotHT - dem].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;
				}
				else
					if (array[dongHT - dem, cotHT - dem].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaTrai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongDuoi++;
				}
			}

			if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
				DiemPhongNgu -= 200;

			if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
				return 0;

			DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaTrai];
			DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

			return DiemPhongNgu;
		}

		//chéo ngược
		public int duyetPN_CheoNguoc(int dongHT, int cotHT)
		{
			int DiemPhongNgu = 0;
			int SoQuanTaTrai = 0;
			int SoQuanTaPhai = 0;
			int SoQuanDich = 0;
			int KhoangChongTren = 0;
			int KhoangChongDuoi = 0;
			bool ok = false;

			//lên
			for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT < board.NumCol - 5; dem++)
			{

				if (array[dongHT - dem, cotHT + dem].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;
				}
				else
					if (array[dongHT - dem, cotHT + dem].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaPhai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongTren++;
				}
			}


			if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
				DiemPhongNgu -= 200;

			ok = false;

			//xuống
			for (int dem = 1; dem <= 4 && dongHT < board.NumRow - 5 && cotHT > 4; dem++)
			{
				if (array[dongHT + dem, cotHT - dem].Possess == 2)
				{
					if (dem == 1)
						DiemPhongNgu += 9;

					SoQuanDich++;
				}
				else
					if (array[dongHT + dem, cotHT - dem].Possess == 1)
				{
					if (dem == 4)
						DiemPhongNgu -= 170;

					SoQuanTaTrai++;
					break;
				}
				else
				{
					if (dem == 1)
						ok = true;

					KhoangChongDuoi++;
				}
			}

			if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
				DiemPhongNgu -= 200;

			if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
				return 0;

			DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
			DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

			return DiemPhongNgu;
		}

		#endregion

		#endregion

		#region duyệt chiến thắng theo 8 hướng
		//kiểm tra chiến thắng
		public bool kiemTraChienThang(Graphics g)
		{
			if (history.Count != 0)
			{
				foreach (Cell oco in history)
				{
					//duyệt theo 8 hướng mỗi quân cờ
					if (duyetNgangPhai(g, oco.Row, oco.Column, oco.Possess) || duyetNgangTrai(g, oco.Row, oco.Column, oco.Possess)
						|| duyetDocTren(g, oco.Row, oco.Column, oco.Possess) || duyetDocDuoi(g, oco.Row, oco.Column, oco.Possess)
						|| duyetCheoXuoiTren(g, oco.Row, oco.Column, oco.Possess) || duyetCheoXuoiDuoi(g, oco.Row, oco.Column, oco.Possess)
						|| duyetCheoNguocTren(g, oco.Row, oco.Column, oco.Possess) || duyetCheoNguocDuoi(g, oco.Row, oco.Column, oco.Possess))
					{
						ketThucTroChoi(oco);
						return true;
					}
				}
			}

			return false;
		}

		//vẽ đường kẻ trên 5 nước thắng
		public void veDuongChienThang(Graphics g, int x1, int y1, int x2, int y2)
		{
			g.DrawLine(new Pen(Color.Blue, 3f), x1, y1, x2, y2);
		}

		public bool duyetNgangPhai(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (cotHT > board.NumCol - 5)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT, cotHT + dem].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, (cotHT) * Cell.Width, dongHT * Cell.Height + Cell.Height / 2, (cotHT + 5) * Cell.Width, dongHT * Cell.Height + Cell.Height / 2);
			return true;
		}

		public bool duyetNgangTrai(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (cotHT < 4)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT, cotHT - dem].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, (cotHT + 1) * Cell.Width, dongHT * Cell.Height + Cell.Height / 2, (cotHT - 4) * Cell.Width, dongHT * Cell.Height + Cell.Height / 2);
			return true;
		}

		public bool duyetDocTren(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (dongHT < 4)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT - dem, cotHT].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, cotHT * Cell.Width + Cell.Width / 2, (dongHT + 1) * Cell.Height, cotHT * Cell.Width + Cell.Width / 2, (dongHT - 4) * Cell.Height);
			return true;
		}

		public bool duyetDocDuoi(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (dongHT > board.NumRow - 5)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT + dem, cotHT].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, cotHT * Cell.Width + Cell.Width / 2, dongHT * Cell.Height, cotHT * Cell.Width + Cell.Width / 2, (dongHT + 5) * Cell.Height);
			return true;
		}

		public bool duyetCheoXuoiTren(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (dongHT < 4 || cotHT < 4)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT - dem, cotHT - dem].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, (cotHT + 1) * Cell.Width, (dongHT + 1) * Cell.Height, (cotHT - 4) * Cell.Width, (dongHT - 4) * Cell.Height);
			return true;
		}

		public bool duyetCheoXuoiDuoi(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (dongHT > board.NumRow - 5 || cotHT > board.NumCol - 5)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT + dem, cotHT + dem].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, cotHT * Cell.Width, dongHT * Cell.Height, (cotHT + 5) * Cell.Width, (dongHT + 5) * Cell.Height);
			return true;
		}

		public bool duyetCheoNguocDuoi(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (dongHT > board.NumRow - 5 || cotHT < 4)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT + dem, cotHT - dem].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, (cotHT + 1) * Cell.Width, dongHT * Cell.Height, (cotHT - 4) * Cell.Width, (dongHT + 5) * Cell.Height);
			return true;
		}

		public bool duyetCheoNguocTren(Graphics g, int dongHT, int cotHT, int SoHuu)
		{
			if (dongHT < 4 || cotHT > board.NumCol - 5)
				return false;
			for (int dem = 1; dem <= 4; dem++)
			{
				if (array[dongHT - dem, cotHT + dem].Possess != SoHuu)
				{
					return false;
				}

			}
			veDuongChienThang(g, cotHT * Cell.Width, (dongHT + 1) * Cell.Height, (cotHT + 5) * Cell.Width, (dongHT - 4) * Cell.Height);
			return true;
		}

		#endregion

		//kết thúc trò chơi
		public void ketThucTroChoi(Cell oco)
		{
			//chơi với người
			if (Mode == 1)
			{
				if (oco.Possess == 1)
					MessageBox.Show("Quân đỏ thắng");
				else
					MessageBox.Show("Quân xanh thắng");
			}
			else//chơi với máy
			{
				if (oco.Possess == 1)
					MessageBox.Show("Máy thắng");
				else
					MessageBox.Show("Người chơi thắng");
			}

			IsReady = false;
		}
	}
}
