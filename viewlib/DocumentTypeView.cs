using System;

namespace icon.spike
{
	/// <summary>
	/// Summary description for DocumentType.
	/// </summary>
	public class DocumentTypeView : AbstractView
	{
		//private string name;
		private bool selected;
		private string caption;

		public DocumentTypeView(string name, string caption, bool selected) : base(name)
		{
			this.name = name;
			this.selected = selected;
			this.caption = caption;
		}		

		public bool Selected
		{
			get
			{
				return selected;
			}
			set
			{
				selected = value;
			}
		}

		public string Caption
		{
			get
			{
				return caption;
			}			
		}

		public override void unloadSubViews(){}
	}
}
