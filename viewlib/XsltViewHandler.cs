using System;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
using context;

namespace icon.spike
{
	/// <summary>
	/// Transforms the XML representation of a view using XSLT and writes
	/// it to the output stream of the HttpResponse
	/// </summary>
	public class XsltViewHandler
	{
		private XslTransform transform;
		
		public XsltViewHandler(string url)
		{
			loadXsl(url);
		}

		private void loadXsl(string url)
		{
			transform = new XslTransform();

			try
			{
				transform.Load(url);				
			}
			catch (Exception e)
			{
				System.Console.Write(e.Message);
			}


		}

		public void handle(AbstractView view)
		{
			// for debugging loads every time			
			ViewSerializer serializer = ViewSerializer.getSerializer(view.GetType());
			XmlNode node = serializer.serialize(view);
			IResponse response = AbstractContext.Current.Response;			
			Stream output = response.OutputStream;			
			transform.Transform((IXPathNavigable)node, null, output);
			response.end();
		}

		public void handleNoXslt(AbstractView view)
		{
			// for debugging loads every time			
			ViewSerializer serializer = ViewSerializer.getSerializer(view.GetType());
			XmlNode node = serializer.serialize(view);
			IResponse response = AbstractContext.Current.Response;			
			Stream output = response.OutputStream;			
			XmlTextWriter writer = new XmlTextWriter(output, System.Text.Encoding.UTF8);
			node.WriteContentTo(writer);
			response.ContentType = "text/xml";
			writer.Flush();
			response.end();
		}
	}
}
