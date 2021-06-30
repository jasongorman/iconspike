using System;
using context;
using icon.spike;
using NUnit.Framework;
using System.Xml;

namespace NUnitTests
{
	/// <summary>
	/// Summary description for XslViewHandlerTest.
	/// </summary>
	/// 
	[TestFixture()]
	public class XslViewHandlerTest
	{
		[SetUp()]
		public void setup()
		{
			Utility.setUpContext();
		}

		[Test()]
		public void TestHandle()
		{
			// set current view = BasicSearchView
			Controller.ShowBasicSearchHandler(null);

			ViewAdaptor adaptor = new ViewAdaptor();
			adaptor.render(ViewCache.getCurrent());

			TestResponse response = (TestResponse)AbstractContext.Current.Response;

			XmlNode node = response.toXmlNode();

			Assertion.Assert(node.Name == "html");
		}

	}
}
