using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// After the user is authenticated and the sender view has been synchronized
	/// with the posted view data then the input event itself is handled.
	/// </summary>
	public class EventHandlerFilter : InterceptingFilter
	{
		private InterceptingFilter next;
		
		void InterceptingFilter.filter(Hashtable args)
		{
			AbstractView sender = (AbstractView)args["sender"];
			string eventName = (string)args["event"];
			EventHandlerManager.EventHandler handler = EventHandlerManager.getEventHandler(eventName);
			handler(sender);

			if (!(next == null))
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
