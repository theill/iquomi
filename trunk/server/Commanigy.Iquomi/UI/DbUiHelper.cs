#region Using directives

using System;
using System.Globalization;

#endregion

namespace Commanigy.Iquomi.Ui {
	/// <summary>
	/// 
	/// </summary>
	public class DbUiHelper {
		public DbUiHelper() {
			;
		}

		public static string ToPackageState(string state) {
			switch (state) {
				case "N":
					return "New";
				case "A":
					return "Activated";
				case "D":
					return "Deactivated";
				case "R":
					return "Retired";
			}

			return "Unknown";
		}
		
		
		public static string ToServiceState(string state) {
			switch (state) {
				case "D":
					return "Design";
				case "P":
					return "Provisioned";
				case "O":
					return "Offline";
				case "R":
					return "Retired";
			}

			return "Unknown";
		}

		public static string ToShapeType(string type) {
			switch (type) {
				case "I":
					return "Include";

				case "E":
					return "Exclude";
			}

			return "Unknown";
		}
		
		
		/// <summary>
		/// Converts argument to file size unit determined by size.
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		public static string ToFileSize(long size) {
			if (size == 0) {
				return "-";
			}

			string unit;
			double d = size;
			if (d > 1048576) {
				d /= 1048576;
				unit = "MB";
			} else if (d > 1024) {
				d /= 1024;
				unit = "KB";
			} else {
				unit = "B";
			}
			
			return string.Format("{0} {1}", d.ToString("N"), unit);
		}

		public static string ToShortDate(DateTime dateTime) {
			return (dateTime != DateTime.MinValue) ? dateTime.ToShortDateString() : "";
		}

		public static DateTime FromShortDate(string dateTimeString) {
			if (dateTimeString == null || dateTimeString.Length == 0) {
				return DateTime.MinValue;
			}

			return Convert.ToDateTime(dateTimeString);
		}

		public static string ToGeneralDateTime(DateTime dateTime) {
			return (dateTime != DateTime.MinValue) ? dateTime.ToString() : "";
		}

		public static DateTime FromGeneralDateTime(string dateTimeString) {
			if (dateTimeString == null || dateTimeString.Length == 0) {
				return DateTime.MinValue;
			}

			return Convert.ToDateTime(dateTimeString, DateTimeFormatInfo.CurrentInfo);
		}
	}
}