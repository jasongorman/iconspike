using System;
using System.Collections.Specialized;

namespace context
{
	/// <summary>
	/// Summary description for TestRequest.
	/// </summary>
	public class TestRequest : IRequest
	{
		private NameValueCollection parameters = new NameValueCollection();

		string IRequest.Item(string key)
		{
			return parameters[key];
		}

		NameValueCollection IRequest.Params
		{
			get
			{
				return parameters;
			}
		}
		
	}
}
