Imports System
Imports System.IO
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder

Namespace SDK.VBExamples
    Public Module SignerOrderingExample
        Dim apiToken = "YOUR TOKEN HERE"
        Dim baseUrl = "ENVIRONMENT URL HERE"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)
            Dim file = New FileInfo(Directory.GetCurrentDirectory() + My.Resources.document)

            Dim package = PackageBuilder.NewPackageNamed("Signing Order " + DateTime.Now) _
                .DescribedAs("This is a signer workflow example") _
                .WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@email.com") _
                    .WithFirstName("John") _
                    .WithLastName("Smith") _
                    .SigningOrder(1)) _
                .WithSigner(SignerBuilder.NewSignerWithEmail("coco.beware@email.com") _
                    .WithFirstName("Coco") _
                    .WithLastName("Beware") _
                    .SigningOrder(2)) _
                .WithDocument(DocumentBuilder.NewDocumentNamed("Second Document") _
                    .FromFile(file.FullName) _
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com") _
                        .OnPage(0) _
                        .AtPosition(500, 100)) _
                    .WithSignature(SignatureBuilder.InitialsFor("john.smith@email.com") _
                        .OnPage(0) _
                        .AtPosition(500, 200)) _
                    .WithSignature(SignatureBuilder.CaptureFor("coco.beware@email.com") _
                        .OnPage(0) _
                        .AtPosition(500, 300))) _
                .WithDocument(DocumentBuilder.NewDocumentNamed("First Document") _
                    .FromFile(file.FullName) _
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com") _
                        .OnPage(0) _
                        .AtPosition(500, 100))) _
            .Build()

            Dim id = client.CreatePackage(package)

            client.SendPackage(id)

            Console.WriteLine("Package {0} was sent", id.Id)
        End Sub
    End Module
End Namespace
