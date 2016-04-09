using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Builder
{
    /**
     * CustomFieldBuilder is a convenient class used to create
     * account custom fields.
     */    
    public class CustomFieldBuilder
    {
        private string id;
        private string value;
		private IList<Translation> translations = new List<Translation>();
        private Boolean required = true;
    
        /**
         * Creates a custom field builder with field id
         *
         * @param id of custom field
         * @return a custom field builder with field id
         */
        public static CustomFieldBuilder CustomFieldWithId( string id ) {
            return new CustomFieldBuilder().WithId( id );
        }

        /**
         * Sets id of custom field
         *
         * @param id of custom field
         * @return the custom field builder itself
         */
        public CustomFieldBuilder WithId( string id ) {
            this.id = id;
            return this;
        }
    
        /**
         * Sets value of custom field
         *
         * @param value of custom field
         * @return the custom field builder itself
         */
        public CustomFieldBuilder WithDefaultValue( string value ) {
            this.value = value;
            return this;
        }

        /**
         * Sets translation of custom field
         *
         * @param builder translation builder
         * @return the custom field builder itself
         */
        public CustomFieldBuilder WithTranslation( TranslationBuilder builder ) {
            return WithTranslation( builder.Build() );
        }
    
        public CustomFieldBuilder WithTranslation( Translation translation ) {
            if ( translations == null ) {
                translations = new List<Translation>();
            }
            translations.Add( translation );
            return this;
    
        }
    
        /**
         * Sets required indication of custom field
         *
         * @param required indication of custom field
         * @return the custom field builder itself
         */
        public CustomFieldBuilder IsRequired( Boolean required ) {
            this.required = required;
            return this;
        }
    
        /**
         * Builds the custom field
         *
         * @return the custom field
         */
        public CustomField Build() {
            var customField = new CustomField();
            
            customField.Id = id;
            customField.Value = value;
            customField.Required = required;
            customField.AddTranslations(translations);

            return customField;
        }
                
    }
}

