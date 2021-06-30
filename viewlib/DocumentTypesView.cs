using System;
using System.Collections;

namespace icon.spike
{
	/// <summary>
	/// Summary description for DocumentTypesView.
	/// </summary>
	public class DocumentTypesView : AbstractView
	{
		private Hashtable documentTypeViews = new Hashtable();

		public DocumentTypesView(string name, string[] documentTypes) : base(name)
		{
			foreach (string docType in documentTypes)
			{
				DocumentTypeView dtview = new DocumentTypeView(this.Name + "." + docType, docType, false);
				documentTypeViews.Add(docType, dtview);
			}
		}

		public Hashtable DocumentTypeViews
		{
			get
			{
				return documentTypeViews;
			}

			set
			{
				documentTypeViews = value;
			}
		}

		public override void unloadSubViews()
		{
			foreach (DictionaryEntry de in documentTypeViews)
			{
				AbstractView view = (AbstractView)de.Value;
				ViewCache.unload(view);
			}
			documentTypeViews = null;
		}
	}
}
