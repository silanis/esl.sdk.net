using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class UserAuthenticationTokenExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new UserAuthenticationTokenExample().Run();
        }

        public string UserSessionId { get; private set; }

        private readonly AuthenticationClient _authenticationClient;

        public UserAuthenticationTokenExample()
        {
            _authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {            
            var userAuthenticationToken = eslClient.AuthenticationTokenService.CreateUserAuthenticationToken();

            UserSessionId = _authenticationClient.GetSessionIdForUserAuthenticationToken(userAuthenticationToken);
        }
    }
}
