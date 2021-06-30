using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Needed if permissions are checked before handling an event (not currently in use)
	/// </summary>
	public class AccessControlFilter : InterceptingFilter
	{
		private InterceptingFilter next;

		void InterceptingFilter.filter(Hashtable args)
		{
			
			/* check that user has permission to make request:
			 * if Yes then allow to continue. If No then force
			 * "not permitted" event.
			 */

			
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
