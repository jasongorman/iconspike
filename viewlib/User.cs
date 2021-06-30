using System;
using System.Collections;
using context;

namespace icon.spike
{
	/// <summary>
	/// Used for authentication and for keeping track of permissions
	/// </summary>
	public class User
	{
		private string userId;
		private string password;
		// collection of event handlers this user can use.
		private ArrayList permissions = new ArrayList();

		private static Hashtable users = new Hashtable();

		public User(string userId, string password)
		{
			this.userId = userId;
			this.password = password;
		}

		public string getUserId()
		{
			return userId;
		}

		public bool passwordMatches(string password)
		{
			return (password == this.password);
		}

		public static User getUser(string userId)
		{
			return (User)users[userId];
		}

		public static User createUser(string userId, string password)
		{
			User user = new User(userId, password);
			users.Add(userId, user);
			return user;
		}

		public void grantPermission(EventHandlerManager.EventHandler handler)
		{
			if (!(permissions.Contains(handler)))
			{
				permissions.Add(handler);
			}
		}

		public bool hasPermission(InputEvent inputEvent)
		{
			EventHandlerManager.EventHandler handler = EventHandlerManager.getEventHandler(inputEvent.getName());
			return (permissions.Contains(handler));
		}

		public static icon.spike.User getCurrent()
		{
			ISession session = AbstractContext.Current.Session;
			return (icon.spike.User)session.getItem("user");
		}

		public static Hashtable getUsers()
		{
			return users;
		}
	}
}
