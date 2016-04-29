using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
	public class CreatePackageWithVariableNumberOfSignersAndDocuments
	{
		public static string apiToken = "YOUR TOKEN HERE";
		public static string baseUrl = "ENVIRONMENT URL HERE";

		public static void Main (string[] args)
		{
			// Create new esl client with api token and base url
			EslClient client = new EslClient (apiToken, baseUrl);
			//Get my hands on the list of signers somehow...
			List<SignerInfo> signers = Signers ();
			//Get my hands on the list of documents somehow...
			List<DocumentInfo> documents = Documents ();

			PackageBuilder packageBuilder = PackageBuilder.NewPackageNamed ("Package with variable number of signers and documents")
					.DescribedAs ("This is a new package");

			foreach (SignerInfo signer in signers)
			{
				packageBuilder.WithSigner (SignerBuilder.NewSignerWithEmail (signer.Email)
				                           .WithFirstName (signer.FirstName)
				                           .WithLastName (signer.LastName)
				                           .Build ());
			}

			foreach (DocumentInfo document in documents)
			{
				DocumentBuilder documentBuilder = DocumentBuilder.NewDocumentNamed (document.Name).FromFile (document.File.FullName);

				foreach (SignerInfo signer in signers)
				{
					documentBuilder.WithSignature (SignatureBuilder.SignatureFor (signer.Email)
					                               .OnPage (0)
					                               .AtPosition (500, 100)
					                               .Build ());
				}
			}

			PackageId id = client.CreatePackage (packageBuilder.Build());

			client.SendPackage(id);

			Console.WriteLine ("Package {0} was sent", id.Id);
		}

		private static List<SignerInfo> Signers()
		{
			return null;
		}

		private static List<DocumentInfo> Documents()
		{
			return null;
		}
	}

	class SignerInfo
	{
		public String FirstName
		{
			get; set;
		}

		public String LastName
		{
			get; set;
		}

		public String Email
		{
			get; set;
		}
	}

	class DocumentInfo
	{
		public String Name
		{
			get; set;
		}

		public FileInfo File {
			get;
			set;
		}
	}
}