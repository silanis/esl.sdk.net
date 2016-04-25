using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class PackageCompletionReport
    {
		private Nullable<DateTime> created;
		private IList<DocumentsCompletionReport> documents = new List<DocumentsCompletionReport>();
		private string id;
		private string name;
		private IList<SignersCompletionReport> signers = new List<SignersCompletionReport>();
		private DocumentPackageStatus packageStatus;
		private Boolean trashed;

		public PackageCompletionReport(string name)
        {
			this.name = name;
        }

		public Nullable<DateTime> Created
		{
			get
			{
				return created;
			}
			set
			{
				created = value;
			}
		}

		public IList<DocumentsCompletionReport> Documents
		{
			get
			{
				return documents;
			}
			set
			{
				documents = value;
			}
		}

		public void AddDocument(DocumentsCompletionReport document)
		{
			this.documents.Add(document);
		}

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public IList<SignersCompletionReport> Signers
		{
			get
			{
				return signers;
			}
			set
			{
				signers = value;
			}
		}

		public void AddSigner(SignersCompletionReport signer)
		{
			this.signers.Add(signer);
		}

		public DocumentPackageStatus DocumentPackageStatus
		{
			get
			{
				return packageStatus;
			}
			set
			{
				packageStatus = value;
			}
		}

		public Boolean Trashed
		{
			get
			{
				return trashed;
			}
			set
			{
				trashed = value;
			}
		}
    }
}

