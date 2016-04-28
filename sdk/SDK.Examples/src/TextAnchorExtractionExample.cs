using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class TextAnchorExtractionExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new TextAnchorExtractionExample().Run();
        }

        public readonly string DocumentName = "Document With Anchors";
        public readonly int FieldWidth = 150;
        public readonly int FieldHeight = 40;

        override public void Execute()
        {
            fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-for-anchor-extraction.pdf").FullName);

            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                                                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                                        .WithFirstName( "John" )
                                                        .WithLastName( "Smith" ) )
                                                .WithDocument( DocumentBuilder.NewDocumentNamed( DocumentName )
                                                        .FromStream( fileStream1, DocumentType.PDF )
                                                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                                                                .WithPositionAnchor(TextAnchorBuilder.NewTextAnchor("Nondisclosure")
                                                                        .AtPosition(TextAnchorPosition.BOTTOMRIGHT)
                                                                        .WithSize(FieldWidth, FieldHeight)
                                                                        .WithOffset(0, 0)
                                                                        .WithCharacter(9)
                                                                        .WithOccurrence(0)))
                                                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                                                                .WithPositionAnchor(TextAnchorBuilder.NewTextAnchor("Receiving")
                                                                        .AtPosition(TextAnchorPosition.TOPLEFT)
                                                                        .WithSize(FieldWidth, FieldHeight)
                                                                        .WithOffset(0, 0)
                                                                        .WithCharacter(0)
                                                                        .WithOccurrence(0))
                                                                .WithField(FieldBuilder.TextField()
                                                                        .WithPositionAnchor(TextAnchorBuilder.NewTextAnchor("Definition")
                                                                                .AtPosition(TextAnchorPosition.TOPLEFT)
                                                                                .WithSize(FieldWidth, FieldHeight)
                                                                                .WithOffset(0, 0)
                                                                                .WithCharacter(0)
                                                                                .WithOccurrence(0)))
                                                                .WithField(FieldBuilder.TextField()
                                                                        .WithPositionAnchor(TextAnchorBuilder.NewTextAnchor("through legitimate means")
                                                                                .AtPosition(TextAnchorPosition.TOPLEFT)
                                                                                .WithSize(FieldWidth, FieldHeight)
                                                                                .WithOffset(100, 100)
                                                                                .WithCharacter(0)
                                                                                .WithOccurrence(1))))
                                                             )
                                                .Build();

            var package = eslClient.CreatePackage( superDuperPackage );
            eslClient.SendPackage( package );

            retrievedPackage = eslClient.GetPackage(package);
            Console.Out.WriteLine(package.Id);
        }
    }
}

