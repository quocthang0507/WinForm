using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
	class Calculate
	{
		public static int ngay;
		public static int thang;
		public static int nam;

		public static int DayOfWeek(int d, int m, int y)
		{
			int t, x, k, w;
			t = y - (14 - m) / 12;
			x = t + t / 4 - t / 100 + t / 400;
			k = m + 12 * ((14 - m) / 12) - 2;
			w = (d + x + (31 * k) / 12) % 7;
			return w;
		}

		public static int INT(double d)
		{
			return (int)Math.Floor(d);
		}

		public static int MOD(int x, int y)
		{
			int z = x - (int)(y * Math.Floor(((double)x / y)));
			if (z == 0)
			{
				z = y;
			}
			return z;
		}

		//Tham khảo tại: http://www.informatik.uni-leipzig.de/~duc/amlich/

		//Đổi ngày dd/mm/yyyy ra số ngày Julius jd
		public static int jdFromDate(int dd, int mm, int yy)
		{
			int a, y, m, jd;
			a = INT((14 - mm) / 12);
			y = yy + 4800 - a;
			m = mm + 12 * a - 3;
			jd = dd + INT((153 * m + 2) / 5) + 365 * y + INT(y / 4) - INT(y / 100) + INT(y / 400) - 32045;
			if (jd < 2299161)
				jd = dd + INT((153 * m + 2) / 5) + 365 * y + INT(y / 4) - 32083;
			return jd;
		}

		//Đổi số ngày Julius jd ra ngày dd/mm/yyyy
		public static Array jdToDate(int jd)
		{
			int[,,] arr;
			int a, b, c, d, e, m, day, month, year;
			if (jd > 2299160)
			{
				a = jd + 32044;
				b = INT((4 * a + 3) / 146097);
				c = a - INT((b * 146097) / 4);
			}
			else
			{
				b = 0;
				c = jd + 32082;
			}
			d = INT((4 * c + 3) / 1461);
			e = c - INT((1461 * d) / 4);
			m = INT((5 * e + 2) / 153);
			day = e - INT((153 * m + 2) / 5) + 1;
			month = m + 3 - 12 * INT(m / 10);
			year = b * 100 + d - 4800 + INT(m / 10);
			arr = new int[day, month, year];
			return arr;
		}

		//Tính ngày Sóc
		public static int getNewMoonDay(int k, double timeZone = 7.0)
		{
			var T = k / 1236.85;
			var T2 = T * T;
			var T3 = T2 * T;
			var dr = Math.PI / 180;
			var Jd1 = 2415020.75933 + 29.53058868 * k + 0.0001178 * T2 - 0.000000155 * T3;
			Jd1 = Jd1 + 0.00033 * Math.Sin((166.56 + 132.87 * T - 0.009173 * T2) * dr);
			var M = 359.2242 + 29.10535608 * k - 0.0000333 * T2 - 0.00000347 * T3;
			var Mpr = 306.0253 + 385.81691806 * k + 0.0107306 * T2 + 0.00001236 * T3;
			var F = 21.2964 + 390.67050646 * k - 0.0016528 * T2 - 0.00000239 * T3;
			var C1 = (0.1734 - 0.000393 * T) * Math.Sin(M * dr) + 0.0021 * Math.Sin(2 * dr * M);
			C1 = C1 - 0.4068 * Math.Sin(Mpr * dr) + 0.0161 * Math.Sin(dr * 2 * Mpr);
			C1 = C1 - 0.0004 * Math.Sin(dr * 3 * Mpr);
			C1 = C1 + 0.0104 * Math.Sin(dr * 2 * F) - 0.0051 * Math.Sin(dr * (M + Mpr));
			C1 = C1 - 0.0074 * Math.Sin(dr * (M - Mpr)) + 0.0004 * Math.Sin(dr * (2 * F + M));
			C1 = C1 - 0.0004 * Math.Sin(dr * (2 * F - M)) - 0.0006 * Math.Sin(dr * (2 * F + Mpr));
			C1 = C1 + 0.0010 * Math.Sin(dr * (2 * F - Mpr)) + 0.0005 * Math.Sin(dr * (2 * Mpr + M));
			double deltat, JdNew;
			if (T < -11)
				deltat = 0.001 + 0.000839 * T + 0.0002261 * T2 - 0.00000845 * T3 - 0.000000081 * T * T3;
			else
				deltat = -0.000278 + 0.000265 * T + 0.000262 * T2;
			JdNew = Jd1 + C1 - deltat;
			return INT(JdNew + 0.5 + timeZone / 24);
		}

		//Tính tọa độ Mặt trời
		public static int getSunLongitude(double jdn, double timeZone = 7.0)
		{
			double T, T2, dr, M, L0, DL, L;
			T = (jdn - 2451545.5 - timeZone / 24) / 36525;
			T2 = T * T;
			dr = Math.PI / 180;
			M = 357.52910 + 35999.05030 * T - 0.0001559 * T2 - 0.00000048 * T * T2;
			L0 = 280.46645 + 36000.76983 * T + 0.0003032 * T2;
			DL = (1.914600 - 0.004817 * T - 0.000014 * T2) * Math.Sin(dr * M);
			DL = DL + (0.019993 - 0.000101 * T) * Math.Sin(dr * 2 * M) + 0.000290 * Math.Sin(dr * 3 * M);
			L = L0 + DL;
			L = L * dr;
			L = L - Math.PI * 2 * (INT(L / (Math.PI * 2)));
			return INT(L / Math.PI * 6);
		}

		//Tìm ngày bắt đầu tháng 11 âm lịch
		public static int getLunarMonth11(int yy, double timeZone = 7.0)
		{
			int off, k, nm, sunLong;
			off = jdFromDate(31, 12, yy) - 2415021;
			k = INT(off / 29.530588853);
			nm = getNewMoonDay(k, timeZone);
			sunLong = getSunLongitude(nm, timeZone); // sun longitude at local midnight
			if (sunLong >= 9)
			{
				nm = getNewMoonDay(k - 1, timeZone);
			}
			return nm;
		}

		//Xác định tháng nhuận
		public static int getLeapMonthOffset(int all, double timeZone = 7.0)
		{
			int k, last = 0, i = 1, arc;
			k = INT((all - 2415021.076998695) / 29.530588853 + 0.5);
			arc = getSunLongitude(getNewMoonDay(k + i, timeZone), timeZone);
			do
			{
				last = arc;
				i++;
				arc = getSunLongitude(getNewMoonDay(k + i, timeZone), timeZone);
			} while (arc != last && i < 14);
			return i - 1;
		}

		//Đổi ngày dương dd/mm/yyyy ra ngày âm
		public static string convertSolar2Lunar(int dd, int mm, int yy, double timeZone = 7.0)
		{
			int k, dayNumber, monthStart, a11, b11, lunarDay, lunarMonth, lunarYear, lunarLeap;
			int diff, leapMonthDiff;
			///int[,,,] array;
			dayNumber = jdFromDate(dd, mm, yy);
			k = INT((dayNumber - 2415021.076998695) / 29.530588853);
			monthStart = getNewMoonDay(k + 1, timeZone);
			if (monthStart > dayNumber)
				monthStart = getNewMoonDay(k, timeZone);
			a11 = getLunarMonth11(yy, timeZone);
			b11 = a11;
			if (a11 >= monthStart)
			{
				lunarYear = yy;
				a11 = getLunarMonth11(yy - 1, timeZone);
			}
			else
			{
				lunarYear = yy + 1;
				b11 = getLunarMonth11(yy + 1, timeZone);
			}
			lunarDay = dayNumber - monthStart + 1;
			diff = INT((monthStart - a11) / 29);
			lunarLeap = 0;
			lunarMonth = diff + 11;
			if (b11 - a11 > 365)
			{
				leapMonthDiff = getLeapMonthOffset(a11, timeZone);
				if (diff >= leapMonthDiff)
				{
					lunarMonth = diff + 10;
					if (diff == leapMonthDiff)
						lunarLeap = 1;
				}
			}
			if (lunarMonth > 12)
				lunarMonth = lunarMonth - 12;
			if (lunarMonth >= 11 && diff < 4)
				lunarYear -= 1;
			//return lunarDay.ToString() + " / " + lunarMonth.ToString() + " / " + lunarYear.ToString() + ", " + lunarLeap.ToString();
			return lunarDay.ToString() + " / " + lunarMonth.ToString() + " / " + lunarYear.ToString();
		}

			//Đổi âm lịch ra dương lịch
		public static Array convertLunar2Solar(int lunarDay, int lunarMonth, int lunarYear, int lunarLeap, double timeZone = 7.0)
		{
			int[,,] array;
			int k, a11, b11, off, leapOff, leapMonth, monthStart;
			if (lunarMonth < 11)
			{
				a11 = getLunarMonth11(lunarYear - 1, timeZone);
				b11 = getLunarMonth11(lunarYear, timeZone);
			}
			else
			{
				a11 = getLunarMonth11(lunarYear, timeZone);
				b11 = getLunarMonth11(lunarYear + 1, timeZone);
			}
			off = lunarMonth - 11;
			if (off < 0)
				off += 12;
			if (b11 - a11 > 365)
			{
				leapOff = getLeapMonthOffset(a11, timeZone);
				leapMonth = leapOff - 2;
				if (leapMonth < 0)
					leapMonth += 12;
				if (lunarLeap != 0 && lunarMonth != leapMonth)
				{
					array = new int[0, 0, 0];
					return array;
				}
				else if (lunarLeap != 0 || off >= leapOff)
					off += 1;
			}
			k = INT(0.5 + (a11 - 2415021.076998695) / 29.530588853);
			monthStart = getNewMoonDay(k + off, timeZone);
			return jdToDate(monthStart + lunarDay - 1);
		}

		//Tính Can-Chi cho ngày dương lịch
		public static string Can_Chi(int d, int m, int y)
		{
			string CHI = "";
			string CAN = "";
			int X = INT(jdFromDate(d, m, y) + 9.5) % 10;
			if (X == 0) CAN = "Giáp";
			if (X == 1) CAN = "Ất";
			if (X == 2) CAN = "Bính";
			if (X == 3) CAN = "Đinh";
			if (X == 4) CAN = "Mậu";
			if (X == 5) CAN = "Kỷ";
			if (X == 6) CAN = "Canh";
			if (X == 7) CAN = "Tân";
			if (X == 8) CAN = "Nhâm";
			if (X == 9) CAN = "Quý";
			int Y = INT(jdFromDate(d, m, y) + 1.5) % 12;
			if (Y == 0) CHI = "Tý";
			if (Y == 1) CHI = "Sửu";
			if (Y == 2) CHI = "Dần";
			if (Y == 3) CHI = "Mão";
			if (Y == 4) CHI = "Thìn";
			if (Y == 5) CHI = "Tị";
			if (Y == 6) CHI = "Ngọ";
			if (Y == 7) CHI = "Mùi";
			if (Y == 8) CHI = "Thân";
			if (Y == 9) CHI = "Dậu";
			if (Y == 10) CHI = "Tuất";
			if (Y == 11) CHI = "Hợi";
			return "\nNgày " + CAN + " " + CHI;
		}

		public static void ThoiGian()
		{
			System.DateTime dt = System.DateTime.Now;
			ngay = dt.Day;
			thang = dt.Month;
			nam = dt.Year;
		}
	}
}