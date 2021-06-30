using System;

namespace context
{
	/// <summary>
	/// Abstraction for HttpContext. Current context can be set in Application_OnStart() event
	/// handler in ASP.NET application or fake context can be set up in [SetUp()] in test fixture.
	/// </summary>
	public abstract class AbstractContext
	{
		private static AbstractContext ctx;		

		public static AbstractContext Current
		{
			get
			{
				return ctx;
			}
			set
			{
				ctx = value;
			}
		}

		public abstract IRequest Request
		{
			get;			
		}

		public abstract IResponse Response
		{
			get;			
		}

		public abstract IApplication Application
		{
			get;			
		}

		public abstract ISession Session
		{
			get;			
		}
//
//		public abstract Server Server
//		{
//			get;			
//		}

	}
}
