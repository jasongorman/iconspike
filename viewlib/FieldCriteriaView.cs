using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Summary description for FieldCriteriaView.
	/// </summary>
	public class FieldCriteriaView : AbstractView
	{
		private ArrayList fieldDefs = new ArrayList();
		private Hashtable fieldCriterionViews = new Hashtable();

		public FieldCriteriaView(string name, ArrayList fieldDefs) : base(name)
		{
			foreach (FieldDef field in fieldDefs)
			{
				this.fieldDefs.Add(((ICloneable)field).Clone());
			}
		}

		public Hashtable FieldCriterionViews
		{
			get
			{
				return fieldCriterionViews;
			}
			set
			{
				fieldCriterionViews = value;
			}
		}

		public ArrayList FieldDefs
		{
			get
			{
				return fieldDefs;
			}
		}

		public override void unloadSubViews()
		{
			foreach (DictionaryEntry de in fieldCriterionViews)
			{
				FieldCriterionView view = (FieldCriterionView)de.Value;
				ViewCache.unload(view);
			}
			fieldCriterionViews = null;
		}		
	}
}
