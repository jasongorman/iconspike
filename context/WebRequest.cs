using System;
using System.Web;
using System.Collections.Specialized;

namespace context
{
	/// <summary>
	/// Summary description for WebRequest.
	/// </summary>
	public class WebRequest : IRequest
	{
		private HttpRequest HttpRequest
		{
			get
			{
				return HttpContext.Current.Request;
			}
		}

			
		string IRequest.Item(string key)
		{			
			return this.HttpRequest[key];			
		}

		NameValueCollection IRequest.Params
		{
			get
			{
				return this.HttpRequest.Params;
			}
		}

		public void Add(string key, string _value)
		{
			throw new ApplicationException("Cannot add new values to Web Request");
		}	
		
	}
}
