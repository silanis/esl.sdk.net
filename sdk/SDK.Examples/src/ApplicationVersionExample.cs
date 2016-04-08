using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [DeploymentItem("prêt.pdf")]
    [DeploymentItem("document.pdf")]
    [DeploymentItem("document-for-anchor-extraction.pdf")]
    [DeploymentItem("document-with-fields.pdf")]
    [DeploymentItem("extract_document.pdf")]
    [DeploymentItem("field_groups.pdf")]
    [DeploymentItem("document.odt")]
    [DeploymentItem("document.rtf")]
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

