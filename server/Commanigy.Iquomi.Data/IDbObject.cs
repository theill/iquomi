#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Commanigy.Iquomi.Data {
	public interface IDbObject<T> {
		T DbCreate();
		T DbRead();
		T DbUpdate();
		T DbDelete();
	}
}
