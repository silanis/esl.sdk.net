using System;
using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
	internal class CustomFieldConverter
    {
		private Silanis.ESL.SDK.CustomField sdkCustomField = null;
		private Silanis.ESL.API.CustomField apiCustomField = null;

		public CustomFieldConverter(Silanis.ESL.SDK.CustomField sdkCustomField)
        {
			this.sdkCustomField = sdkCustomField;
        }

		public CustomFieldConverter(Silanis.ESL.API.CustomField apiCustomField)
		{
			this.apiCustomField = apiCustomField;
		}

		public Silanis.ESL.API.CustomField ToAPICustomField()
		{
			if (sdkCustomField == null)
			{
				return apiCustomField;
			}

			Silanis.ESL.API.CustomField result = new Silanis.ESL.API.CustomField();

			result.Id = sdkCustomField.Id;
			result.Value = sdkCustomField.Value;
			result.Name = "";
			result.Required = sdkCustomField.Required;

			foreach (Translation translation in sdkCustomField.Translations) 
			{
				result.AddTranslation (translation.toAPITranslation());
			}

			return result;
		}

		public Silanis.ESL.SDK.CustomField ToSDKCustomField()
		{
			if (apiCustomField == null)
			{
				return sdkCustomField;
			}

			CustomFieldBuilder result = new CustomFieldBuilder();
			result.WithId(apiCustomField.Id)
				.WithDefaultValue(apiCustomField.Value)
				.IsRequired(apiCustomField.Required.Value);

			foreach(Silanis.ESL.API.Translation translation in apiCustomField.Translations)
			{
				result.WithTranslation(TranslationBuilder.NewTranslation(translation));
			}

			return result.Build();
		}
    }
}

