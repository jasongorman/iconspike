using System;

namespace context
{
	/// <summary>
	/// Summary description for TestContext.
	/// </summary>
	public class TestContext : AbstractContext
	{
		private IRequest request = new TestRequest();
		private ISession session = new TestSession();
		private IApplication application = new TestApplication();
		private IResponse response = new TestResponse();

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
