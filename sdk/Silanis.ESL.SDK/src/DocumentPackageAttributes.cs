using System.Collections.Generic;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{

    /// <summary>
    /// Document package attributes
    /// </summary>
    public class DocumentPackageAttributes
    {
        [JsonProperty("contents")]
        public IDictionary<string, object> Contents
        {
            get;
            set;
        }

        public DocumentPackageAttributes()
        {
            Contents = new Dictionary<string, object>();
        }

        public DocumentPackageAttributes(IDictionary<string, object> contents)
        {
			Contents = contents != null ? contents : new Dictionary<string, object>();
        }

        public virtual void Append(string name, object value)
        {
            if (null == Contents) 
            {
                Contents = new Dictionary<string, object>();
            }
            Contents[name] = value;
        }

        public virtual void Append( DocumentPackageAttributes attributes )
        {
            if (null == attributes || null == attributes.Contents) 
            {
                return;
            }
            foreach(var content in attributes.Contents)
            {
                Append((string)content.Key, content.Value);
            }
        }
    }
}



