Imports Silanis.ESL.SDK

Public Class PackageUtil

    Shared Function NewPackage() As Package
        Dim role As Role = New Role
        role.Name = "role name"
        role.Type = RoleType.SIGNER
        role.Signers.Add(NewSigner())
        role.Id = "Role1"

        Dim package As Package = New Package
        package.Autocomplete = True
        package.Name = "My Package"
        package.AddRole(role)

        Return package
    End Function

    Shared Function NewSigner() As Signer
        Dim auth As Auth = New Auth
        auth.Scheme = AuthScheme.CHALLENGE

        Dim signer As Signer = New Signer
        signer.Auth = auth
        signer.Email = "email@email.com"
        signer.FirstName = "FirstName"
        signer.LastName = "LastName"
        signer.Id = "Signer1"

        Return signer
    End Function

    Shared Function NewDocument() As Document

        Dim field As Field = New Field
        field.Type = FieldType.SIGNATURE
        field.Subtype = FieldSubtype.FULLNAME
        field.Left = 500.0
        field.Top = 100.0
        field.Height = 50.0
        field.Width = 200.0
        field.Name = "Sign Here"

        Dim field2 As Field = New Field
        field2.Type = FieldType.INPUT
        field2.Subtype = FieldSubtype.TEXTFIELD
        field2.Left = 500.0
        field2.Top = 300.0
        field2.Height = 50.0
        field2.Width = 100.0

        Dim field3 As Field = New Field
        field3.Type = FieldType.INPUT
        field3.Subtype = FieldSubtype.TEXTFIELD
        field3.Left = 500.0
        field3.Top = 400.0
        field3.Height = 50.0
        field3.Width = 100.0

        Dim approval As Approval = New Approval
        approval.AddField(field)
        approval.AddField(field2)
        approval.AddField(field3)
        approval.Role = "Role1"

        Dim document As Document = New Document
        document.AddApproval(approval)
        document.Name = "File Name"
        document.Id = "Doc1"

        Return document
    End Function

End Class
