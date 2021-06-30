using System;
using NUnit.Framework;
using icon.spike;
using context;

namespace NUnitTests
{
	/// <summary>
	/// Summary description for ControllerTest.
	/// </summary>
	/// 
	[TestFixture()]
	public class ControllerTest
	{
		[SetUp()]
		public void setup()
		{
			Utility.setUpContext();
		}

		[Test()]
		public void TestShowBasicSearchHandler()
		{
			Controller.ShowBasicSearchHandler(null);

			AbstractView view = ViewCache.getCurrent();

			Assertion.Assert(view.GetType().Name == "BasicSearchView");

		}
	}
}
