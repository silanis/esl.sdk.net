Imports System
Imports System.IO
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder

Namespace SDK.VBExamples
    Public Module GetPackageExample
        Dim apiToken = "UGF3anRiZHJxVUNNOnNlY3JldA=="
        Dim baseUrl = "http://localhost:8080"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)
            Dim file = New FileInfo(Directory.GetCurrentDirectory() + My.Resources.document)

            Dim package = PackageBuilder.NewPackageNamed("Fields example " + DateTime.Now) _
                .DescribedAs("This is a new package") _
                .WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@email.com") _
                    .WithFirstName("John") _
                    .WithLastName("Smith") _
                    .WithCompany("Acme Inc") _
                    .WithTitle("Managing Director")) _
                .WithDocument(DocumentBuilder.NewDocumentNamed("My Document") _
                    .FromFile(file.FullName) _
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com") _
                        .OnPage(0) _
                        .AtPosition(500, 100) _
                        .WithField(FieldBuilder.SignatureDate() _
                            .OnPage(0) _
                            .AtPosition(500, 200)) _
                        .WithField(FieldBuilder.SignerName() _
                            .OnPage(0) _
                            .AtPosition(500, 300)) _
                        .WithField(FieldBuilder.SignerTitle() _
                            .OnPage(0) _
                            .AtPosition(500, 400)) _
                        .WithField(FieldBuilder.SignerCompany() _
                            .OnPage(0) _
                            .AtPosition(500, 500)))) _
                .Build()

            Dim id = client.CreatePackage(package)
            client.SendPackage(id)

            Console.WriteLine("Package {0} was sent", id.Id)

            Dim retrievedPackage = client.GetPackage(id)

            Console.WriteLine("id = {0}", retrievedPackage.Id)
            Console.WriteLine("status = {0}", retrievedPackage.Status)
        End Sub
    End Module
End Namespace