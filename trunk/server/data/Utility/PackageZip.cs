using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;

namespace Commanigy.Iquomi.Utility {
	/// <summary>
	/// Summary description for PackageZip.
	/// </summary>
	public class PackageZip {
		private PackageItem[] items_;

		public PackageZip(PackageItem[] items) {
			items_ = items;
		}

		public byte[] Zip() {
            
			string[] files = new string[items_.Length];
			for (int i = 0; i < items_.Length; i++) {
				files[i] = "c:\\tmp_" + i;
				FileStream fs = File.Create(files[i]);
				byte[] bytes = (byte[])items_[i].Data;
				fs.Write(bytes, 0, bytes.Length);
				fs.Close();
			}
			
			MemoryStream ms = new MemoryStream();
			ZipOutputStream s = new ZipOutputStream(ms);
            
			s.SetLevel(9); // 0 - store only to 9 - means best compression
            
			foreach (string file in files) {
				FileStream fs = File.OpenRead(file);
            	
				byte[] buffer = new byte[fs.Length];
				fs.Read(buffer, 0, buffer.Length);
				
				ZipEntry entry = new ZipEntry(file);
				s.PutNextEntry(entry);
				s.Write(buffer, 0, buffer.Length);
			}
            
			s.Finish();
			s.Close();
			
			return ms.GetBuffer();
		}
		
		public bool Unzip(byte[] bytes) {
			return true;
		}
	}
}