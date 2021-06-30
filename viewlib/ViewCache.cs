using System;
using context;

namespace icon.spike
{
	/// <summary>
	/// Responsibility for storing and retrieving references to views
	/// in session or application state, as well as keeping track of which
	/// is the current view (the view to be rendered.
	/// </summary>
	public class ViewCache
	{		

		public static AbstractView getView(string id)
		{
			AbstractView view;
			ISession session = AbstractContext.Current.Session;
			view = (AbstractView)session.getItem(id);

			if (view == null)
			{
				IApplication app = AbstractContext.Current.Application;
				view = (AbstractView)app.getItem(id);
			}

			return view;
		}

		public static void addSessionView(AbstractView view)
		{
			ISession session = AbstractContext.Current.Session;
			session.add(view.getName(), view);
		}

		public static void addApplicationView(AbstractView view)
		{
			IApplication app = AbstractContext.Current.Application;
			app.add(view.getName(), view);
		}

		public static void setCurrent(AbstractView view)
		{
			ISession session = AbstractContext.Current.Session;
			session.setItem("currentview", view);
		}

		public static AbstractView getCurrent()
		{
			return (AbstractView)AbstractContext.Current.Session.getItem("currentview");
		}

		// called by the views themselves in the AbstractView::close() method
		public static void unload(AbstractView view)
		{
			AbstractContext.Current.Session.remove(view.getName());
			AbstractContext.Current.Application.remove(view.getName());
		}

	}
}
