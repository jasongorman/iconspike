using System;
using System.Collections.Specialized;
using context;


namespace icon.spike
{
	/// <summary>
	/// Synchronizes view state (sender) with posted data (HttpRequest args)
	/// and outputs HTML (or whatever) based on current view state (the I/O module)
	/// </summary>
	public class ViewAdaptor
	{        		

		public void synchronize(AbstractView sender)
		{			
			IRequest request = AbstractContext.Current.Request;	
			Synchroniser s = Synchroniser.GetSynchroniser(sender);
			s.Synchronise(sender, request.Params);
		}
		
		public void render(AbstractView output)
		{
			string url = "http://localhost/icon.spike/xsl/" + output.GetType().Name + ".xsl";
			XsltViewHandler handler = new XsltViewHandler(url);
			
			handler.handle(output);
			
		}
		
		
	}
}
