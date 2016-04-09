using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Builder
{
    public class DocumentPackageAttributesBuilder
    {
        private DocumentPackageAttributes attributes = new DocumentPackageAttributes();

		public DocumentPackageAttributesBuilder() 
		{
		}

		public DocumentPackageAttributesBuilder(IDictionary<string, object> data)
		{
			attributes.Contents = data;
		}
        
        public DocumentPackageAttributesBuilder WithAttribute(string name, Object value)
        {
            attributes.Append(name, value);
            return this;
        }
        
        [Obsolete("Use WithAttribute() instead.  Notice the uppercase W.")]
        public DocumentPackageAttributesBuilder withAttribute( string name, Object value ) 
        {
            return WithAttribute( name, value );
        }

        [Obsolete("Use Build() instead, Notice the uppercase B.")]
        public DocumentPackageAttributes build()
        {
            return Build();
        }

        public DocumentPackageAttributes Build() {
            return attributes;
        }
    }
}

