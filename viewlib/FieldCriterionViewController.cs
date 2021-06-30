using System;

namespace viewlib
{
	/// <summary>
	/// Page controller for FieldCriterionView
	/// </summary>
	public class FieldCriterionViewController
	{
		// concrete event handler for 'insertafter' input event
		public static void InsertAfter(AbstractView sender)
		{
			FieldCriterionView view = (FieldCriterionView)sender;
			view.insertAfter();
		}

		// register concrete handlers with EventHandlerManager.
		// don't forget to call from EventHandlerManager::loadEventHandlers()
		public static void registerHandlers()
		{					
			EventHandlerManager.addHandler("insertafter", new EventHandlerManager.EventHandler(InsertAfter));		
		}
	}
}
