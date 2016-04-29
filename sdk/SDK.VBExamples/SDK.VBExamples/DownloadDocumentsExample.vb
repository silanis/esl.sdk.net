Imports System
Imports System.IO
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder

Namespace SDK.VBExamples
    Public Module DownloadDocumentsExample
        Dim apiToken = "YOUR TOKEN HERE"
        Dim baseUrl = "ENVIRONMENT URL HERE"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)
            Dim packageId = New PackageId("GLK2xasqLvFe2wc4qwO5iTKyjx42")

            Dim documentContent = client.DownloadDocument(packageId, "testing")
            File.WriteAllBytes(Directory.GetCurrentDirectory() + "/downloaded.pdf", documentContent)

            Dim evidenceContent = client.DownloadEvidenceSummary(packageId)
            File.WriteAllBytes(Directory.GetCurrentDirectory() + "/evidence-summary.pdf", evidenceContent)

            Dim zipContent = client.DownloadZippedDocuments(packageId)
            File.WriteAllBytes(Directory.GetCurrentDirectory() + "/package-documents.zip", zipContent)
        End Sub
    End Module
End Namespace