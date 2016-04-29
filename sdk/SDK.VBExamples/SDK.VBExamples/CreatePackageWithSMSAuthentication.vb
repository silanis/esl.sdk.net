Imports System
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder

Namespace SDK.VBExamples
    Public Module CreatePackageWithSMSAuthentication
        Dim apiToken = "YOUR TOKEN HERE"
        Dim baseUrl = "ENVIRONMENT URL HERE"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)

            'Signer firstname, lastname, email, title, company
            Dim package = PackageBuilder.NewPackageNamed("VB Package " + DateTime.Now) _
                .DescribedAs("This is a new package") _
                .ExpiresOn(DateTime.Now.AddDays(5)) _
                .WithEmailMessage("This message should appear in email invitation to signers") _
                .InPerson(True) _
                .WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@email.com") _
                    .WithFirstName("John") _
                    .WithLastName("Smith") _
                    .WithTitle("Super Duper") _
                    .WithCompany("Acme Inc") _
                    .WithSMSSentTo("3334445555")) _
                .Build()

            Dim id = client.CreatePackage(package)

            Console.WriteLine("Package {0} was created", id.Id)
        End Sub
    End Module
End Namespace