using System;

namespace Silanis.ESL.SDK
{
	public class Field
	{

        public Field(){
            Style = FieldStyle.BOUND_DATE;
        }
		public string Id {
			get;
			set;
		}

		public double Width {
			get;
			set;
		}

		public double Height {
			get;
			set;
		}

		public FieldStyle Style {
			get;
			set;
		}

		public double X {
			get;
			set;
		}

		public double Y {
			get;
			set;
		}

		public int Page {
			get;
			set;
		}

		public string Binding
		{
			get
			{
				return FieldStyleUtility.Binding (Style);
			}
		}

		public FieldValidator Validator {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public bool Extract {
			get;
			set;
		}

		public string Value {
			get;
			set;
		}

        public TextAnchor TextAnchor {
            get;
            set;
        }
	}
}