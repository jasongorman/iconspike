using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Abstraction for filters that are "chained" up as a linked list
	/// and handle requests in turn.
	/// </summary>
	public interface InterceptingFilter
	{
		void filter(Hashtable args);
		InterceptingFilter getNext();
		void setNext(InterceptingFilter next);
	}
}
