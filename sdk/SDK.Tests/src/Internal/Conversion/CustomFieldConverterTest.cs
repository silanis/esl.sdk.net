using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Tests
{
    [TestFixture()]
    public class CustomFieldConverterTest
    {
		private Silanis.ESL.SDK.CustomField sdkCustomField1 = null;
		private Silanis.ESL.SDK.CustomField sdkCustomField2 = null;
		private Silanis.ESL.API.CustomField apiCustomField1 = null;
		private Silanis.ESL.API.CustomField apiCustomField2 = null;
		private Silanis.ESL.SDK.CustomFieldConverter converter = null;

		[Test()]
		public void ConvertNullSDKToAPI()
		{
			sdkCustomField1 = null;
			converter = new CustomFieldConverter(sdkCustomField1);
			Assert.IsNull(converter.ToAPICustomField());
		}

		[Test()]
		public void ConvertNullAPIToSDK()
		{
			apiCustomField1 = null;
			converter = new CustomFieldConverter(apiCustomField1);
			Assert.IsNull(converter.ToSDKCustomField());
		}

		[Test()]
		public void ConvertNulSDKIToSDK()
		{
			sdkCustomField1 = null;
			converter = new CustomFieldConverter(sdkCustomField1);

			Assert.IsNull(converter.ToSDKCustomField());
		}
	
		[Test()]
		public void ConvertNullAPIToAPI()
		{
			apiCustomField1 = null;
			converter = new CustomFieldConverter(apiCustomField1);

			Assert.IsNull(converter.ToAPICustomField());
		}

		[Test()]
		public void ConvertSDKToSDK()
		{
			sdkCustomField1 = CreateTypicalSDKCustomField();
			converter = new CustomFieldConverter(sdkCustomField1);
			sdkCustomField2 = converter.ToSDKCustomField();

			Assert.IsNotNull(sdkCustomField2);
			Assert.AreEqual(sdkCustomField2, sdkCustomField1);
		}

		[Test()]
		public void ConvertAPIToAPI()
		{
			apiCustomField1 = CreateTypicalAPICustomField();
			converter = new CustomFieldConverter(apiCustomField1);
			apiCustomField2 = converter.ToAPICustomField();

			Assert.IsNotNull(apiCustomField2);
			Assert.AreEqual(apiCustomField2, apiCustomField1);
		}

		[Test()]
		public void ConvertSDKToAPI()
		{
			sdkCustomField1 = CreateTypicalSDKCustomField();
			apiCustomField1 = new CustomFieldConverter(sdkCustomField1).ToAPICustomField();

			Assert.IsNotNull(apiCustomField1);
			Assert.AreEqual(sdkCustomField1.Id, apiCustomField1.Id);
			Assert.AreEqual(sdkCustomField1.Translations[0].Name, apiCustomField1.Translations[0].Name);
			Assert.AreEqual(sdkCustomField1.Translations[0].Description, apiCustomField1.Translations[0].Description);
			Assert.AreEqual(sdkCustomField1.Value, apiCustomField1.Value);
			Assert.AreEqual(sdkCustomField1.Required, apiCustomField1.Required);
		}

		[Test()]
		public void ConvertAPIToSDK()
		{
			apiCustomField1 = CreateTypicalAPICustomField();
			sdkCustomField1 = new CustomFieldConverter(apiCustomField1).ToSDKCustomField();

			Assert.IsNotNull(sdkCustomField1);
			Assert.AreEqual(apiCustomField1.Id, sdkCustomField1.Id);
			Assert.AreEqual(apiCustomField1.Value, sdkCustomField1.Value);
			Assert.AreEqual(apiCustomField1.Required, sdkCustomField1.Required);
		}

		private Silanis.ESL.SDK.CustomField CreateTypicalSDKCustomField()
		{
			Silanis.ESL.SDK.CustomField sdkCustomField = CustomFieldBuilder.CustomFieldWithId("1")
				.WithDefaultValue("Default Value")
				.WithTranslation(TranslationBuilder.NewTranslation("en")
					.WithName("Translation Name")
					.WithDescription("Translatioin Description")
					.Build())
				.IsRequired(true)
				.Build();

			return sdkCustomField;
		}

		private Silanis.ESL.API.CustomField CreateTypicalAPICustomField()
		{
			Silanis.ESL.API.CustomField apiCustomField = new Silanis.ESL.API.CustomField();
			apiCustomField.Id = "1";
			apiCustomField.Value = "API custom field value";
			apiCustomField.Required = true;

			return apiCustomField;
		}
    }
}

