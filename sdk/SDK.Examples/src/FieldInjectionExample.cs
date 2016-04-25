using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;

namespace SDK.Examples
{
    public class FieldInjectionExample : SDKSample {
        public static void Main (string[] args)
        {
            new FieldInjectionExample().Run();
        }

        override public void Execute()
        {
            this.fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/field_groups.pdf").FullName);

            // Note that the field ID for injected field is not a significant for the field injection.
            // InjectedField list is not returned by the esl-backend.
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                .WithSigner( SignerBuilder.NewSignerWithEmail( email1 )
                            .WithFirstName( "John" )
                            .WithLastName( "Smith" ) )
                    .WithDocument( DocumentBuilder.NewDocumentNamed( "First Document" )
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithInjectedField(FieldBuilder.TextField().WithName("Text1").WithValue("First Injected Value"))
                                  .WithInjectedField(FieldBuilder.TextField().WithName("Text2").WithValue("Second Injected Value"))
                                  .WithInjectedField(FieldBuilder.TextField().WithName("Text3").WithValue("Third Injected Value"))
                                  .WithInjectedField(FieldBuilder.TextField().WithName("Text4").WithValue("Fourth Injected Value"))
                                  .WithInjectedField(FieldBuilder.TextField().WithName("Text5").WithValue("Fifth Injected Value"))
                                  .WithInjectedField(FieldBuilder.TextField().WithName("Text6").WithValue("À à Â â Æ æ Ç ç È è É é Ê ë")))
                    .Build();

            packageId = eslClient.CreatePackage( superDuperPackage );
            retrievedPackage = eslClient.GetPackage( PackageId );
        }
    }
}

