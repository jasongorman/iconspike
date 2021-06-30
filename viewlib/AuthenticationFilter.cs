using System;
using System.Collections;
using context;

namespace icon.spike
{
	/// <summary>
	/// Checks the user is logged in before allowing any other kinds
	/// of event to be handled. First in the filter chain.
	/// </summary>
	public class AuthenticationFilter : InterceptingFilter
	{
		private InterceptingFilter next;

		public AuthenticationFilter()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		void InterceptingFilter.filter(Hashtable args)
		{
			
			ISession session = AbstractContext.Current.Session;
			icon.spike.User user = (icon.spike.User)session.getItem("user");
			
			IRequest request = AbstractContext.Current.Request;
			string eventName = request.Item("event");			

			if (user == null && !(eventName == "login"))
			{
				// show login view and skip processing
				eventName = "showlogin";
			}			

			args.Add("event", eventName);


			if (next != null)
			{
				next.filter(args);
			}
		}

		InterceptingFilter InterceptingFilter.getNext()
		{
			return this.next;
		}

		void InterceptingFilter.setNext(InterceptingFilter next)
		{
			this.next = next;
		}
	}
}
