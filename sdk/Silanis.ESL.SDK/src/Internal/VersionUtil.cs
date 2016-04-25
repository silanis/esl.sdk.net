using System;
using System.Reflection;
using System.Diagnostics;

namespace Silanis.ESL.SDK
{
    public class VersionUtil
    {
        public static string getVersion() {

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            string version = String.Format("{0}.{1}", fileVersionInfo.ProductMajorPart, fileVersionInfo.ProductMinorPart);

            if (fileVersionInfo.ProductBuildPart != 0) 
            {
                version = version + "." + fileVersionInfo.ProductBuildPart;
            }

            if (fileVersionInfo.ProductPrivatePart != 0) 
            {
                version = version + "." + fileVersionInfo.ProductPrivatePart;
            }
            return version;
        }
    }
}

