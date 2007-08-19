#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization; 

#endregion

namespace Commanigy.Iquomi.Services.IqFavorites {
	/// <summary>
	/// Converts IE favorite files into Xml structure matching IqFavorites 
	/// schema.
	/// </summary>
	public class FavoriteConverter {
		public static string Convert(favoriteType f) {
			string fullpath = string.Format("{0}/{1}.url", 
				f.cat[0].@ref.Substring(1), f.title[0]);
			using (StreamWriter sw = new StreamWriter(fullpath)) {
				sw.WriteLine("URL={0}", f.url);
				sw.Flush();
			}
			return fullpath;
		}

		public static favoriteType Convert(string fullpath) {
			favoriteType f = new favoriteType();
			using (StreamReader reader = File.OpenText(fullpath)) {
				FileInfo fi = new FileInfo(fullpath);
				string path = fi.DirectoryName;
				string filename = fi.Name;

				string url = reader.ReadToEnd();
				url = url.Substring(url.IndexOf("URL=") + 4).Trim();

				f.title = new string[] { filename };
				f.url = url;
				
				catType ct = new catType();
				ct.@ref = "#" + path;
				f.cat = new catType[] { ct };

			}

			return f;
		}

		public static XmlElement ConvertToXml(favoriteType favorite) {
			XmlSerializer serializer = new XmlSerializer(favorite.GetType());
			StringWriter sw = new StringWriter();
			XmlWriter w = new XmlTextWriter(sw);
			serializer.Serialize(w, favorite);
			w.Flush();
			w.Close();
			
			XmlDocument d = new XmlDocument();
			d.LoadXml(sw.GetStringBuilder().ToString());
			return d.DocumentElement;
		}
	}
}
