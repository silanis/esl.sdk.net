using System;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class UnauthenticatedRestClient
    {
        public UnauthenticatedRestClient()
        {
        }

        public string GetUnauthenticated(string path)
        {
            var responseBytes = HttpMethods.GetHttp(path);
            return Converter.ToString(responseBytes);
        }
    }
}

