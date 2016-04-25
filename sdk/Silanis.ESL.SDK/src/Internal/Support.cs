using System;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace Silanis.ESL.SDK
{
    public class Support
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public Support() 
		{
        }

        internal void LogRequest(string httpVerb, string path, string jsonPayload) {
			log.Debug(httpVerb + " on " + path + "\n" + jsonPayload);
        }

        internal void LogRequest(string httpVerb, string path) {
            log.Debug(httpVerb + " on " + path);
        }

        internal void LogResponse(string response) {
			log.Debug("Response: \n" + response);
        }

        internal void LogError(Error error) {
            log.Error("message: " + error.Message + ", http code: " + error.Code);
        }

		internal void LogError( string message ) {
			log.Error(message);
		}

		internal void LogDebug(string message) {
			log.Debug(message);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void LogMethodEntry(params object[] values)
		{
            try
            {
    			MethodBase methodBase = GetCallingMethod();
    			LogDebug("--->" + methodBase.DeclaringType.Name + ": " + methodBase.ToString());
    			if (values != null)
    			{
    				for (int paramCtr = 0; paramCtr < values.Length; paramCtr++)
    				{
    					ParameterInfo paramInfo = methodBase.GetParameters()[paramCtr];
    					object param = values[paramCtr];
    					string json = JsonConvert.SerializeObject(param);
    					LogDebug("\t" + paramInfo.ParameterType.ToString() + " " + paramInfo.Name + ": " + json);
    				}
    			}
            }
            catch (Exception e)
            {
                LogDebug("!!!! Exception occurred in logging: " + e.Message);
            }
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
        public void LogMethodExit(params object[] values)
        {
            try
            {
                if (values != null)
                {
                    foreach (object value in values)
                    {
                        LogDebug("Returning: " + JsonConvert.SerializeObject(value));
                    }
                }
                else
                {
                    LogDebug("Returning: null");
                }
                MethodBase methodBase = GetCallingMethod();
                LogDebug("<---" + methodBase.DeclaringType.Name + ": " + methodBase.Name);
            }
            catch (Exception e)
            {
                LogDebug("!!!! Exception occurred in logging: " + e.Message);
            }
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MethodBase GetCallingMethod() {
			StackTrace st = new StackTrace();
			StackFrame sf = st.GetFrame(2);

			return sf.GetMethod();
		}
    }
}

