using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Summary description for BasicSearchView.
	/// </summary>
	public class BasicSearchView : AbstractView
	{
		private string contains = "";
		private string notContains = "";

		private AbstractView fieldCriteriaView;
		private AbstractView dateCriteriaView;
		private AbstractView documentTypesView;

		public BasicSearchView(string name, ArrayList fields, string[] documentTypes) : base(name)
		{
			ArrayList dateFields = new ArrayList();

			foreach (FieldDef field in fields)
			{
				if (field.FieldType == FieldType.DATE)
				{
					dateFields.Add(field);
				}
			}

			fieldCriteriaView = new FieldCriteriaView(this.name + ".fieldCriteriaView", fields);
			dateCriteriaView = new DateCriteriaView(this.name + ".dateCriteriaView", dateFields);			
			documentTypesView = new DocumentTypesView(this.name + ".documentTypesView", documentTypes);
		}

		public string Contains
		{
			get
			{
				return contains;
			}
			set
			{
				contains = value;
			}
		}

		public string NotContains
		{
			get
			{
				return notContains;
			}
			set
			{
				notContains = value;
			}
		}

		public AbstractView FieldCriteriaView
		{
			get
			{
				return fieldCriteriaView;
			}
		}

		public AbstractView DateCriteriaView
		{
			get
			{
				return dateCriteriaView;
			}
		}

		public AbstractView DocumentTypesView
		{
			get
			{
				return documentTypesView;
			}
		}

		public override void unloadSubViews()
		{
			fieldCriteriaView.close();
			fieldCriteriaView = null;
			dateCriteriaView.close();
			dateCriteriaView = null;
			documentTypesView.close();
			documentTypesView = null;
		}
	}
}
