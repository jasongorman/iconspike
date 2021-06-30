using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using context;

namespace icon.spike
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(Object sender, EventArgs e)
		{
			createContext();
			InterceptingFilter filterChain = new AuthenticationFilter();
			InterceptingFilter synchFilter = new SynchronizeViewFilter();
			filterChain.setNext(synchFilter);
			InterceptingFilter eventFilter = new EventHandlerFilter();
			synchFilter.setNext(eventFilter);
			eventFilter.setNext(new RenderViewFilter());
			HttpContext.Current.Application.Add("filterchain", filterChain);
			createUsers();
		}
 
		private void createContext()
		{
			AbstractContext ctx = new WebContext();
		}

		protected void Session_Start(Object sender, EventArgs e)
		{			

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
		private void createUsers()
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

