#region Using directives

using System;
using System.Text;
using System.Security.Cryptography;

#endregion

namespace Commanigy.Iquomi.Api {
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public class Account  {

		private int id;
		public int Id {
			get { return id; }
			set { id = value; }
		}

		private int ownerAccountId;
		public int OwnerAccountId {
			get { return ownerAccountId; }
			set { ownerAccountId = value; }
		}

		private int groupId;
		public int GroupId {
			get { return groupId; }
			set { groupId = value; }
		}

		private string iqid;
		public string Iqid {
			get { return iqid; }
			set { iqid = value; }
		}

		private string email;
		public string Email {
			get { return email; }
			set { email = value; }
		}

		private string password;
		public string Password {
			get { return password; }
			set { password = value; }
		}

		private string ipAddress;
		public string IpAddress {
			get { return ipAddress; }
			set { ipAddress = value; }
		}

		public string ApplicationID {
			get {
				SHA1 sha = new SHA1CryptoServiceProvider();
				byte[] hash = sha.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.Iqid + ':' + this.Password));
				sha.Clear();

				StringBuilder buffer = new StringBuilder();
				foreach (byte hashByte in hash) {
					buffer.Append(String.Format("{0:x2}", hashByte));
				}

				return buffer.ToString();
			}
		}

		public Account() {
			
		}
		
		public Account(string email, string password) {
			Email = email;
			Password = password;
		}
	}
}