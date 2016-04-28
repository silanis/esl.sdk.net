using System;
using System.Diagnostics;

namespace Silanis.ESL.SDK.Internal
{
    internal class ApplicationLogger : ILogger
    {
        private TraceSwitch traceSwitch = new TraceSwitch("eSignLive", "ESignLive SDK Logging");
        private readonly string Name;
        public string FormatString { get; set; }

        protected internal ApplicationLogger(string name)
        {
            Name = name;
            FormatString = "{0}\t{1}\t[{2}] ---\t{3}";
        }
        public void Debug(string message)
        {
            Trace.WriteLineIf(traceSwitch.TraceVerbose, string.Format(FormatString, DateTime.UtcNow.ToString("o"), Level.DEBUG, Name, message));
        }
        public void Info(string message, params object[] formatArgs)
        {
            Trace.WriteLineIf(traceSwitch.TraceInfo, string.Format(FormatString, DateTime.UtcNow.ToString("o"), Level.INFO, Name, formatMessage(message, formatArgs)));
        }
        public void Warn(string message, params object[] formatArgs)
        {
            Trace.WriteLineIf(traceSwitch.TraceWarning, string.Format(FormatString, DateTime.UtcNow.ToString("o"), Level.WARN, Name, formatMessage(message, formatArgs)));
        }
        public void Error(Exception cause, string message, params object[] formatArgs)
        {
            Trace.WriteLineIf(traceSwitch.TraceError, string.Format(FormatString, DateTime.UtcNow.ToString("o"), Level.ERROR, Name, message));
            Trace.WriteLineIf(traceSwitch.TraceError, cause);
        }
        public void Error(string message, params object[] formatArgs)
        {
            Trace.WriteLineIf(traceSwitch.TraceError, string.Format(FormatString, DateTime.UtcNow.ToString("o"), Level.ERROR, Name, formatMessage(message, formatArgs)));
        }
        private string formatMessage(string message, params object[] formatArgs)
        {
            return string.Format(message, formatArgs);
        }
    }

    public enum Level
    {
        DEBUG, INFO, WARN, ERROR
    }
}
