using System;

namespace Silanis.ESL.SDK
{
    public class Translation
    {
        public Translation()
        {
        }
        public string Name 
        {
                get;
                set;
        }
        public string Language 
        {
                get;
                set;
        }
        public string Description 
        {
                get;
                set;
        }
        
        internal Silanis.ESL.API.Translation toAPITranslation() 
        {
            Silanis.ESL.API.Translation result = new Silanis.ESL.API.Translation();
			result.Id = "";
            result.Name = Name;
            result.Language = Language;
            result.Description = Description;
            return result;
        }        
    }
}

