Imports Silanis.ESL.SDK
Imports System.IO

Module CreatePackageExample

    Public ApiToken As String = "api token"
    Public BaseUrl As String = "https://stage-api.e-signlive.com/aws/rest/services"

    Sub Main()

        Dim eslClient As New EslClient(ApiToken, BaseUrl)
        Dim packageService As PackageService = eslClient.PackageService

        ' Create a new package
        Dim packageId As PackageId = packageService.CreatePackage(PackageUtil.NewPackage())
        Console.WriteLine("package id :" + packageId.Id)

        ' Upload document to package
        Dim fileBytes() As Byte = ReadFile("C://path/to/file/document.pdf")
        Dim fileName As String = Path.GetFileName("C://path/to/file/document.pdf")
        packageService.UploadDocument(packageId, fileName, fileBytes, PackageUtil.NewDocument())

        ' Get the package
        Dim package As Package = packageService.GetPackage(packageId)

        ' Send the package
        packageService.SendPackage(packageId)

        ' Create a session token for signer
        Dim sessionService As SessionService = eslClient.SessionService
        Dim sessionToken As SessionToken = sessionService.CreateSessionToken(packageId, PackageUtil.NewSigner())
        Console.WriteLine("The signer can access the session from : http://stage-web.e-signlive.com/access?sessionToken=" + sessionToken.Token)

        ' After the package is complete, download the documents

        ' Download the zip file of all the documents
        Dim downloadedDoc As Byte() = packageService.DownloadDocument(packageId, PackageUtil.NewDocument())
        WriteToFile("C://path/to/save/file/document.pdf", downloadedDoc)

    End Sub

    Function ReadFile(path As String) As Byte()
        Try
            Using fsSource As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read)
                ' Read the source file into a byte array. 
                Dim bytes() As Byte = New Byte((fsSource.Length) - 1) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead. 
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                        numBytesToRead)
                    ' Break when the end of the file is reached. 
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)
                End While
                Return bytes
            End Using
        Catch ioEx As FileNotFoundException
            Throw New IOException(ioEx.Message)
        End Try
    End Function

    Function WriteToFile(path As String, bytes As Byte())
        ' Create a file and write the byte data to a file.
        Dim oFileStream As System.IO.FileStream
        oFileStream = New System.IO.FileStream(path, System.IO.FileMode.Create)
        oFileStream.Write(bytes, 0, bytes.Length)
        oFileStream.Close()
    End Function

End Module
