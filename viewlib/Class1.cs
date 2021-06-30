using System;

namespace viewlib
{
	/// <summary>
	/// Logical abstraction of Field Criteria view
	/// </summary>
	public class FieldCriteriaView : AbstractView
	{
		private ArrayList availableFields;
		private FieldDef defaultField;
		private string contains;
		private string notContains;
		private string defaultComparisonOperator = CONTAINS;
		private ArrayList fieldCriterionViews = new ArrayList();

		private const string CONTAINS = "Contains";
		private const string CONTAINS = "Equals";
		private const string CONTAINS = "Starts With";
		
		public FieldCriteriaView(string name, 
			ArrayList availableFields, 
			FieldDef defaultField) : base(name)
		{
			this.availableFields = availableFields;
			this.defaultField = defaultField;
		}

		/*
		 * 
		 * etc etc etc
		 * */		
	}
}
