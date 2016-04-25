using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
    internal class SignedDocuments
    {
        private IList<Document> _documents = new List<Document>();

        [JsonProperty("documents")]
        public IList<Document> Documents
        {
            get
            {
                return _documents;
            }
            set
            {
                _documents = value;
            }
        }

        public SignedDocuments AddDocument(Document document) 
        {
            _documents.Add(document);
            return this;
        }
    }
}

