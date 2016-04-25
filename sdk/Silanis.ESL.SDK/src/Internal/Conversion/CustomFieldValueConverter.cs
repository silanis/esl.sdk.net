using System;
using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
    internal class CustomFieldValueConverter
    {
        private Silanis.ESL.SDK.CustomFieldValue sdkCustomFieldValue = null;
        private Silanis.ESL.API.UserCustomField apiUserCustomField = null;

        public CustomFieldValueConverter(Silanis.ESL.SDK.CustomFieldValue sdkCustomFieldValue)
        {
            this.sdkCustomFieldValue = sdkCustomFieldValue;
        }

        internal CustomFieldValueConverter(Silanis.ESL.API.UserCustomField apiUserCustomField)
        {
            this.apiUserCustomField = apiUserCustomField;
        }

        internal Silanis.ESL.API.UserCustomField ToAPIUserCustomField()
        {
            if (sdkCustomFieldValue == null)
            {
                return apiUserCustomField;
            }

            Silanis.ESL.API.UserCustomField result = new Silanis.ESL.API.UserCustomField();

            result.Id = sdkCustomFieldValue.Id;
            result.Value = sdkCustomFieldValue.Value;
            result.Name = "";

            return result;
        }

        public Silanis.ESL.SDK.CustomFieldValue ToSDKCustomFieldValue()
        {
            if (apiUserCustomField == null)
            {
                return sdkCustomFieldValue;
            }

            CustomFieldValueBuilder result = new CustomFieldValueBuilder();
            result.WithId(apiUserCustomField.Id)
                    .WithValue(apiUserCustomField.Value);

            return result.build();
        }
    }
}

