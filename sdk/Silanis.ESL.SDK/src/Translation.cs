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
        
        internal API.Translation toAPITranslation() 
        {
            var result = new API.Translation();
			result.Id = "";
            result.Name = Name;
            result.Language = Language;
            result.Description = Description;
            return result;
        }        
    }
}

