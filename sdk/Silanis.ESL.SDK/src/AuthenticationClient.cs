using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class AuthenticationClient
    {
        private AuthenticationService authenticationService;

        public AuthenticationClient(string webpageUrl) {
            authenticationService = new AuthenticationService(webpageUrl);
        }

        public string GetSessionIdForUserAuthenticationToken(string userAuthenticationToken) {
            return authenticationService.GetSessionIdForUserAuthenticationToken(userAuthenticationToken);
        }

        public string BuildRedirectToDesignerForUserAuthenticationToken(string userAuthenticationToken, PackageId packageId) {
            return authenticationService.BuildRedirectToDesignerForUserAuthenticationToken(userAuthenticationToken, packageId);
        }

        public string GetSessionIdForSenderAuthenticationToken(string senderAuthenticationToken) {
            return authenticationService.GetSessionIdForSenderAuthenticationToken(senderAuthenticationToken);
        }

        public string BuildRedirectToDesignerForSender(string senderAuthenticationToken, PackageId packageId) {
            return authenticationService.BuildRedirectToDesignerForSender(senderAuthenticationToken, packageId);
        }

        public string BuildRedirectToPackageViewForSender(string userAuthenticationToken, PackageId packageId) {
            return authenticationService.BuildRedirectToPackageViewForSender(userAuthenticationToken, packageId);
        }

        public string GetSessionIdForSignerAuthenticationToken(string signerAuthenticationToken) {
            return authenticationService.GetSessionIdForSignerAuthenticationToken(signerAuthenticationToken);
        }

        public string BuildRedirectToSigningForSigner(string signerAuthenticationToken, PackageId packageId) {
            return authenticationService.BuildRedirectToSigningForSigner(signerAuthenticationToken, packageId);
        }
    }
}

