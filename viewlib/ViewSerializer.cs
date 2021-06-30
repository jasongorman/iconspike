using System;
using System.Collections;
using System.Xml;

namespace icon.spike
{
	/// <summary>
	/// Writes view state in XML + any subviews (recursively)
	/// </summary>
	public class ViewSerializer
	{		

		public static ViewSerializer getSerializer(System.Type viewType)
		{
			return new ViewSerializer();
		}		

		public XmlNode serialize(AbstractView view)
		{
			XmlDocument doc = new XmlDocument();
			XmlNode root = doc.CreateElement("root");
			doc.AppendChild(root);
			XmlBuilder builder = XmlBuilder.GetBuilder(view);
			builder.BuildXml(view, root);
			//XmlDirector.Render(view, root, "");
			return doc;
		}		
		
	}
}
