using System;
using System.Web;
using System.IO;

namespace context
{
	/// <summary>
	/// Summary description for WebResponse.
	/// </summary>
	public class WebResponse : IResponse
	{
		private HttpResponse Response
		{
			get
			{

				return HttpContext.Current.Response;
			}
		}

		Stream IResponse.OutputStream	
		{
			get
			{
				return this.Response.OutputStream;
			}
		}

		string IResponse.ContentType 
		{
			get
			{
				return this.Response.ContentType;
			}
			set
			{
				this.Response.ContentType = value;
			}
		}

		
		void IResponse.end()
		{
			this.Response.End();
		}
		
	}
}
