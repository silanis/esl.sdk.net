
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Silanis.ESL.API
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum SignerStatus
    {
        NONE, REVIEWER, FUTURE_SIGNER, CURRENT_SIGNER, MUST_COMPLETE, COMPLETED
    }
}

