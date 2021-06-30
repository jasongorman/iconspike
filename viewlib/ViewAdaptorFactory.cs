using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Maintains a collection of adaptors for concrete views, using
	/// the view's System.Type as a key for retrieving them
	/// </summary>
	public class ViewAdaptorFactory
	{
		
		public static ViewAdaptor getAdaptor(AbstractView view)
		{
			return new ViewAdaptor();
		}

		
	}
}
