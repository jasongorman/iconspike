using System;

namespace icon.spike
{
	/// <summary>
	/// Summary description for FieldDef.
	/// </summary>
	public enum FieldType
	{
		STRING,
		DATE
	}

	public class FieldDef : ICloneable
	{
		private string name;
		private FieldType type;

		public FieldDef(string name, FieldType type)
		{
			this.name = name;
			this.type = type;
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public FieldType FieldType
		{
			get
			{
				return type;
			}
		}

		Object ICloneable.Clone()
		{
			return new FieldDef(this.Name, this.FieldType);
		}


	}
}
