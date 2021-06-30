using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Logical abstraction of physical views. Concrete views
	/// need to be kept in synch with the physical HTML views that the user sees, 
	/// which is done by the ViewAdaptor.
	/// 
	/// NB: this version of AbstractView does not have an errors collection as yet.
	/// </summary>
	public abstract class AbstractView
	{// you never know when a unique ID might be needed - not in use.
		protected Guid guid;
		// unique name at either session or application scope
		protected string name;
		// what events can be raised through this view
		protected ArrayList events = new ArrayList();
		// did the user do something silly?
		protected string message = "";

		protected AbstractView parent;

		public AbstractView(string name)
		{
			this.setNameAndGuid(name);
		}	
	
		public AbstractView(string name, AbstractView parent)
		{
			this.setNameAndGuid(name);
			this.parent = parent;
		}

		private void setNameAndGuid(string name)
		{
			this.guid = Guid.NewGuid();
			this.name = name;
		}


		public Guid getGuid()
		{
			return this.guid;
		}

		public Guid Guid
		{
			get { return getGuid(); }
		}

		public string getName()
		{
			return this.name;
		}

		public string Name
		{
			get { return getName(); }
		}

		public void close()
		{
			ViewCache.unload(this);
			this.unloadSubViews();
		}

		public abstract void unloadSubViews();

		public ArrayList getEvents()
		{
			return this.events;
		}

		public ArrayList Events
		{
			get { return getEvents(); }
		}

		public void setMessage(string message)
		{
			this.message = message;
		}

		public string getMessage()
		{
			return this.message;
		}

		public string Message
		{
			get { return getMessage(); }
			set { setMessage(value); }
		}

		public AbstractView Parent
		{
			get
			{
				return this.parent;
			}
		}
	}
}
