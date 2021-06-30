using System;
using System.Collections;
using System.Xml;

namespace icon.spike
{
	/// <summary>
	/// The last in the chain of intercepting filters, renders
	/// the current view to the HttpResponse as HTML (or whatever)
	/// </summary>
	public class RenderViewFilter : InterceptingFilter
	{
		private InterceptingFilter next;

		void InterceptingFilter.filter(Hashtable args)
		{
			AbstractView current = ViewCache.getCurrent();
			ViewAdaptor adaptor = ViewAdaptorFactory.getAdaptor(current);
			adaptor.render(current);
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
