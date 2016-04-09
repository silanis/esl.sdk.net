namespace SDK.Examples
{
    public class ApplicationVersionExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new ApplicationVersionExample().Run();
        }

        public string ApplicationVersion;

        override public void Execute()
        {
            ApplicationVersion = eslClient.SystemService.GetApplicationVersion();
        }
    }
}

