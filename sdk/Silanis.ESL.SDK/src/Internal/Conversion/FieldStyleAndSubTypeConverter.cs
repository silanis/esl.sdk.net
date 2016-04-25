using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK.Internal;
using System.Reflection;

namespace Silanis.ESL.SDK
{
    internal class FieldStyleAndSubTypeConverter
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        private static string BINDING_DATE = "{approval.signed}";
        private static string BINDING_TITLE = "{signer.title}";
        private static string BINDING_NAME = "{signer.name}";
        private static string BINDING_COMPANY = "{signer.company}";

        private FieldStyle sdkFieldStyle;
        private string apiFieldSubType;
        private string apiFieldBinding;

        public FieldStyleAndSubTypeConverter(FieldStyle sdkFieldStyle)
        {
            this.sdkFieldStyle = sdkFieldStyle;
            apiFieldSubType = null;
            apiFieldBinding = null;
        }

        public FieldStyleAndSubTypeConverter(string apiFieldSubtype, String apiFieldBinding)
        {
            this.apiFieldSubType = apiFieldSubtype;
            this.apiFieldBinding = apiFieldBinding;
            sdkFieldStyle = null;
        }

        public string ToAPIFieldSubtype()
        {
            if (null==sdkFieldStyle)
            {
                return apiFieldSubType;
            }
            return sdkFieldStyle.getApiValue();       
        }

        public FieldStyle ToSDKFieldStyle()
        {
            if (String.IsNullOrEmpty(apiFieldSubType) && apiFieldBinding == null) 
            {
                return sdkFieldStyle;
            }

            if (apiFieldBinding == null)
            {
                return FieldStyle.valueOf(apiFieldSubType);
            }
            else
            {
                if (apiFieldBinding == BINDING_DATE)
                {
                    return FieldStyle.BOUND_DATE;
                }
                else if (apiFieldBinding == BINDING_TITLE)
                {
                    return FieldStyle.BOUND_TITLE;
                }
                else if (apiFieldBinding == BINDING_NAME)
                {
                    return FieldStyle.BOUND_NAME;
                }
                else if (apiFieldBinding == BINDING_COMPANY)
                {
                    return FieldStyle.BOUND_COMPANY;
                }
                else
                {
                    return FieldStyle.valueOf(apiFieldBinding);
                }
            }
        }
    }
}

