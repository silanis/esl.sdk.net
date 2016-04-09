using System;

namespace Silanis.ESL.SDK.Internal
{
    internal interface ILogger
    {
        void Debug(string message);
        void Info(string message, params object[] formatArgs);
        void Warn(string message, params object[] formatArgs);
        void Error(Exception cause, string message, params object[] formatArgs);
        void Error(string message, params object[] formatArgs);
    }
}
