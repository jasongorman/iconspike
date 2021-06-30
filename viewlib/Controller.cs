using System;
using System.Collections;
using context;

namespace icon.spike
{
	/// <summary>
	/// A convenient grouping of concrete event handlers. Controller::registerHandlers() is
	/// called by the EventHandlerManager when initialising the collection of concrete handlers.
	/// </summary>
	public class Controller
	{
		

				

		// by default there is no current view, so creates one (when the sender == null)
		public static void DefaultHandler(AbstractView sender)
		{
			
		}

		public static void LoginHandler(AbstractView sender)
		{
			LoginView login = (LoginView)sender;
			icon.spike.User user = icon.spike.User.getUser(login.getUserId());
			string message = "The user ID or mpassword you entered are incorrect. Please re-enter them and try again.";

			if (user == null)
			{
				login.setMessage(message);
			}
			else 
			{
				if (!user.passwordMatches(login.getPassword()))
				{
					login.setMessage(message);
				}
				else
				{
					ISession session = AbstractContext.Current.Session;
					session.add("user", user);
					login.close();	
					ShowBasicSearchHandler(sender);

				}
			}
			
		}

		public static void ShowLoginHandler(AbstractView sender)
		{
			LoginView login = new LoginView("login");
			ViewCache.addSessionView(login);
			ViewCache.setCurrent(login);
		}

		public static void ShowBasicSearchHandler(AbstractView sender)
		{
			
			BasicSearchView view = new BasicSearchView("myBasicSearchView", getFieldDefs(), getDocTypes());
			FieldCriteriaView fcv = (FieldCriteriaView)view.FieldCriteriaView;

			fcv.FieldCriterionViews.Add("fieldCriterionView1",new FieldCriterionView("FieldCriterionView1","Contains","Field1","bob"));
			fcv.FieldCriterionViews.Add("fieldCriterionView2",new FieldCriterionView("FieldCriterionView2","Contains","Field3","sue"));
			fcv.FieldCriterionViews.Add("fieldCriterionView3",new FieldCriterionView("FieldCriterionView3","Contains","Field4",""));

			foreach (DictionaryEntry de in fcv.FieldCriterionViews)			
			{
				AbstractView av = (AbstractView)de.Value;
				ViewCache.addSessionView(av);
			}

			ViewCache.addSessionView(view);
			ViewCache.setCurrent(view);
		}

		
		
		public static void UpdateViewHandler(AbstractView sender)
		{
			sender.setMessage("Your view has been updated!");
		}		

		public static void registerHandlers()
		{			
			
			EventHandlerManager.addHandler("login", new EventHandlerManager.EventHandler(LoginHandler));
			EventHandlerManager.addHandler("showlogin", new EventHandlerManager.EventHandler(ShowLoginHandler));
			EventHandlerManager.addHandler("showbasicsearch", new EventHandlerManager.EventHandler(ShowBasicSearchHandler));
			EventHandlerManager.addHandler("update", new EventHandlerManager.EventHandler(UpdateViewHandler));
			EventHandlerManager.setDefault(new EventHandlerManager.EventHandler(ShowBasicSearchHandler));
		
		}
		

		private static ArrayList getFieldDefs()
		{
			ArrayList fieldDefs = new ArrayList();
			
			for (int i = 0; i <= 4; i++)
			{
				fieldDefs.Add( new FieldDef("Field" + i.ToString(), FieldType.STRING));
			}

			for (int i = 5; i <= 9; i++)
			{
				fieldDefs.Add(new FieldDef("DateField" + i.ToString(), FieldType.DATE));
			}

			return fieldDefs;
		}

		private static string[] getDocTypes()
		{
			string[] types = {"All", "Nothing", "Scooby", "Doo", "Tripitaka", "Sandy", "Pigsy", "Blah", "Etc"};
			return types;
		}
	}
}
