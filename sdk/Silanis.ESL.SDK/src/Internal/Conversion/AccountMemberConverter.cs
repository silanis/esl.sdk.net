using System;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class AccountMemberConverter
    {
        private User apiUser = null;
        private AccountMember sdkAccountMember = null;

        public AccountMemberConverter( User apiUser )
        {
            this.apiUser = apiUser;
        }

        public AccountMemberConverter( AccountMember sdkAccountMember ) {
            this.sdkAccountMember = sdkAccountMember;
        }

        public API.Sender ToAPISender() {
            if (null!=sdkAccountMember) {
                var result = new API.Sender();
                
                result.Address = new AddressConverter(sdkAccountMember.Address).ToAPIAddress();
                result.FirstName = sdkAccountMember.FirstName;
                result.LastName = sdkAccountMember.LastName;
                result.Title = sdkAccountMember.Title;
                result.Company = sdkAccountMember.Company;
                result.Email = sdkAccountMember.Email;
                result.Phone = sdkAccountMember.PhoneNumber;
                result.Language = sdkAccountMember.Language;
                var convertedStatus = new SenderStatusConverter(sdkAccountMember.Status).ToAPISenderStatus();
                if ( !String.IsNullOrEmpty(convertedStatus) ) result.Status = convertedStatus;
                return result;
            }
            else {
                return null;
            }
        }
        
        public AccountMember ToSDKAccountMember() {
            if (sdkAccountMember != null)
            {
                return sdkAccountMember;
            }
            else if (apiUser != null)
            {
                var builder = AccountMemberBuilder.NewAccountMember(apiUser.Email)
                        .WithAddress(new AddressConverter(apiUser.Address).ToSDKAddress())
                        .WithCompany(apiUser.Company)
                        .WithFirstName(apiUser.FirstName)
                        .WithLastName(apiUser.LastName)
                        .WithTitle(apiUser.Title)
                        .WithLanguage(apiUser.Language)
                        .WithPhoneNumber(apiUser.Phone);                        

                return builder.Build();
            }
            else
            {
                return null;
            }
        }
    }
}

