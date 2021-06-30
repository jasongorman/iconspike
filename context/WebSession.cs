using System;
using System.Web;
using System.Web.SessionState;

namespace context
{
	/// <summary>
	/// Summary description for WebSession.
	/// </summary>
	public class WebSession : ISession
	{
		private HttpSessionState Session
		{
			get
			{
				return HttpContext.Current.Session;
			}
		}

		void ISession.add(string key, object item)
		{
			this.Session.Add(key, item);
		}

		void ISession.remove(string key)
		{
			this.Session.Remove(key);
		}

		object ISession.getItem(string key)
		{
			return this.Session[key];
		}

		void ISession.setItem(string key, object item)
		{
			this.Session[key] = item;
		}
	}
}
