using System;
using context;
using icon.spike;

namespace NUnitTests
{
	/// <summary>
	/// Summary description for Utility.
	/// </summary>
	public class Utility
	{
		public static void setUpContext()
		{
			AbstractContext ctx = new TestContext();
			AbstractContext.Current = ctx;
		}

		public static InterceptingFilter buildFilterChain()
		{
			InterceptingFilter filterChain = new AuthenticationFilter();
			InterceptingFilter synchFilter = new SynchronizeViewFilter();
			filterChain.setNext(synchFilter);
			InterceptingFilter eventFilter = new EventHandlerFilter();
			synchFilter.setNext(eventFilter);
			eventFilter.setNext(new RenderViewFilter());
			return filterChain;
		}

		public static void setUpUsers()
		{			
			EventHandlerManager.EventHandler login = EventHandlerManager.getEventHandler("login");
			EventHandlerManager.EventHandler showLogin = EventHandlerManager.getEventHandler("showlogin");
			EventHandlerManager.EventHandler showView = EventHandlerManager.getEventHandler("showView");
			EventHandlerManager.EventHandler update = EventHandlerManager.getEventHandler("update");

			for (int i = 1; i <= 10; i++)
			{
				icon.spike.User user = icon.spike.User.createUser("user" + i.ToString(), "password" + i.ToString());
				user.grantPermission(login);
				user.grantPermission(showLogin);
				user.grantPermission(showView);
				user.grantPermission(update);
			}		
		}

	}
}
