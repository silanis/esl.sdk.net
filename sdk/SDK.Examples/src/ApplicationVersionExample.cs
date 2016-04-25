using System;

namespace SDK.Examples
{
    public class ApplicationVersionExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new ApplicationVersionExample().Run();
        }

        public string applicationVersion;

        override public void Execute()
        {
            applicationVersion = eslClient.SystemService.GetApplicationVersion();
        }
    }
}

