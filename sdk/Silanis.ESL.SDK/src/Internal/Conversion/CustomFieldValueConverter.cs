using Silanis.ESL.API;
using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
    internal class CustomFieldValueConverter
    {
        private CustomFieldValue sdkCustomFieldValue = null;
        private UserCustomField apiUserCustomField = null;

        public CustomFieldValueConverter(CustomFieldValue sdkCustomFieldValue)
        {
            this.sdkCustomFieldValue = sdkCustomFieldValue;
        }

        internal CustomFieldValueConverter(UserCustomField apiUserCustomField)
        {
            this.apiUserCustomField = apiUserCustomField;
        }

        internal UserCustomField ToAPIUserCustomField()
        {
            if (sdkCustomFieldValue == null)
            {
                return apiUserCustomField;
            }

            var result = new UserCustomField();

            result.Id = sdkCustomFieldValue.Id;
            result.Value = sdkCustomFieldValue.Value;
            result.Name = "";

            return result;
        }

        public CustomFieldValue ToSDKCustomFieldValue()
        {
            if (apiUserCustomField == null)
            {
                return sdkCustomFieldValue;
            }

            var result = new CustomFieldValueBuilder();
            result.WithId(apiUserCustomField.Id)
                    .WithValue(apiUserCustomField.Value);

            return result.build();
        }
    }
}

