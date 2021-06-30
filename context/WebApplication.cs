using System;
using System.Web;

namespace context
{
	/// <summary>
	/// Summary description for WebApplication.
	/// </summary>
	public class WebApplication : IApplication
	{
		private HttpApplicationState Application
		{
			get
			{
				return HttpContext.Current.Application;
			}
		}

		void IApplication.add(string key, object item)
		{
			this.Application.Add(key, item);
		}

		void IApplication.remove(string key)
		{
			this.Application.Remove(key);
		}

		object IApplication.getItem(string key)
		{
			return this.Application[key];
		}

		void IApplication.setItem(string key, object item)
		{
			this.Application[key] = item;
		}
	}
}
