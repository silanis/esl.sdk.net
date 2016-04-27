namespace Silanis.ESL.SDK.Builder
{
    /**
     * TranslationBuilder is a convenient class used to create
     * array of translations.
     */
    public class TranslationBuilder
    {
        private string name;
        private string language;
        private string description;
    
        /**
         * Creates a translation builder
         *
         * @return new instance of TranslationBuilder
         */
        public static TranslationBuilder NewTranslation( string language ) {
            return new TranslationBuilder( language );
        }
    
        internal static TranslationBuilder NewTranslation( API.Translation apiTranslation ) {
            var builder = new TranslationBuilder( apiTranslation.Language );
            builder.WithName( apiTranslation.Name )
                    .WithDescription( apiTranslation.Description );
            return builder;
        }
    
        private TranslationBuilder( string language ) {
            this.language = language;
        }
    
        public TranslationBuilder WithName( string name ) {
            this.name = name;
            return this;
        }
    
        public TranslationBuilder WithDescription( string description ) {
            this.description = description;
            return this;
        }
    
        /**
         * Builds the list of translation
         *
         * @return the list of translation
         */
        public Translation Build() {
            var result = new Translation();
            result.Name = name;
            result.Description = description;
            result.Language = language;

            return result;
        }
        
    }
}

