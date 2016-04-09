using System.Net;
using Silanis.ESL.API;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    public class EslServerException:EslException
    {

        public ServerError ServerError
        {
            get; set;
        }
    
        public EslServerException(string message, ServerError serverError, EslServerException cause):base(message, cause)
        {
            ServerError = serverError;
        }

        public EslServerException(string message, string errorDetails, WebException cause):base(message, cause)
        {
            var e = JsonConvert.DeserializeObject<Error>(errorDetails);
            ServerError = new ErrorConverter(e).ToServerError();
        }
        
    }
}
