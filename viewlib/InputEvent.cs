using System;
using context;

namespace icon.spike
{
	/// <summary>
	/// Represents a unique input event (eg, a button click or following a link)
	/// that a view can raise - and whether that event is allowed.
	/// </summary>
	public class InputEvent
	{
		private string name;
		private bool enabled = false;

		public InputEvent(string name)
		{
			this.name = name;			
			this.enabled = isAllowed();
		}

		public bool isEnabled()
		{
			return this.enabled;
		}

		public bool IsEnabled
		{
			get { return isEnabled(); }
		}

		public string getName()
		{
			return this.name;
		}

		public string Name
		{
			get { return getName(); }
		}


		public void disable()
		{
			enabled = false;
		}

		public void enable()
		{
			enabled = true;
		}
	
		private bool isAllowed()
		{
			ISession session = AbstractContext.Current.Session;
			icon.spike.User user = (icon.spike.User)session.getItem("user");
			if (user != null)
			{
				return user.hasPermission(this);
			}
			else
			{
				return false;
			}
		}
	}
}
