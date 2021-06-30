using System;
using System.Collections;
using context;

namespace icon.spike
{
	/// <summary>
	/// Makes sure that the posted data matches the state ofthe abstract view that raised the incoming event (sender)
	/// </summary>
	public class SynchronizeViewFilter : InterceptingFilter
	{
		private InterceptingFilter next;

		void InterceptingFilter.filter(Hashtable args)
		{			
			
			IRequest request = AbstractContext.Current.Request;
			string senderId = request.Item("sender");
			AbstractView sender = null;

			if (senderId != null)
			{
				sender = ViewCache.getView(senderId);

				if (!(sender == null))
				{
					ViewAdaptor adaptor = ViewAdaptorFactory.getAdaptor(sender);				
					adaptor.synchronize(sender);
				}
			}

			args.Add("sender", sender);			

			if (!(this.next == null))
			{
				next.filter(args);
			}
		}

		void InterceptingFilter.setNext(InterceptingFilter next)
		{
			this.next = next;
		}

		InterceptingFilter InterceptingFilter.getNext()
		{
			return this.next;
		}
	
	}
}
