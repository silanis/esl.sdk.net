using System;

namespace Silanis.ESL.SDK
{
	public abstract class EslEnumeration
	{         
        private readonly string sdkValue;
        private readonly string apiValue;
        private readonly int index;

        protected EslEnumeration(string apiValue, int index):this(apiValue, apiValue, index) 
        {
		}

        protected EslEnumeration(string apiValue, string sdkValue, int index) 
        {
            this.apiValue = apiValue;
            this.sdkValue = sdkValue;           
            this.index = index;			
        }
		
		internal string getSdkValue() 
        {
			return sdkValue;
		}

        internal string getApiValue()
        {
			return apiValue;
        }

        public string GetName()
        {
            return getSdkValue();
        }

        public override string ToString()
        {
            return GetName();
        }

        public static T Convert<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        internal int Ordinal() 
        {
            return index;
        }

        public static implicit operator int(EslEnumeration eslEnum)
        {
            return eslEnum.Ordinal();
        }

        public static implicit operator string(EslEnumeration eslEnum)
        {
            return eslEnum.ToString();
        }
	}
}