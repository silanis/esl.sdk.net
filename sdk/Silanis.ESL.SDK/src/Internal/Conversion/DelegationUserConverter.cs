using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
    internal class DelegationUserConverter
    {
        private API.DelegationUser apiDelegationUser;
        private DelegationUser sdkDelegationUser;

        public DelegationUserConverter( DelegationUser sdkDelegationUser ) {
            this.sdkDelegationUser = sdkDelegationUser;
            apiDelegationUser = null;
        }

        public DelegationUserConverter( API.DelegationUser apiDelegationUser ) {
            this.apiDelegationUser = apiDelegationUser;
            sdkDelegationUser = null;
        }

        public API.DelegationUser ToAPIDelegationUser()
        {
            if (sdkDelegationUser == null)
            {
                return apiDelegationUser;
            }
            var result = new API.DelegationUser();

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

