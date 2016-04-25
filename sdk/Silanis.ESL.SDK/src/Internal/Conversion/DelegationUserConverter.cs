using System;
using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
    internal class DelegationUserConverter
    {
        private Silanis.ESL.API.DelegationUser apiDelegationUser;
        private DelegationUser sdkDelegationUser;

        public DelegationUserConverter( DelegationUser sdkDelegationUser ) {
            this.sdkDelegationUser = sdkDelegationUser;
            this.apiDelegationUser = null;
        }

        public DelegationUserConverter( Silanis.ESL.API.DelegationUser apiDelegationUser ) {
            this.apiDelegationUser = apiDelegationUser;
            this.sdkDelegationUser = null;
        }

        public Silanis.ESL.API.DelegationUser ToAPIDelegationUser()
        {
            if (sdkDelegationUser == null)
            {
                return apiDelegationUser;
            }
            Silanis.ESL.API.DelegationUser result = new Silanis.ESL.API.DelegationUser();

            result.Email = sdkDelegationUser.Email;
            result.FirstName = sdkDelegationUser.FirstName;
            result.Id = sdkDelegationUser.Id;
            result.LastName = sdkDelegationUser.LastName;
            result.Name = sdkDelegationUser.Name;

            return result;
        }

        public DelegationUser ToSDKDelegationUser()
        {
            if (apiDelegationUser == null)
            {
                return sdkDelegationUser;
            }

            return DelegationUserBuilder.NewDelegationUser(apiDelegationUser.Email)
                    .WithFirstName(apiDelegationUser.FirstName)
                    .WithId(apiDelegationUser.Id)
                    .WithLastName(apiDelegationUser.LastName)
                    .WithName(apiDelegationUser.Name)
                    .Build();
        }
    }
}

