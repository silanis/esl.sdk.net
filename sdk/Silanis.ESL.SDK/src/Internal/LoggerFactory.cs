using System;

namespace Silanis.ESL.SDK.Internal
{
    internal class LoggerFactory
    {
        internal static ILogger get(string name)
        {
            return new ApplicationLogger(name);
        }
        internal static ILogger get(Type type)
        {
            return new ApplicationLogger(type.FullName);
        }
    }
}
