using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
	internal class CustomFieldConverter
    {
		private CustomField sdkCustomField = null;
		private API.CustomField apiCustomField = null;

		public CustomFieldConverter(CustomField sdkCustomField)
        {
			this.sdkCustomField = sdkCustomField;
        }

		public CustomFieldConverter(API.CustomField apiCustomField)
		{
			this.apiCustomField = apiCustomField;
		}

		public API.CustomField ToAPICustomField()
		{
			if (sdkCustomField == null)
			{
				return apiCustomField;
			}

			var result = new API.CustomField();

			result.Id = sdkCustomField.Id;
			result.Value = sdkCustomField.Value;
			result.Name = "";
			result.Required = sdkCustomField.Required;

			foreach (var translation in sdkCustomField.Translations) 
			{
				result.AddTranslation (translation.toAPITranslation());
			}

			return result;
		}

		public CustomField ToSDKCustomField()
		{
			if (apiCustomField == null)
			{
				return sdkCustomField;
			}

			var result = new CustomFieldBuilder();
			result.WithId(apiCustomField.Id)
				.WithDefaultValue(apiCustomField.Value)
				.IsRequired(apiCustomField.Required.Value);

			foreach(var translation in apiCustomField.Translations)
			{
				result.WithTranslation(TranslationBuilder.NewTranslation(translation));
			}

			return result.Build();
		}
    }
}

