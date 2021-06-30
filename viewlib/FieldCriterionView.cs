using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Summary description for FieldCriterionView.
	/// </summary>
	public class FieldCriterionView : AbstractView
	{
		private string comparisonOperator;
		private string terms;
		private string selectedField;	
		//private ArrayList fieldDefs;

		public FieldCriterionView(string name, string comparisonOperator, string selectedField, string terms) : base(name)
		{
			this.comparisonOperator = comparisonOperator;
			this.terms = terms;
//			this.fieldDefs = fieldDefs;
			this.selectedField = selectedField;
		}

		public string ComparisonOperator
		{
			get
			{
				return comparisonOperator;
			}
			set
			{
				comparisonOperator = value;
			}
		}

		public string Terms
		{
			get
			{
				return terms;
			}
			set
			{
				terms = value;
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
				selectedField = value;
			}
		}

//		public ArrayList FieldDefs
//		{
//			get
//			{
//				return fieldDefs;
//			}
//		}

		public override void unloadSubViews(){}
	}
}
