using System;
using System.Collections;
using System.Collections.Specialized;
using context;
using icon.spike;
using NUnit.Framework;

namespace NUnitTests
{
	/// <summary>
	/// Summary description for AuthenticationFilterTest.
	/// </summary>
	/// 
	[TestFixture()]
	public class AuthenticationFilterTest
	{

		[SetUp()]
		public void setup()
		{
			Utility.setUpContext();
		}

		/* not logged in so login view should be displayed. BasicSearchView
		 * should be displayed after successful login */
		[Test()]
		public void TestFilter()
		{			
			
			IRequest request = AbstractContext.Current.Request;
			InterceptingFilter auth = Utility.buildFilterChain();
			Utility.setUpUsers();
			Hashtable args = new Hashtable();
			auth.filter(args);
			AbstractView current = ViewCache.getCurrent();
			Assertion.Assert(current.GetType().Name == "LoginView");
			request.Params.Add("event", "login");
			request.Params.Add("sender", "login");
			request.Params.Add("login.UserId", "user1");
			request.Params.Add("login.Password", "password1");
			args.Clear();
			auth.filter(args);

			Assertion.Assert(ViewCache.getCurrent().GetType().Name == "BasicSearchView");
			Assertion.Assert(AbstractContext.Current.Session.getItem("user") != null);

			// reset users					
			icon.spike.User.getUsers().Clear();
		}
		
	}
}
