using System;
using System.Collections.Generic;
namespace Silanis.ESL.SDK
{
    public class CustomField
    {
        private List<Translation> translations = new List<Translation> ();

        public CustomField()
        {
        }
        public string Id { 
                get;
                set;
        }

        public string Value {
                get;
                set;
        }

        public bool Required {
                get;
                set;
        }

		public List<Translation> Translations
		{
			get
			{
				return translations;
			}
			set
			{
				translations = value;
			}
		}

        public void AddTranslations (IList<Translation> translations)
        {
                this.translations.AddRange (translations);
        }

    }
}

