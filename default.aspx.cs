using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace icon.spike
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class Default : System.Web.UI.Page
	{
		public Default()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			InterceptingFilter filterChain = (InterceptingFilter)HttpContext.Current.Application["filterchain"];
			Hashtable args = new Hashtable();
			args.Add("httpcontext", HttpContext.Current);
			filterChain.filter(args);
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
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
