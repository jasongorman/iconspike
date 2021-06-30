using System;
using System.IO;
using System.Xml;
using TidyCOM;

namespace context
{
	/// <summary>
	/// Fake response object where we can write output HTML or XML
	/// and query the output afterwards in test assertions.
	/// </summary>
	public class TestResponse : IResponse
	{
		private Stream outputStream = new MemoryStream();
		private string contentType = "text/html";

		Stream IResponse.OutputStream	
		{
			get
			{
				return outputStream;
			}
		}

		string IResponse.ContentType 
		{
			get
			{
				return contentType;
			}
			set
			{
				contentType = value;
			}
		}

		/* do nothing because we want to keep the contents of the stream
			for testing. */
		void IResponse.end()
		{
			//outputStream.Close();
		}

		
		public XmlNode toXmlNode()
		{	
			XmlDocument doc = new XmlDocument();
			string xhtml = this.toXhtml(this.ToString());			
			doc.LoadXml(xhtml);
			return doc.DocumentElement;
		}

		// not well-formed XHTML produced by MSXML transformer!!!
		private string toXhtml(string html)
		{
			ITidyObject TidyObj = new TidyObjectClass();	
			TidyObj.Options.Doctype = "omit";	
			TidyObj.Options.OutputXhtml = true;			
			return TidyObj.TidyMemToMem(html);
		}
		public override string ToString()
		{
			StreamReader reader = new StreamReader(outputStream);
			outputStream.Position = 0;	
			string s = reader.ReadToEnd();			
			return s;
		}
	}
}
