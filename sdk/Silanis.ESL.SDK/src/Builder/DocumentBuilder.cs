using System;
using System.IO;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder.Internal;

namespace Silanis.ESL.SDK.Builder
{
	public class DocumentBuilder
	{
		private readonly string name;
		private string id;
		private string fileName;
		private DocumentSource documentSource;
		private IList<Signature> signatures = new List<Signature>();
		private int index;
		private bool extract;
		private IList<Field> injectedFields = new List<Field> ();
        private IList<Field> qrCodes = new List<Field> ();
        private string description;
        private External external;

		private DocumentBuilder(string name)
		{
			this.name = name;
		}

		public static DocumentBuilder NewDocumentNamed (string name)
		{
			return new DocumentBuilder (name);
		}

        public DocumentBuilder WithId (string id)
		{
			this.id = id;
			return this;
		}

        public DocumentBuilder WithExternal( External external)
        {
            this.external = external;
            return this;
        }

		public DocumentBuilder FromFile (string fileName)
		{
			this.fileName = fileName;
			documentSource = new FileDocumentSource (fileName);
			return this;
		}

		public DocumentBuilder FromStream (Stream contentStream, DocumentType type)
		{
			documentSource = new StreamDocumentSource (contentStream);
			fileName = DocumentTypeUtility.NormalizeName (type, name);
			return this;
		}

		public DocumentBuilder WithSignature (SignatureBuilder builder)
		{
			return WithSignature (builder.Build ());
		}

		public DocumentBuilder WithSignature (Signature signature)
		{
			signatures.Add (signature);
			return this;
		}

		public DocumentBuilder AtIndex (int index)
		{
			this.index = index;
			return this;
		}

		public DocumentBuilder EnableExtraction ()
		{
			extract = true;
			return this;
		}

		private void Validate ()
		{
			if (String.IsNullOrEmpty(id) && String.IsNullOrEmpty (fileName))
			{
				throw new EslException ("Document fileName must be set",null);
			}
		}

		public DocumentBuilder WithInjectedField (FieldBuilder builder)
		{
			return WithInjectedField (builder.Build());
		}

		public DocumentBuilder WithInjectedField (Field field)
		{
			injectedFields.Add (field);
			return this;
		}

        public DocumentBuilder WithQRCode (FieldBuilder builder)
        {
            return WithQRCode(builder.Build());
        }

        public DocumentBuilder WithQRCode (Field field)
        {
            qrCodes.Add(field);
            return this;
        }

        public DocumentBuilder WithDescription( string description ) {
            this.description = description;
            return this;
        }

		public Document Build ()
		{
			Validate ();

			var doc = new Document ();
			doc.Name = name;
			doc.Id = id;
			doc.FileName = fileName;
			doc.Content = documentSource != null ? documentSource.Content () : null;
			doc.AddSignatures (signatures);
			doc.Index = index;
            doc.External = external;
			doc.Extract = extract;
			doc.AddFields(injectedFields);
            doc.AddQRCodes(qrCodes);
			doc.Description = description;

			return doc;
		}
	}
}