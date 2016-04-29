Imports System
Imports System.IO
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder

Namespace SDK.VBExamples
    Public Module FieldValidationExample
        Dim apiToken = "YOUR TOKEN HERE"
        Dim baseUrl = "ENVIRONMENT URL HERE"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)
            Dim file = New FileInfo(Directory.GetCurrentDirectory() + My.Resources.document)

            Dim package = PackageBuilder.NewPackageNamed("Fields example " + DateTime.Now) _
                .DescribedAs("This is a new package") _
                .WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@email.com") _
                    .WithFirstName("John") _
                    .WithLastName("Smith")) _
                .WithDocument(DocumentBuilder.NewDocumentNamed("My Document") _
                    .FromFile(file.FullName) _
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com") _
                        .OnPage(0) _
                        .AtPosition(500, 100) _
                        .WithField(FieldBuilder.TextField() _
                            .OnPage(0) _
                            .AtPosition(500, 200) _
                            .WithValidation(FieldValidatorBuilder.Alphabetic() _
                                .MaxLength(10) _
                                .MinLength(3) _
                                .Required() _
                                .WithErrorMessage("This field is not alphabetic"))) _
                        .WithField(FieldBuilder.TextField() _
                            .OnPage(0) _
                            .AtPosition(500, 300) _
                            .WithValidation(FieldValidatorBuilder.Numeric() _
                                .WithErrorMessage("This field is not numeric"))) _
                        .WithField(FieldBuilder.TextField() _
                            .OnPage(0) _
                            .AtPosition(500, 400) _
                            .WithValidation(FieldValidatorBuilder.Alphanumeric() _
                                .WithErrorMessage("This field is not alphanumeric"))) _
                        .WithField(FieldBuilder.TextField() _
                            .OnPage(0) _
                            .AtPosition(500, 500) _
                            .WithValidation(FieldValidatorBuilder.Email() _
                                .WithErrorMessage("The value in this field is not an email address"))) _
                        .WithField(FieldBuilder.TextField() _
                            .OnPage(0) _
                            .AtPosition(500, 600) _
                            .WithValidation(FieldValidatorBuilder.URL() _
                                .WithErrorMessage("The value in this field is not a valid URL"))) _
                        .WithField(FieldBuilder.TextField() _
                            .OnPage(0) _
                            .AtPosition(500, 700) _
                            .WithValidation(FieldValidatorBuilder.Regex("^[0-9a-zA-Z]+$") _
                                .WithErrorMessage("The value in this field does not match the expression"))))) _
                .Build()

            Dim id = client.CreatePackage(package)

            client.SendPackage(id)

            Console.WriteLine("Package {0} was sent", id.Id)
        End Sub
    End Module
End Namespace