using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanHang
{
	class ExcelReader
	{
		int rowCount, colCount;

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
		/// Read and get data from excel file to object array
		/// </summary>
		/// <returns>Array of object</returns>
		public object[,] GetDataFromExcel(string path)
		{
			//Create COM Objects. Create a COM object for everything that is referenced
			Excel.Application xlsApp = new Excel.Application();
			Excel.Workbook xlsWorkbook = xlsApp.Workbooks.Open(path);
			Excel.Worksheet xlsWorksheet = xlsWorkbook.Sheets[1]; //excel is not zero based
			Excel.Range xlsRange = xlsWorksheet.UsedRange;

			object[,] valueArray = (object[,])xlsRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

			rowCount = xlsWorksheet.UsedRange.Rows.Count;
			colCount = xlsWorksheet.UsedRange.Columns.Count;

			//cleanup
			GC.Collect();
			GC.WaitForPendingFinalizers();

			//release com objects to fully kill excel process from running in the background
			Marshal.ReleaseComObject(xlsRange);
			Marshal.ReleaseComObject(xlsWorksheet);

			//close and release
			xlsWorkbook.Close();
			Marshal.ReleaseComObject(xlsWorkbook);

			//quit and release
			xlsApp.Quit();
			Marshal.ReleaseComObject(xlsApp);

			return valueArray;
		}
	}
}
