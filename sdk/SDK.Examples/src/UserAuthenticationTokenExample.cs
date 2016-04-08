using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class UserAuthenticationTokenExample : SDKSample
    {
        public static void Main (string[] args)
        {
            new UserAuthenticationTokenExample().Run();
        }

        public string UserSessionId{ get; private set; }

        private AuthenticationClient AuthenticationClient;

        public UserAuthenticationTokenExample()
        {
            this.AuthenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {            
            var userAuthenticationToken = eslClient.AuthenticationTokenService.CreateUserAuthenticationToken();

            UserSessionId = AuthenticationClient.GetSessionIdForUserAuthenticationToken(userAuthenticationToken);
        }
    }
}

