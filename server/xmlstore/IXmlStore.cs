#region Using directives

using System;

using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Store {
	/// <summary>
	/// Summary description for IXmlStore.
	/// </summary>
	public interface IXmlStore {
		ContentDocument ContentDocument { get; }
		RoleListDocument RoleListDocument { get; }
		SystemDocument SystemDocument { get; }
		NotifyListDocument NotifyListDocument { get; }
		
		InsertResponseType Insert(SubjectType subject, InsertRequestType request);
		QueryResponseType Query(SubjectType subject, QueryRequestType request);
		ReplaceResponseType Replace(SubjectType subject, ReplaceRequestType request);
		DeleteResponseType Delete(SubjectType subject, DeleteRequestType request);
		UpdateResponseType Update(SubjectType subject, UpdateRequestType request);
	}
}