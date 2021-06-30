using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using context;
using System.Diagnostics;

namespace icon.spike.tests
{
	/// <summary>
	/// Summary description for TestContext.
	/// </summary>
	public class TestContext : System.Web.UI.Page
	{
		private int tests = 0;
		private int fails = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			testRequestAdd();
			testRequestItem();
			testRequestItems();
			testContextCreate();
			testSessionAdd();
			Response.Write("Tests: " + tests + " Fails: " + fails);
		}

		private void testRequestAdd()
		{
			tests++;

			bool result = false;

			try
			{
				WebRequest req = new WebRequest();
				req.Add("somevalue", "somevalue");	
			}
			catch(ApplicationException)
			{
				result = true;
			}

			Assert(result);
		}

		private void testRequestItem()
		{
			tests++;
			IRequest req = new WebRequest();
			string s = req.Item("name");
			Assert(s == "jason");
		}
		
		private void testRequestItems()
		{
			tests++;
			IRequest req = new WebRequest();
			NameValueCollection items = req.Params;
			Assert(items == Request.Params);
		}

		private void testContextCreate()
		{
			AbstractContext ctx = new WebContext();
			Assert(ctx == AbstractContext.Current);
			tests++;
		}

		private void testSessionAdd()
		{
			ISession session = AbstractContext.Current.Session;
			session.add("name", "jason");
			string name = session.getItem("name").ToString();
			Assert(name == "jason");
			tests++;
		}

		private void Assert(bool assertion)
		{
			if (!assertion)
			{
				fails++;
			}

		}

	
			

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
