#region Using directives

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Utility {
	public class ObjectUtils {
		public ObjectUtils() {

		}

		public static string Dump(object o) {
			if (o == null) {
				return "<dump />";
			}

			StringBuilder buffer = new StringBuilder();

			buffer.Append("<dump name=\"" + o.GetType().FullName + "\">");

			buffer.Append("<fields>");
			foreach (FieldInfo i in o.GetType().GetFields()) {
				buffer.Append("<field name=\"" + i.Name + "\">" + i.GetValue(o) + "</field>");
			}
			buffer.Append("</fields>");

			buffer.Append("<properties>");
			foreach (PropertyInfo i in o.GetType().GetProperties()) {
				buffer.Append("<property name=\"" + i.Name + "\">" + i.GetValue(o, null) + "</property>");
			}
			buffer.Append("</properties>");

			buffer.Append("</dump>");

			return buffer.ToString();
		}
	}
}