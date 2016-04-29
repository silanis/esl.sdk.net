Imports System
Imports System.IO
Imports Silanis.ESL.SDK
Imports Silanis.ESL.SDK.Builder
Imports System.Collections.Generic

Namespace SDK.VBExamples
    Public Module GetPackageListExample
        Dim apiToken = "YOUR TOKEN HERE"
        Dim baseUrl = "ENVIRONMENT URL HERE"

        Sub Main()
            ' Create new esl client with api token and base url
            Dim client = New EslClient(apiToken, baseUrl)

            'Get the packages that have status COMPLETED, starting from the most recent package and getting 20 packages per page
            Dim packages = client.PackageService.GetPackages(DocumentPackageStatus.COMPLETED, New PageRequest(1, 20))

            PrintPage(packages)

            While (packages.HasNextPage())
                packages = client.PackageService.GetPackages(DocumentPackageStatus.COMPLETED, packages.NextRequest)
                PrintPage(packages)
            End While
        End Sub

        Sub PrintPage(ByRef page)
            Console.WriteLine("Got {0} packages, total = {1}", page.NumberOfElements, page.TotalElements)

            For Each package In page
                Console.WriteLine("Package {0} has status {1}", package.Name, package.Status)
            Next
        End Sub
    End Module
End Namespace