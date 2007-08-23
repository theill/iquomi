using System;
using System.Runtime.Serialization;

namespace Commanigy.Iquomi.Services {
	/// <summary>
	/// Controls how a response to this request is generated and delivered. 
	/// Valid values include:
	/// 
	/// <dl>
	///		<dt><b>always</b></dt>
	///		<dd>Always generate a response message.</dd>
	/// 
	///		<dt><b>never</b></dt>
	///		<dd>Never generate a response message.</dd>
	/// 
	///		<dt><b>faultOnly</b></dt>
	///		<dd>Generate a response message, but only if the request message 
	///		results in a fault message.</dd>
	/// </dl>
	/// 
	/// </summary>
	[Serializable]
	public enum GenResponseType {
		Always,
		Never,
		FaultOnly
	}
}