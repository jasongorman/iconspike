using System;
using System.Collections;

namespace context
{
	/// <summary>
	/// Summary description for Application.
	/// </summary>
	public interface IApplication
	{
		void add(string key, object item);
		object getItem(string key);
		void setItem(string key, object item);
		void remove(string key);

	}
}
