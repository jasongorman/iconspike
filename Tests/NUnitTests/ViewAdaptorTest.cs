using System;
using System.Collections;
using System.Collections.Specialized;
using NUnit.Framework;
using context;
using icon.spike;

namespace NUnitTests
{
	/// <summary>
	/// Summary description for ViewAdaptorTest.
	/// </summary>
	/// 
	[TestFixture()]
	public class ViewAdaptorTest
	{
		[SetUp()]
		public void setup()
		{
			Utility.setUpContext();
		}
	
		[Test()]
		public void TestSyncronizeLoginView()
		{
			// create sender view
			LoginView login = new LoginView("login");
			ViewCache.addSessionView(login);
			ViewCache.setCurrent(login);

			IRequest request = (TestRequest)AbstractContext.Current.Request;

			NameValueCollection prms = request.Params;
			prms.Add("event", "login");
			prms.Add("sender", "login");
			prms.Add("login.UserId", "user1");
			prms.Add("login.Password", "password1");

			Hashtable args = new Hashtable();

            InterceptingFilter sync = new SynchronizeViewFilter();
			
			sync.filter(args);

			LoginView sender = (LoginView)args["sender"];

			Assertion.Assert(sender.UserId == "user1");
			Assertion.Assert(sender.Password == "password1");

		}

		
	
	}
}
