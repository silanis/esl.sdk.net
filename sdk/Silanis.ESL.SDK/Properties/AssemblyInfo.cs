using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Silanis.ESL.SDK")]
[assembly: AssemblyDescription("Compatible with .Net 2.0")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Silanis Technology")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("11.0")]
[assembly: AssemblyKeyFile("sdk.snk")]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

// This allows us to write unit tests in the Silanis.ESL.SDK.Test project that can access internal classes (ie. API model)
[assembly:InternalsVisibleTo("Silanis.ESL.SDK.Test, PublicKey=002400000480000094000000060200000024000052534131000400001100000075437f4fb7ce723c1ca149fa20e60e0ca0b4eab5aa0fb78f85dd4059d06afefde2296350975d3c2cf1b1b0e36a5709c5730bc2560ae8948e4ae137a01b5dcc6eef0e4ebf40beee08b0ec945b92a1de6caa677eab5ed885d96740221c6b02211a04d8b189acba397c5597bb6da55f6cda3da7451a87c21d4f3df6fedccf599587")]