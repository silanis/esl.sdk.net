Imports System
Imports System.IO
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder

Namespace SDK.VBExamples
    Public Module CreatePackageFromStream
        Dim apiToken = "YOUR TOKEN HERE"
        Dim baseUrl = "ENVIRONMENT URL HERE"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)
            Dim file = New FileInfo(Directory.GetCurrentDirectory() + My.Resources.document)
            Dim fileStream = file.OpenRead

            Dim package = PackageBuilder.NewPackageNamed("VB Package " + DateTime.Now) _
                .DescribedAs("This is a new package") _
                .WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@email.com") _
                    .WithFirstName("John") _
                    .WithLastName("Smith")) _
                .WithDocument(DocumentBuilder.NewDocumentNamed("My Document") _
                    .FromStream(fileStream, DocumentType.PDF)) _
                .Build()

            Dim id = client.CreatePackage(package)

            Console.WriteLine("Package {0} was created", id.Id)
        End Sub
    End Module
End Namespace