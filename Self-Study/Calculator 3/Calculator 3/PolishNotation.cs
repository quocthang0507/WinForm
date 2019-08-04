using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator_3
{
	class PolishNotation
	{
		public string bieuThuc;

		public List<string> input = new List<string>();

		public Stack<string> stack = new Stack<string>();

		public List<string> output = new List<string>();

		public void Chuyen_BieuThuc_DanhSach()
		{
			for (int i = 0; i < bieuThuc.Length; i++)
			{
				if (bieuThuc[i] >= '0' && bieuThuc[i] <= '9')
				{
					string t = Tach_So(bieuThuc, i);
					input.Add(t);
					i += t.Length - 1;
				}
				else input.Add(bieuThuc[i].ToString());
			}
		}

		public int Dem_SoKyTu(char c)
		{
			return bieuThuc.Count(x => x == c);
		}

		public bool KT_BT_Dung()
		{
			if (La_ToanTu(bieuThuc[0].ToString()))
				bieuThuc.Insert(0, "0");
			if (bieuThuc.Contains("(") || bieuThuc.Contains(")"))
				if (Dem_SoKyTu('(') > Dem_SoKyTu(')'))
					throw new Exception("Bạn thiếu dấu đóng ngoặc ')'");
				else if (Dem_SoKyTu('(') < Dem_SoKyTu(')'))
					throw new Exception("Bạn thiếu dấu mở ngoặc '('");
			for (int i = 0; i < bieuThuc.Length - 1; i++)
			{
				if (La_ToanTu(bieuThuc[i].ToString()) && La_ToanTu(bieuThuc[i + 1].ToString()))
					throw new Exception("Bạn nhập sai cú pháp");
			}
			return true;
		}

		public static int Do_UuTien_ToanTu(string c)
		{
			if (c == "*" || c == "/" || c == "%")
				return 2;
			else if (c == "+" || c == "-")
				return 1;
			else return 0;
		}

		public static bool La_ToanTu(string c)
		{
			if (c == "+" || c == "-" || c == "*" || c == "/" || c == "%")
				return true;
			else return false;
		}

		public static bool La_KySo(string s)
		{
			double n;
			return double.TryParse(s, out n);
		}

		public string Tach_So(string s, int index)
		{
			string t = "";
			do
			{
				t += s[index];
				index++;
			} while (index < s.Length && ((s[index] >= '0' && s[index] <= '9') || s[index] == '.'));
			return t;
		}

		public void TrungTo_HauTo()
		{
			Chuyen_BieuThuc_DanhSach();
			string x;
			foreach (var item in this.input)
			{
				if (La_KySo(item))
					output.Add(item);
				else if (item == "(")
					this.stack.Push(item);
				else if (item == ")")
				{
					x = stack.Pop();
					while (x != "(")
					{
						output.Add(x);
						x = stack.Pop();
					}
				}
				else
				{
					while (this.stack.Count > 0 && La_ToanTu(stack.Peek()))
						if (Do_UuTien_ToanTu(stack.Peek()) >= Do_UuTien_ToanTu(item))
						{
							x = stack.Pop();
							output.Add(x);
						}
						else break;
					stack.Push(item);
				}
			}
			while (stack.Count > 0)
			{
				x = stack.Pop();
				output.Add(x);
			}
		}

		public double Tinh_BieuThuc_HauTo()
		{
			double x, y;
			Stack<double> s = new Stack<double>();
			foreach (var item in output)
			{
				if (La_KySo(item))
				{
					x = double.Parse(item, System.Globalization.CultureInfo.InvariantCulture);
					s.Push(x);
				}
				else
				{
					x = s.Pop();
					y = s.Pop();
					switch (item)
					{
						case "+":
							s.Push(y + x);
							break;
						case "-":
							s.Push(y - x);
							break;
						case "*":
							s.Push(y * x);
							break;
						case "/":
							if (x == 0)
								throw new Exception("Không thể thực hiện phép chia cho không");
							else
								s.Push(y / x);
							break;
						case "%":
							if (x == 0)
								throw new Exception("Không thể thực hiện phép chia cho không");
							else
								s.Push(y % x);
							break;
						default:
							break;
					}
				}
			}
			return s.Peek();
		}

		public string Xuat_BieuThuc_HauTo()
		{
			string s = "";
			foreach (var item in output)
			{
				s += item + ' ';
			}
			return s;
		}

		public void Reset()
		{
			bieuThuc = "";
			input.Clear();
			output.Clear();
			stack.Clear();
		}
	}
}
