using Microsoft.Win32;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace QuanLyBanHang
{
	public static class Excel
	{
		/// <summary>
		/// Find and return path of worksheet excel
		/// </summary>
		/// <returns>the path</returns>
		public static string OpenFile()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Browse to Price list";
			openFileDialog.Filter = "Microsoft Excel Worksheet (*.xlsx)|*.xlsx";
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			if (openFileDialog.ShowDialog() == true)
				return openFileDialog.FileName;
			else
				return null;
		}

		/// <summary>
		/// Read and return data from BangGia
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static List<BangGia> ReadExcel(string filePath)
		{
			FileInfo file = new FileInfo(filePath);
			List<BangGia> bangGia = new List<BangGia>();
			using (ExcelPackage package = new ExcelPackage(file))
			{
				ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
				int colCount = worksheet.Dimension.End.Column;
				int rowCount = worksheet.Dimension.End.Row; //Excel based index is 1
				for (int i = 2; i <= rowCount; i++)
				{
					string ten = worksheet.Cells[i, 1].Value.ToString();
					string loai = worksheet.Cells[i, 2].Value.ToString();
					int donGia = int.Parse(worksheet.Cells[i, 3].Value.ToString());
					bangGia.Add(new BangGia() { Tên = ten, Loại = loai, ĐơnGiá = donGia });
				}
			}
			return bangGia;
		}
	}
}
