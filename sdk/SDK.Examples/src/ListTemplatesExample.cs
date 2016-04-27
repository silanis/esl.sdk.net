using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class ListTemplatesExample : SdkSample
    {
        public Page<DocumentPackage> Templates { get; private set; }

        public static void Main (string[] args)
        {
            new ListTemplatesExample().Run();
        }

        override public void Execute()
        {
            Templates = eslClient.PackageService.GetTemplates(new PageRequest(0));
            Console.WriteLine("Templates = " + Templates.Size);
        }
    }
}

