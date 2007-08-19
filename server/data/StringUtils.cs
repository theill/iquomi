#region Using directives

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

#endregion

namespace Commanigy.Utils {
	/// <summary>
	/// Summary description for StringUtils.
	/// </summary>
	public class StringUtils {
		public StringUtils() {

		}

		/// <summary>
		/// Concatenates all fields of a given object into a string.
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static string FieldsToString(object o) {
			StringBuilder buffer = new StringBuilder();

			buffer.Append("[");
			foreach (FieldInfo i in o.GetType().GetFields()) {
				buffer.Append(i.Name + "=" + i.GetValue(o) + ",");
			}
			buffer.Length = Math.Max(1, buffer.Length - 1);
			buffer.Append("]");

			return buffer.ToString();
		}

		/// <summary>
		/// Concatenates all properties of a given object into a string.
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static string PropertiesToString(object o) {
			StringBuilder buffer = new StringBuilder();

			buffer.Append("[");
			foreach (PropertyInfo i in o.GetType().GetProperties()) {
				buffer.Append(i.Name + "=" + i.GetValue(o, null) + ",");
			}
			buffer.Length = Math.Max(1, buffer.Length - 1);
			buffer.Append("]");

			return buffer.ToString();
		}

		/// <summary>
		/// Replace urls in string with a href references. Use method 
		/// 'SimpleUrlReplacer' for a simple match evaluator replacing an url
		/// with a raw a href tag.
		/// </summary>
		/// <example>
		/// <![CDATA[StringUtils.ReplaceUrls("Please visit http://www.iquomi.com/ for more information.", delegate(Match m) { return "<a href=\"" + m.Groups[0].Value + "\">" + m.Groups[0].Value + "</a>"; });]]>
		/// </example>
		/// <param name="stringWithUrls"></param>
		/// <param name="urlReplacer"></param>
		/// <returns></returns>
		public static string ReplaceUrls(string stringWithUrls, MatchEvaluator urlReplacer) {
			return Regex.Replace(stringWithUrls, @"(https?|ftp|news)(:\/\/[-_.!~*'()a-zA-Z0-9;\/?:\@&=+\$,%#]+)", urlReplacer, RegexOptions.IgnoreCase);
		}

		public static string SimpleUrlReplacer(Match match) {
			return "<a href=\"" + match.Groups[0].Value + "\">" + match.Groups[0].Value + "</a>";
		}
	}
}