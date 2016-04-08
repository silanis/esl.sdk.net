using System;

namespace Silanis.ESL.SDK
{
	internal class SenderConverter
    {
		private Silanis.ESL.API.Sender apiSender;
		private Silanis.ESL.SDK.SenderInfo sdkSenderInfo;
		private Silanis.ESL.SDK.Sender sdkSender;

		public SenderConverter(Silanis.ESL.API.Sender sender)
		{
			if (sender == null) 
				throw new ArgumentNullException("sender");
			this.apiSender = sender;
			this.sdkSenderInfo = null;
		}

		public SenderConverter(Silanis.ESL.SDK.SenderInfo senderInfo)
		{
			if (senderInfo == null) 
				throw new ArgumentNullException("senderInfo");
			this.apiSender = null;
			this.sdkSenderInfo = senderInfo;
		}

		public SenderInfo ToSDKSenderInfo() {
			if (sdkSenderInfo != null)
			{
				return sdkSenderInfo;
			}
			else
			{
				return SenderInfoBuilder.NewSenderInfo(apiSender.Email)
						.WithName(apiSender.FirstName, apiSender.LastName)
						.WithCompany(apiSender.Company)
						.WithTitle(apiSender.Title)
						.Build();
			}
		}

		internal Silanis.ESL.API.Sender ToAPISender()
		{
			if (apiSender != null)
			{
				return apiSender;
			}
			else
			{
				var result = new Silanis.ESL.API.Sender();
				result.Email = sdkSenderInfo.Email;

				if (sdkSenderInfo.FirstName != null)
					result.FirstName = sdkSenderInfo.FirstName;
				if (sdkSenderInfo.LastName != null)
					result.LastName = sdkSenderInfo.LastName;
				if (sdkSenderInfo.Company != null)
					result.Company = sdkSenderInfo.Company;
				if (sdkSenderInfo.Title != null)
					result.Title = sdkSenderInfo.Title;

				return result;
			}
		}

		public Sender ToSDKSender() {
			if (apiSender == null)
			{
				return sdkSender;
			}

			var result = new Sender();
			result.Email = apiSender.Email;
			result.Id = apiSender.Id;
			result.FirstName = apiSender.FirstName;
			result.LastName = apiSender.LastName;
			result.Company = apiSender.Company;
			result.Created = apiSender.Created;
			result.Language = apiSender.Language;
			result.Name = apiSender.Name;
			result.Phone = apiSender.Phone;
			result.Status = new SenderStatusConverter(apiSender.Status).ToSDKSenderStatus();
			result.Type = new SenderTypeConverter(apiSender.Type).ToSDKSenderType();
			result.Title = apiSender.Title;
			result.Updated = apiSender.Updated;
            result.External = new ExternalConverter(apiSender.External).ToSDKExternal();
			
			return result;
		}
    }
}

