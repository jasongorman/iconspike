using System;

namespace icon.spike
{
	/// <summary>
	/// Summary description for LoginView.
	/// </summary>
	public class LoginView : AbstractView
	{
		private string userId = "";
		private string password = "";

		public LoginView(string name) : base(name)
		{
			events.Add(new InputEvent("login"));		
		}
		
		public override void unloadSubViews(){}

		public void setUserId(string userId)
		{
			this.userId = userId;
		}

		public string getUserId()
		{
			return this.userId;
		}

		public string UserId
		{
			get { return getUserId(); }
			set { setUserId(value); }
		}

		public string getPassword()
		{
			return this.password;
		}

		public void setPassword(string password)
		{
			this.password = password;
		}

		public string Password
		{
			get { return getPassword(); }
			set { setPassword(value); }
		}

	}
}
