Imports System
Imports System.IO
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder

Namespace SDK.VBExamples
    Public Module FieldExtractionExample
        Dim apiToken = "YOUR TOKEN HERE"
        Dim baseUrl = "ENVIRONMENT URL HERE"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)
            Dim file = New FileInfo(Directory.GetCurrentDirectory() + My.Resources.documentWithFields)

            Dim package = PackageBuilder.NewPackageNamed("Field extraction example") _
                .DescribedAs("This is a new package") _
                .WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@email.com") _
                    .WithFirstName("John") _
                    .WithLastName("Smith")) _
                .WithDocument(DocumentBuilder.NewDocumentNamed("My Document") _
                    .FromFile(file.FullName) _
                    .EnableExtraction() _
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com") _
                        .WithName("AGENT_SIG_1") _
                        .EnableExtraction() _
                        .WithField(FieldBuilder.SignatureDate() _
                            .WithName("AGENT_SIG_2") _
                            .WithExtraction()))) _
                .Build()

            Dim id = client.CreatePackage(package)

            client.SendPackage(id)

            Console.WriteLine("Package {0} was sent", id.Id)
        End Sub
    End Module
End Namespace