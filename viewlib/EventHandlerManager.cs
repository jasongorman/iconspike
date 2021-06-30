using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Manages a collection of concrete event handlers. If the event handler requested
	/// is not found it uses the default event.
	/// </summary>
	public class EventHandlerManager
	{
		public delegate void EventHandler(AbstractView sender);
		
		private static Hashtable eventHandlers;

		private static EventHandler defaultHandler;

		public EventHandlerManager()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static EventHandler getEventHandler(string name)
		{
			if (eventHandlers == null)
			{
				loadEventHandlers();
			}		
			
			EventHandler handler = null; 
			
			if (!(name == null))
			{
				handler = (EventHandler)eventHandlers[name];
			}
			
			if (handler == null)
			{
				handler = defaultHandler;
			}				
			
			return handler;
		}

		private static void loadEventHandlers()
		{
			eventHandlers = new Hashtable();
			Controller.registerHandlers();

		}

		public static void addHandler(string name, EventHandlerManager.EventHandler handler)
		{
			eventHandlers.Add(name, handler);
		}

		public static void setDefault(EventHandler defaultHandler)
		{
			EventHandlerManager.defaultHandler = defaultHandler;
		}
	}
}
