using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Summary description for DateCriteriaView.
	/// </summary>
	public class DateCriteriaView : AbstractView
	{

		private DateTime from;
		private DateTime to;
		private string selectedField;
		private ArrayList dateFields = new ArrayList();

		public DateCriteriaView(string name, ArrayList dateFields) : base(name)
		{
			foreach (FieldDef field in dateFields)
			{
				this.dateFields.Add(((ICloneable)field).Clone());
			}
			// by default, the first field is selected
			if (dateFields.Count > 0)
			{
				this.selectedField = ((FieldDef)this.dateFields[0]).Name;
			}
		}

		public DateTime From
		{
			get
			{
				return from;
			}
			set
			{
				from = value;
			}
		}

		public DateTime To
		{
			get
			{
				return to;
			}
			set
			{
				to = value;
			}
		}

		public string SelectedField
		{
			get
			{
				return selectedField;
			}
			set
			{
				//check field exists in dateFields?				
				selectedField = value;
			}
		}

		public ArrayList DateFields
		{
			get
			{
				return dateFields;
			}
		}

		public override void unloadSubViews(){}
	}
}
