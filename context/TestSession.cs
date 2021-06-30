using System;
using System.Collections;

namespace context
{
	/// <summary>
	/// Summary description for TestSession.
	/// </summary>
	public class TestSession : ISession
	{
		private Hashtable variables = new Hashtable();

		void ISession.add(string key, object item)
		{
			variables.Add(key, item);
		}

		void ISession.remove(string key)
		{
			variables.Remove(key);
		}

		object ISession.getItem(string key)
		{
			return variables[key];
		}

		void ISession.setItem(string key, object item)
		{
			variables[key] = item;
		}
	}
}
