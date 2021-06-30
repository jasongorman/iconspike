using System;
using System.Collections;

namespace context
{
	/// <summary>
	/// Summary description for TestApplication.
	/// </summary>
	public class TestApplication : IApplication
	{
		private Hashtable variables = new Hashtable();

		void IApplication.add(string key, object item)
		{
			variables.Add(key, item);
		}

		void IApplication.remove(string key)
		{
			variables.Remove(key);
		}

		object IApplication.getItem(string key)
		{
			return variables[key];
		}

		void IApplication.setItem(string key, object item)
		{
			variables[key] = item;
		}
	}
}
