using System;
using System.Collections.Specialized;

namespace context
{
	/// <summary>
	/// Summary description for Request.
	/// </summary>
	public interface IRequest
	{	
		string Item(string key);
		NameValueCollection Params{get;}
	}
}
