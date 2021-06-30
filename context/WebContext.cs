using System;

namespace context
{
	/// <summary>
	/// Summary description for WebContext.
	/// </summary>
	public class WebContext : AbstractContext
	{
		private IRequest request = new WebRequest();
		private ISession session = new WebSession();
		private IApplication application = new WebApplication();
		private IResponse response = new WebResponse();

		public WebContext()
		{
			AbstractContext.Current = this;
		}

		public override IRequest Request
		{
			get
			{
				return request;
			}
		}

		public override ISession Session
		{
			get
			{
				return session;
			}
		}

		public override IApplication Application
		{
			get
			{
				return application;
			}
		}

		public override IResponse Response
		{
			get
			{
				return response;
			}
		}
	}
}
