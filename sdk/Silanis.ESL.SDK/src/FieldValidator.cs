using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class FieldValidator
	{
        private List<String> options = new List<String>();

		public string Regex {
			get;
			set;
		}

		public int MinLength {
			get;
			set;
		}

		public int MaxLength {
			get;
			set;
		}

		public string Message {
			get;
			set;
		}

        public int ErrorCode
        {
            get;
            set;
        }

		public bool Required {
			get;
			set;
		}

        public List<string> Options
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
            }
        }

        public void AddOption(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Argument cannot be null");
            }

            options.Add(value);

        }

        public void AddOptions (IList<string> options)
        {
            this.options.AddRange (options);
        }
	}
}